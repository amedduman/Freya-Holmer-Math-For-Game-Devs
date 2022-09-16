using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizedVector : MonoBehaviour
{
    [SerializeField] Transform _target;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        Vector3 target = _target.position;

        Vector3 diffVec = target - center;

        Vector3 dirToTarget = diffVec.normalized;

        Gizmos.DrawLine(center, dirToTarget);
    }
}
