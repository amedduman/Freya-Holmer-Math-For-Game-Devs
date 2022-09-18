using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformation : MonoBehaviour
{
    [SerializeField] Transform _point;
    [SerializeField] Vector2 _pos;
    [SerializeField] Vector2 _rot;

    [SerializeField] float _localX;
    [SerializeField] float _localY;

    void OnDrawGizmos()
    {
        if(_point == null) return;

        Vector2 pointPos = new Vector2(_point.position.x, _point.position.y);
        pointPos -= new Vector2(transform.position.x, transform.position.y);

        Vector2 r = transform.right;
        _localX = Vector2.Dot(r, pointPos);

        Vector2 u = transform.up;
        _localY = Vector2.Dot(u, pointPos);
    }
}
