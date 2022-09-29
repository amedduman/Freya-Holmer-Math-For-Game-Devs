using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveFieldOfView : MonoBehaviour
{
    [SerializeField] Transform _object;

    void OnDrawGizmos()
    {
        if(_object == null) return;

        GameObject[] objects = new GameObject[_object.childCount];

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = _object.transform.GetChild(i).gameObject;
        }

        Bounds bound = new Bounds(_object.position, Vector3.zero);
        foreach (var obj in objects)
        {
            bound.Encapsulate(obj.transform.position);
        }

        Gizmos.matrix = Matrix4x4.identity;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(bound.center, bound.extents * 2);


        float a = Vector3.Distance(bound.center, transform.position);
        float o = bound.extents.y;
        float angle = Mathf.Atan(o/a);

        Camera.main.fieldOfView = angle * 2 * Mathf.Rad2Deg;
    }
}
