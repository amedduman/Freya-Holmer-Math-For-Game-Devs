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
            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawLine(points[i], points[(i + 1) % _pointCount]);
            }
        }

        void DrawPentagrams()
        {
            Gizmos.color = Color.white;
            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawLine(points[i], points[(i + _density) % _pointCount]);
            }
        }
    }

    enum DrawMode
    {
        Pentagon,
        Pentagram
    }
}