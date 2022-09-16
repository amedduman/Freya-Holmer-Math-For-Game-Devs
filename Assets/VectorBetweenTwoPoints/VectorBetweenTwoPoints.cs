using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorBetweenTwoPoints : MonoBehaviour
{
    [SerializeField] Transform _a;
    [SerializeField] Transform _b;

    void OnDrawGizmos()
    {
        Vector3 aToBDir = (_b.position - _a.position).normalized;
        Gizmos.DrawLine(_a.position, _a.position + aToBDir);
    }
}
