using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] positions = new Transform[3];
    public float jumpHeight = 3f;
    public float moveSpeed = 5f;
    
    [SerializeField] private InputAction moveLeft, moveRight, jump;
    private int positionIndex;
    private Rigidbody rb;

    private Vector3 newPos;
    private bool isMoving = false;
    private bool canJump = false;

    #region InputShit
    private void OnEnable()
    {
        moveLeft.Enable();
        moveRight.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        moveLeft.Disable();
        moveRight.Disable();
        jump.Disable();
    }

    private void OnDestroy()
    {
        moveLeft.Disable();
        moveRight.Disable();
        jump.Disable();
    }
    #endregion

    void Start()
    {
        positionIndex = 1;
        rb = GetComponent<Rigidbody>();
        transform.position = positions[positionIndex].position;
        newPos = transform.position;
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
        canJump = IsGrounded();
    }


    public void MovePlayer()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, newPos) < 0.01f)
            {
                transform.position = newPos;
                isMoving = false;
            }
        }
    }

    public void HandleInput()
    {
        if (moveLeft.triggered)
        {
            positionIndex--;
            if (positionIndex < 0) positionIndex = positions.Length - 1;
            newPos = new Vector3(positions[positionIndex].position.x, transform.position.y, transform.position.z);
            isMoving = true;
        }

        if (moveRight.triggered)
        {
            positionIndex++;
            if (positionIndex >= positions.Length) positionIndex = 0;
            newPos = new Vector3(positions[positionIndex].position.x, transform.position.y, transform.position.z);
            isMoving = true;
        }

        if (jump.triggered && canJump)
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
    
    private bool IsGrounded()
    {
        float raycastDistance = 1.1f;
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        // Debug.DrawRay(transform.position, Vector3.down * raycastDistance, Color.red);
        return Physics.Raycast(transform.position, Vector3.down, raycastDistance, groundLayer);
    }
}