using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(LineRenderer))]
public class Hermite : MonoBehaviour
{
	private LineRenderer lineRenderer;

	[SerializeField] private Transform startPoint, startTangent, endPoint, endTangent;
	[SerializeField] private int numberOfPoints = 20;

	void Awake() 
	{
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update()
	{
		SetCurve();
	}

	private void SetCurve()
    {
		Vector3 p0 = startPoint.position;
		Vector3 p1 = endPoint.position;
		Vector3 m0 = startTangent.position - startPoint.position;
		Vector3 m1 = endTangent.position - endPoint.position;
		float t;
		Vector3 pos;

		for (int i = 0; i < numberOfPoints; i++)
		{
			t = i / (numberOfPoints - 1.0f);
			pos = PositionOnCurve(t, p0, m0, p1, m1);
			lineRenderer.SetPosition(i, pos);
		}
	}

	private Vector3 PositionOnCurve(float _t,Vector3 _p0,Vector3 _m0,Vector3 _p1,Vector3 _m1)
    {
		Vector3 _pos= (2.0f * _t * _t * _t - 3.0f * _t * _t + 1.0f) * _p0
		              + (_t * _t * _t - 2.0f * _t * _t + _t) * _m0
		              + (-2.0f * _t * _t * _t + 3.0f * _t * _t) * _p1
		              + (_t * _t * _t - _t * _t) * _m1;
		return _pos;
	}
}
