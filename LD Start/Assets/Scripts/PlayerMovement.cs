using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform topCheck;
    [SerializeField]
    float groundDistance;
    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    float speed;
    [SerializeField]
    float gravity;
    [SerializeField]
    float jumpHeight;

    bool isGrounded;

    Vector3 velocity;

    CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            charController.stepOffset = 0f;
        }
        else if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            charController.stepOffset = 0.5f;
        }

        // apply input
        controller.Move(MoveInput() * speed * Time.deltaTime);

        CrouchInput();

        // apply gravity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    Vector3 MoveInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //charController.SimpleMove(Vector3.ClampMagnitude(transform.right * x + transform.forward * z, 1) * speed);

        return Vector3.ClampMagnitude(transform.right * x + transform.forward * z, 1);
    }

    void CrouchInput()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 0.6f, 1);
        }
        else if (!Physics.CheckSphere(topCheck.position, groundDistance, groundMask))
        {            
            transform.localScale = new Vector3(1, 1, 1);

        }

    }
}
