using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerCam playerCam;
    private PlayerInteraction playerInteraction;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform orientation;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    private bool canMove = true;

    private void Start()
    {
        playerCam = FindFirstObjectByType<PlayerCam>();
        rb = GetComponent<Rigidbody>();
        playerInteraction = GetComponent<PlayerInteraction>();
    }

    private void Update()
    {
        if (!canMove) return;
        
        MyInput();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        rb.AddForce(moveDirection * (moveSpeed * 10f), ForceMode.Force);
    }

    public void EnterDialogue()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        
        playerInteraction.canInteract = false;
        
        canMove = false;
        playerCam.canRotate = false;
    }

    public void ExitDialogue()
    {
        playerInteraction.canInteract = true;
        
        canMove = true;
        playerCam.canRotate = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
