using System.Runtime.CompilerServices;
using UnityEngine;

public class Movimentação : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public float mouseSensitivy = 2f;
    public float runSpeed = 10f;
    private bool isRunning = false;
    private float lastWPressTime = -1f;
    public float doubleTapTime = 0.3f;


    private Vector3 velocity;
    private bool isGrounded;
    private CharacterController controller;

    private Transform cam;

    private float xRotation = 0f;
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        cam = transform.Find("Main Camera");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // checagem de solo
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f; // mantém o personagem preso ao chão
        }

        // entrada de movimento
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Detectar duplo toque no W
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Time.time - lastWPressTime < doubleTapTime)
            {
                isRunning = true;
            }
            lastWPressTime = Time.time;
        }

        // Interromper corrida se soltar W
        if (Input.GetKeyUp(KeyCode.W))
        {
            isRunning = false;
        }

        float currentSpeed = isRunning ? runSpeed : moveSpeed;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // pulo 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // rotação com o mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
