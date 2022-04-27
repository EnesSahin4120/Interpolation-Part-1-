using UnityEngine;

public class SLERP_Test : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Quaternion targetQuaternion;
    private Quaternion startQuaternion;

    [Range(0,1)]
    [SerializeField] private float time;

    private void Start()
    {
        startQuaternion = cube.transform.rotation;
    }

    private void Update()
    {
        cube.transform.rotation = Orientation.SLERP(startQuaternion, targetQuaternion, time);
    }
}
