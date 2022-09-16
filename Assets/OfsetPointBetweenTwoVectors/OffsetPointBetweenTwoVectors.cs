using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPointBetweenTwoVectors : MonoBehaviour
{
    [SerializeField] Transform _a;
    [SerializeField] Transform _b;
    [Range(1, 4)] [SerializeField] float _range = 1;

    void OnDrawGizmos()
    {
        Vector3 aToBDir = (_b.position - _a.position).normalized;
        Gizmos.DrawLine(_a.position, _a.position + aToBDir);

        Gizmos.DrawSphere(_a.position +  aToBDir * _range, .1f);
    }
}
