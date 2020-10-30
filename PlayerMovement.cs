using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharController;
    public float PlayerSpeed = 10f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance= 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Camera playerCam;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate (bulletPrefab);
            bulletObject.transform.position = playerCam.transform.position + playerCam.transform.forward;
            bulletObject.transform.forward = playerCam.transform.forward;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        CharController.Move(move * PlayerSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        CharController.Move(velocity * Time.deltaTime);

    }
}
