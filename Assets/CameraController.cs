using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ronaldo;

    private float cameraSize;
    private float screenHeight;

    
    void Start()
    {
        cameraSize = Camera.main.orthographicSize;
        screenHeight = cameraSize * 2;

    }

    
    void Update()
    {
        CalculateCameraPosition();
    }

    void CalculateCameraPosition()
    { 
    int screenRonaldo = (int)(ronaldo.position.y / screenHeight);
        float cameraHeight = (screenRonaldo * screenHeight) + cameraSize;
        transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
    }

}
