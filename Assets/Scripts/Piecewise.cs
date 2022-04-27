using UnityEngine;

public class Piecewise : MonoBehaviour
{
    public float[] timeRanges;
    public Vector3[] points;
    public float t;

    public GameObject ball;

    private void Start()
    {
        Debug.DrawLine(points[0], points[1], Color.red, Mathf.Infinity);
        Debug.DrawLine(points[1], points[2], Color.red, Mathf.Infinity);
        Debug.DrawLine(points[2], points[3], Color.red, Mathf.Infinity);
    }

    private void Update()
    {
        ball.transform.position = EvaluatePiecewiseLinear(t, points, timeRanges);
    }

    private Vector3 EvaluatePiecewiseLinear (float _t, Vector3[] _positions, float[] _times)
    {
        if (_t <= _times[0])
            return _positions[0];
        else if (_t >= _times[_positions.Length - 1])
            return _positions[_positions.Length - 1];

        int i;
        for (i = 0; i < _positions.Length; i++)
        {
            if (_t < _times[i + 1])
                break;
        }

        float t0 = _times[i];
        float t1 = _times[i + 1];
        float u = (_t - t0) / (t1 - t0);

        return (1 - u) * _positions[i] + u * _positions[i + 1];
    }
}
