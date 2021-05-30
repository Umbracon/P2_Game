using UnityEngine;

public class SnakeSpawn : MonoBehaviour
{
    [SerializeField]
    Material destMaterial;

    Material initMaterial;

    static RopeController uncoiledSnake;

    void Start()
    {
        uncoiledSnake = null;

        initMaterial = GetComponent<MeshRenderer>().material;
    }

    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material = destMaterial;
    }

    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = initMaterial;
    }

    void OnMouseDown()
    {
        if (uncoiledSnake != null)
        {
            StartCoroutine(uncoiledSnake.CoilSnake(1f / 60f));
        }

        uncoiledSnake = GetComponentInChildren<RopeController>();

        if (uncoiledSnake != GetComponentInChildren<RopeController>())
        {
            StartCoroutine(uncoiledSnake.UncoilSnake(1f / 60f));
        }
    }
}
