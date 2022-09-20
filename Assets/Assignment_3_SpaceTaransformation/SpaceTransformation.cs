using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformation : MonoBehaviour
{
    [SerializeField] Transform _point;

    [SerializeField] Vector2 _localPos;

    [SerializeField] Vector2 _globalPos;

    void OnDrawGizmos()
    {
        if(_point == null) return;
        
        GlobalToLocal();
        
        void GlobalToLocal()
        {
            Vector2 offsetInWorldSpace = _point.position - transform.position;
            float localX = Vector2.Dot(transform.right, offsetInWorldSpace);
            float localY = Vector2.Dot(transform.up, offsetInWorldSpace);
            
            _localPos = new Vector2(localX, localY);
        }

        LocalToGlobal();

        void LocalToGlobal()
        {
            _globalPos = transform.right * _localPos.x + transform.up * _localPos.y;

            _globalPos = (Vector2)transform.position + _globalPos;
        }
    }
}
