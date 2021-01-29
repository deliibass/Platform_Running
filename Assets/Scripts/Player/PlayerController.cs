using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;

    private Animator playerAnim;

    public CharacterController controller;

    public float playerSpeed = 8f;
    public float jumpForce;

    public Transform pivot;
    public float rotateSpoeed;

    private Vector3 moveDirection;
    public float gravityScale;

    public GameObject playerModel;

    public float knockBackForce;
    public float knockBackTime;
    public float knockBackCounter;

    public PaintSectionManager pC;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        joystick = FindObjectOfType<Joystick>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(knockBackCounter <= 0)
        {
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * (joystick.Vertical + Input.GetAxis("Vertical")) * playerSpeed) + (transform.right * (joystick.Horizontal + Input.GetAxis("Horizontal")) * playerSpeed);
            moveDirection = moveDirection.normalized * playerSpeed;
            moveDirection.y = yStore;
            if (controller.isGrounded)
            {
                moveDirection.y = 0f;
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * Time.deltaTime * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

        //moveDirection the player in different directions based on camera look direction
        if((joystick.Vertical + Input.GetAxis("Vertical")) != 0 || (joystick.Horizontal + Input.GetAxis("Horizontal")) != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpoeed * Time.deltaTime);
        }

        playerAnim.SetBool("isGrounded", controller.isGrounded);
        playerAnim.SetFloat("moveSpeed", (Mathf.Abs((joystick.Vertical + Input.GetAxis("Vertical"))) + (Mathf.Abs((joystick.Horizontal + Input.GetAxis("Horizontal"))))));
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }
}
