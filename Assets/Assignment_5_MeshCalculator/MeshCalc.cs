using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCalc : MonoBehaviour
{
    [SerializeField] Mesh _mesh;
    [SerializeField] float _area;
    void OnValidate()
    {
        _area = 0;
        Vector3[] verts = _mesh.vertices;
        int[] tris = _mesh.triangles;

        for (int i = 0; i < tris.Length; i+= 3)
        {
            Vector3 a = verts[tris[i]];
            Vector3 b = verts[tris[i + 1]];
            Vector3 c = verts[tris[i + 2]];

            _area += Vector3.Cross(b-a, c-a).magnitude;

        }

        _area /= 2;
    }
}
