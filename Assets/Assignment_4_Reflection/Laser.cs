using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] Transform _hitRefTf;
    void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            //Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.green);
            Vector3 normal = hit.normal;

            Vector3 comingVector = transform.forward * hit.distance;

            Vector3 outgoingVector = comingVector - 2 * (Vector3.Dot(normal, comingVector) * normal);

            //Vector3 x = Vector3.Dot(normal, comingVector) * normal * -2;
            Debug.Log(Vector3.Dot(normal, comingVector));
            Vector3 x = Vector3.Dot(normal, comingVector) * normal;

            Debug.DrawRay(transform.position,  comingVector, Color.green);
            Debug.DrawRay(hit.point,  outgoingVector, Color.red); 

            Debug.DrawRay(hit.point, x, Color.magenta);
            Debug.DrawRay(hit.point, normal, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);
        }
    }
}
