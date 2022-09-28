using UnityEngine;

public class PointsAroundCircle : MonoBehaviour
{
    public const float TAU = 6.28318530718f;

    [SerializeField][Range(3, 15)] int _pointCount = 4;
    [SerializeField][Range(2, 10)] int _density = 2;
    [SerializeField] DrawMode _drawMode = DrawMode.Pentagon;

    void OnDrawGizmos()
    {
        if (_pointCount <= 2) return;

        Vector2[] points = new Vector2[_pointCount];

        Gizmos.color = Color.red;
        for (int i = 0; i < _pointCount; i++)
        {
            float t = i / (float)_pointCount;

            float angRad = TAU * t;

            float x = Mathf.Cos(angRad);
            float y = Mathf.Sin(angRad);

            Vector2 point = new Vector2(x, y);

            Gizmos.DrawSphere(point, .1f);
            points[i] = point;
        }
        switch (_drawMode)
        {
            case DrawMode.Pentagon:
                DrawPentagons();
                break;
            case DrawMode.Pentagram:
                DrawPentagrams();
                break;
            default:
                break;
        }

        void DrawPentagons()
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < points.Length - 1; i++)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
            Gizmos.DrawLine(points[points.Length - 1], points[0]);
        }

        void DrawPentagrams()
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < points.Length - _density; i++)
            {
                Gizmos.DrawLine(points[i], points[i + _density]);
            }
            for (int j = _density; j > 0; j--)
            {
                if(j == _density)
                {
                    Gizmos.DrawLine(points[points.Length - j], points[0]);
                }
                Gizmos.DrawLine(points[points.Length - j], points[j]);
            }
        }
    }

    enum DrawMode
    {
        Pentagon,
        Pentagram
    }
}


// void DrawPentagrams()
// {
//     Gizmos.color = Color.white;
//     for (int i = 0; i < points.Length - 2; i++)
//     {
//         Gizmos.DrawLine(points[i], points[i + 2]);
//     }
//     Gizmos.DrawLine(points[points.Length - 2], points[0]);
//     Gizmos.DrawLine(points[points.Length - 1], points[1]);
// }