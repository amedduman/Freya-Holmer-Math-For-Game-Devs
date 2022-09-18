using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    [SerializeField] float _range = 1;
    [SerializeField] Transform _target;

    void OnDrawGizmos()
    {

        float distance = Vector3.Distance(transform.position, _target.position);

        if(distance < _range)
        {
            Gizmos.color = Color.green;
        }

        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawSphere(transform.position, _range);

    }
}
