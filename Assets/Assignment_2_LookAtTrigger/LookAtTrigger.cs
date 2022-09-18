using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] Transform  _player;
    [SerializeField] [Range(0, 1)] float _threshold = .8f; 

    void OnDrawGizmos()
    {
        var playerDir = _player.up;
        var myDir = transform.up;

       var dot = Vector3.Dot(playerDir, myDir);

       if(dot > _threshold)
       {
            Gizmos.color = Color.green;
       }
       else 
       {
            Gizmos.color = Color.red;
       }

       Gizmos.DrawSphere(transform.position, .1f);
    }
}
