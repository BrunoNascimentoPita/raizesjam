using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        // Aplica suavização com Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Arredonda para evitar tremedeira
        smoothedPosition.x = Mathf.Round(smoothedPosition.x * 100) / 100;
        smoothedPosition.y = Mathf.Round(smoothedPosition.y * 100) / 100;

        transform.position = smoothedPosition;
    }
}
