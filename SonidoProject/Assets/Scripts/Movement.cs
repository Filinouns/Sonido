using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float walkSpeed = 2.0f;
    private float runSpeed = 3.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float speed;

    public CursorLockMode cursorLockMode = CursorLockMode.Locked;
    public bool cursorVisible = false;
    [Space]
    [Header("Look")]
    public Transform cameraPivot;
    public float lookSpeed = 45;
    public bool invertY = true;
    private Quaternion targetRotation, targetPivotRotation;

    void Awake()
    {
        Cursor.lockState = cursorLockMode;
        Cursor.visible = cursorVisible;
    }

    private void Start()
    {
        if (gameObject.GetComponent<CharacterController>() != null)
        {
            controller = gameObject.GetComponent<CharacterController>();
        }
        else
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    void Update()
    {
        UpdateTranslation();
        UpdateRotation();
    }

    void UpdateTranslation()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        var run = Input.GetKey(KeyCode.LeftShift);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        speed = run ? runSpeed : walkSpeed;
        Vector3 movement = transform.TransformDirection(move * speed);
        controller.Move(movement * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void UpdateRotation()
    {
        var x = Input.GetAxis("Mouse Y");
        var y = Input.GetAxis("Mouse X");

        x *= invertY ? -1 : 1;
        targetRotation = transform.localRotation * Quaternion.AngleAxis(y * lookSpeed * Time.deltaTime, Vector3.up);
        targetPivotRotation = cameraPivot.localRotation * Quaternion.AngleAxis(x * lookSpeed * Time.deltaTime, Vector3.right);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * 15);
        cameraPivot.localRotation = Quaternion.Slerp(cameraPivot.localRotation, targetPivotRotation, Time.deltaTime * 15);
    }
}