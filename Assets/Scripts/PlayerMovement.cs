using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Variables publicas
    public float walkSpeed, runSpeed, jumpForce, rotationSpeed;
    public bool canMove;
    public Transform CameraAim;
    public GroundDetector groundDetector;


    //Variables privadas
    private Vector3 vectorMovement;
    private Vector3 verticalForce;
    private float speed;
    private CharacterController characterController;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        //inicializacion de variables
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        verticalForce = Vector3.zero;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Walk();
            Run();
            AlignPlayer();
            Jump();
        }
        Gravity();
        checkGround();
    }

    void Walk()
    {
        //conseguimos los inputs
        vectorMovement.x = Input.GetAxis("Horizontal");
        vectorMovement.z = Input.GetAxis("Vertical");

        //normalizamos el vector de movimiento
        vectorMovement = vectorMovement.normalized;

        //Nos movemos en direccion a la camara
        vectorMovement = CameraAim.TransformDirection(vectorMovement);

        //Movemos al player
        characterController.Move(vectorMovement * speed * Time.deltaTime);
    }

    void Run()
    {
        //si presionamos left alt modificamos la velovidad
        if (Input.GetAxis("Run") > 0)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

    }

    void Gravity()
    {
        if (!isGrounded) 
        {
            verticalForce += Physics.gravity * Time.deltaTime;
        }
        else
        {
            verticalForce = new Vector3(0f, -2, 0f);
        }
        characterController.Move(verticalForce * Time.deltaTime);
    }

    void AlignPlayer()
    {
        if (characterController.velocity.magnitude > 0f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }

    void checkGround()
    {
        isGrounded = groundDetector.GetIsGrounded();

    }

    void Jump()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0f)
        {
            verticalForce = new Vector3(0f, jumpForce, 0f);
            isGrounded = false;
            //Debug.Log("sientra");
        }
    }
}
