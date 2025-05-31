using UnityEngine;

public class controlarCamara : MonoBehaviour
{
    public Transform ronaldo;     
    public Vector3 offset;        
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (ronaldo == null) return;

        Vector3 desiredPosition = ronaldo.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
