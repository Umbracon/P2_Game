using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    GameObject fragmentPrefab;

    [SerializeField]
    GameObject junctionPrefab;

    [SerializeField]
    int fragmentCount = 80;

    [SerializeField]
    Vector3 interval = new Vector3(0f, 0f, 0.25f);

    GameObject[] fragments;

    float activeFragmentCount;

    Vector3 position;

    float[] xPositions;
    float[] yPositions;
    float[] zPositions;

    CatmullRomSpline splineX;
    CatmullRomSpline splineY;
    CatmullRomSpline splineZ;

    int splineFactor = 4;

    float vy = -0.4f;

    void Start()
    {
        activeFragmentCount = fragmentCount;

        fragments = new GameObject[fragmentCount];

        //var position = Vector3.zero;
        position = transform.position;

        for (var i = 0; i < fragmentCount; i++)
        {
            fragments[i] = Instantiate(fragmentPrefab, position, Quaternion.identity);
            fragments[i].transform.SetParent(transform);

            //var joint = fragments[i].GetComponent<SpringJoint>();
            var joint = fragments[i].GetComponent<FixedJoint>();
            if (i > 0)
            {
                joint.connectedBody = fragments[i - 1].GetComponent<Rigidbody>();
            }

            if (i == fragmentCount - 1)
            {
                fragments[i].AddComponent<SnakeHead>();
                AttachHeadJunction(i);
            }

            position += interval;
        }

        var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = (fragmentCount - 1) * splineFactor + 1;

        xPositions = new float[fragmentCount];
        yPositions = new float[fragmentCount];
        zPositions = new float[fragmentCount];

        splineX = new CatmullRomSpline(xPositions);
        splineY = new CatmullRomSpline(yPositions);
        splineZ = new CatmullRomSpline(zPositions);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            vy *= -1;
        }

        activeFragmentCount = Mathf.Clamp(activeFragmentCount + vy, 0, fragmentCount);

        for (var i = 0; i < fragmentCount; i++)
        {
            if (i <= fragmentCount - activeFragmentCount)
            {
                //fragments[i].GetComponent<Rigidbody>().position = Vector3.zero;
                fragments[i].GetComponent<Rigidbody>().position = transform.position;
                fragments[i].GetComponent<Rigidbody>().isKinematic = true;
            } else
            {
                fragments[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    void LateUpdate()
    {
        var lineRenderer = GetComponent<LineRenderer>();

        for (var i = 0; i < fragmentCount; i++)
        {
            var position = fragments[i].transform.position;
            xPositions[i] = position.x;
            yPositions[i] = position.y;
            zPositions[i] = position.z;
        }

        for (var i = 0; i < (fragmentCount - 1) * splineFactor + 1; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(
                splineX.GetValue(i / (float)splineFactor),
                splineY.GetValue(i / (float)splineFactor),
                splineZ.GetValue(i / (float)splineFactor)));
        }
    }

    void AttachHeadJunction(int parentIndex)
    {
        var parentTransform = fragments[parentIndex].transform;
        var junction = Instantiate(junctionPrefab, position, Quaternion.identity);

        junction.transform.SetParent(parentTransform);
    }
}