using UnityEngine;

public class PolygonMeshMaker
{
    public static Mesh GetPolygon()
    {
        return new Mesh
        {
            vertices = GetVertecies(),
            triangles = GetTriangles(),
            normals = GetNormals(),
            uv = GetUVs()
        };
    }

    private static Vector3[] GetVertecies()
    {
        var vertecies = new Vector3[3];

        vertecies[0] = new Vector3(0f, 0f, 0f);
        vertecies[1] = new Vector3(0f, 1f, 0f);
        vertecies[2] = new Vector3(0.5f, 0.5f, 0f);

        return vertecies;
    }

    private static int[] GetTriangles()
    {
        var tris = new int[3];

        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;

        return tris;
    }

    private static Vector3[] GetNormals()
    {
        var normals = new Vector3[3];

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;

        return normals;
    }

    private static Vector2[] GetUVs()
    {
        var uvCoordinates = new Vector2[3];

        uvCoordinates[0] = new Vector2(0f, 0f);
        uvCoordinates[1] = new Vector2(0f, 1f);
        uvCoordinates[2] = new Vector2(1f, 0.5f);

        return uvCoordinates;
    }
}
