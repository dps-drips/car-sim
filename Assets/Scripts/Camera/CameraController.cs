using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The target for the camera to follow
    public float chaseDistance = 5.0f;
    public float height = 2.0f;
    public float damping = 1.0f;
    public bool cockpitView = false;

    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0, height, -chaseDistance);
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = target.position + (cockpitView ? Vector3.up * height : offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.LookAt(target);
    }
}
