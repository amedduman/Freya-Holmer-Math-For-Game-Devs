using UnityEngine;

public class PointsAroundCircle : MonoBehaviour
{
    public const float TAU = 6.28318530718f;

    [SerializeField] int _pointCount = 4;

    void OnDrawGizmos()
    {
        for (int i = 0; i < _pointCount; i++)
        {
            float t = i / (float)_pointCount;
            
            float angRad = TAU * t;

            float x = Mathf.Cos(angRad);
            float y = Mathf.Sin(angRad);

            Vector2 point = new Vector2(x,y);

            Gizmos.DrawSphere(point, .1f);
        }
    }
}
