using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCalc : MonoBehaviour
{
    [SerializeField] Mesh _mesh;

    void OnDrawGizmos()
    {
        if(_mesh == null) return;
    }
}
