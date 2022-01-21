using System.Collections;
using UnityEngine;

public class SnakeRenderer : MonoBehaviour {
    public bool isUncoiled = false;
    
    [SerializeField] GameObject fragmentPrefab;
    [SerializeField] GameObject junctionPrefab;
    [SerializeField] int fragmentCount = 80;
    [SerializeField] Vector3 interval = new Vector3(0f, 0f, 0.25f);

    LineRenderer lineRenderer;
    GameObject[] fragments;
    Vector3 position;

    float[] xPositions;
    float[] yPositions;
    float[] zPositions;

    CatmullRomSpline splineX;
    CatmullRomSpline splineY;
    CatmullRomSpline splineZ;

    int splineFactor = 4;

    IEnumerator currCoroutine;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        fragments = new GameObject[fragmentCount];

        position = transform.position;

        InstantiateFragments();
        CountSplines();

        currCoroutine = CoilSnake(0f);
        StartCoroutine(currCoroutine);
    }
    
    void LateUpdate() {
        DrawLines();
    }
    
    void InstantiateFragments() {
        for (var i = 0; i < fragmentCount; i++) {
            fragments[i] = Instantiate(fragmentPrefab, position, Quaternion.identity);
            fragments[i].transform.SetParent(transform);

            var joint = fragments[i].GetComponent<FixedJoint>();

            if (i > 0) {
                joint.connectedBody = fragments[i - 1].GetComponent<Rigidbody>();
            }

            if (i == fragmentCount - 1) {
                fragments[i].AddComponent<SnakeHead>();
                AttachHeadJunction(i);
            }

            position += interval;
        }
    }

    public IEnumerator CoilSnake(float seconds) {
        isUncoiled = false;
        for (var i = 0; i < fragmentCount; i++) {
            fragments[i].GetComponent<SphereCollider>().enabled = false;
            fragments[i].GetComponent<Rigidbody>().isKinematic = true;
            fragments[i].GetComponent<Rigidbody>().position = transform.position;

            yield return new WaitForSeconds(seconds);
        }

        lineRenderer.enabled = false;
    }

    public IEnumerator UncoilSnake(float seconds) {
        isUncoiled = true;
        lineRenderer.enabled = true;
        for (var i = 0; i < fragmentCount; i++) {
            fragments[i].GetComponent<Rigidbody>().isKinematic = false;

            yield return new WaitForSeconds(seconds);
        }

        Invoke(nameof(ActivateColliders), 0.06f);
    }

    void CountSplines() {
        var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = (fragmentCount - 1) * splineFactor + 1;

        xPositions = new float[fragmentCount];
        yPositions = new float[fragmentCount];
        zPositions = new float[fragmentCount];

        splineX = new CatmullRomSpline(xPositions);
        splineY = new CatmullRomSpline(yPositions);
        splineZ = new CatmullRomSpline(zPositions);
    }


    void DrawLines() {
        for (var i = 0; i < fragmentCount; i++) {
            var position = fragments[i].transform.position;
            xPositions[i] = position.x;
            yPositions[i] = position.y;
            zPositions[i] = position.z;
        }

        for (var i = 0; i < (fragmentCount - 1) * splineFactor + 1; i++) {
            lineRenderer.SetPosition(i, new Vector3(
                splineX.GetValue(i / (float) splineFactor),
                splineY.GetValue(i / (float) splineFactor),
                splineZ.GetValue(i / (float) splineFactor)));
        }
    }

    void AttachHeadJunction(int parentIndex) {
        var parentTransform = fragments[parentIndex].transform;
        var junction = Instantiate(junctionPrefab, position, Quaternion.identity);

        junction.transform.SetParent(parentTransform);
    }

    void ActivateColliders() {
        for (var i = 0; i < fragmentCount; i++) {
            fragments[i].GetComponent<SphereCollider>().enabled = true;
        }
    }
}