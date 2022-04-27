using UnityEngine;

public class Orientation : MonoBehaviour
{
    static public Quaternion SLERP(Quaternion startQuaternion,Quaternion endQuaternion,float t)
    {
        float theta = Angle(startQuaternion, endQuaternion);
        float x = (Mathf.Sin((1 - t) * theta) * startQuaternion.x + Mathf.Sin(t * theta) * endQuaternion.x) / Mathf.Sin(theta);
        float y = Mathf.Sin((1 - t) * theta) * endQuaternion.y + Mathf.Sin(t * theta) * endQuaternion.y / Mathf.Sin(theta);
        float z = Mathf.Sin((1 - t) * theta) * startQuaternion.z + Mathf.Sin(t * theta) * endQuaternion.z / Mathf.Sin(theta);
        float w = Mathf.Sin((1 - t) * theta) * startQuaternion.w + Mathf.Sin(t * theta) * endQuaternion.w / Mathf.Sin(theta);

        Quaternion result = new Quaternion(x, y, z, w);
        return result;
    }

    static public float Dot(Quaternion quaternion1,Quaternion quaternion2)
    {
        float dot= (quaternion1.x * quaternion2.x
                  + quaternion1.y * quaternion2.y
                  + quaternion1.z * quaternion2.z
                  + quaternion1.w * quaternion2.w);
        return dot;
    }

    static public float Angle(Quaternion quaternion1,Quaternion quaternion2)
    {
        float angle = Mathf.Acos(Dot(quaternion1, quaternion2));
        return angle;
    }
}
