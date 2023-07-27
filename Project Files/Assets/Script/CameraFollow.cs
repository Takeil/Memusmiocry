using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desirePosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);

        transform.position = smoothedPosition;
    }

    public void setTarget(Transform _target)
    {
        target = _target;
    }

    public void SetSpeed(float speed)
    {
        smoothSpeed = speed;
    }
}
