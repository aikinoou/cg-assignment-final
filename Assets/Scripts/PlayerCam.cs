using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;

    private float xRotation;
    private float yRotation;
    public bool canRotate = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!canRotate) return;
        
        MoveCamera();
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.fixedDeltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.fixedDeltaTime;
        
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }

    private void MoveCamera()
    {
        transform.position = player.transform.position;
    }
}
