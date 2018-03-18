using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class PolygonComponent : MonoBehaviour
{
    public Material Material;

    void Start()
    {
        if(Material == null)
            Material = new Material(Shader.Find("Default"));

        gameObject.GetComponent<MeshRenderer>().material = Material;
        gameObject.GetComponent<MeshFilter>().mesh = PolygonMeshMaker.GetPolygon();
    }
}
