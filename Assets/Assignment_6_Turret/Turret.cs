using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform _turret;
    void OnDrawGizmos()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            Vector3 normal = hit.normal;
            Vector3 comingVector = transform.forward * hit.distance;

            Vector3 playerLookDir = hit.point - transform.position;

            Vector3 up = normal;
            Vector3 right = Vector3.Cross(up, playerLookDir).normalized;
            Vector3 forward = Vector3.Cross(_turret.right, _turret.up).normalized;

            _turret.up = up;
            _turret.position = hit.point;

            Vector3[] corners = new Vector3[] {
            // bottom 4 positions:
            new Vector3( 1, 0, 1 ), 
            new Vector3( -1, 0, 1 ),
            new Vector3( -1, 0, -1 ),
            new Vector3( 1, 0, -1 ),
            // top 4 positions:
            new Vector3( 1, 2, 1 ),
            new Vector3( -1, 2, 1 ),
            new Vector3( -1, 2, -1 ),
            new Vector3( 1, 2, -1 )
        };

            Quaternion turretRot = Quaternion.LookRotation(forward, up);
            Matrix4x4 turretToWorld = Matrix4x4.TRS(hit.point, turretRot, Vector3.one);
            
            Gizmos.color = Color.yellow;
            Gizmos.matrix = turretToWorld;
            for (int i = 0; i < corners.Length; i++)
            {

                Gizmos.DrawSphere(corners[i], .07f);
            }



            Debug.DrawRay(hit.point, up, Color.green);
            Debug.DrawRay(hit.point, right, Color.red);
            Debug.DrawRay(hit.point, forward, Color.blue);



            Debug.DrawRay(transform.position, comingVector, Color.white);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10, Color.yellow);
        }
    }
}
