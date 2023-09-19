using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Variables publicas
    public float walkSpeed, runSpeed, rotationSpeed;
    public bool canMove;
    public Transform CameraAim;


    //Variables privadas
    private Vector3 vectorMovement;
    private float speed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        //inicializacion de variables
        characterController = GetComponent<CharacterController>();
        speed = walkSpeed;
        vectorMovement = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        { 
            Walk();
            Run();
            AlignPlayer();
        }
        Gravity();
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
        if(Input.GetAxis("Run") > 0)
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
        characterController.Move(new Vector3(0f, -4f * Time.deltaTime, 0f));
    }

    void AlignPlayer()
    {
        if(characterController.velocity.magnitude > 0f) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vectorMovement), rotationSpeed * Time.deltaTime);
        }
    }
}
