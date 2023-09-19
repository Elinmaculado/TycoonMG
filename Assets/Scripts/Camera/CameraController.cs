using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variables publicas
    public float sensitibity;
    public Transform cameraJointY, targetObject;
    public bool camRotate;
    
    //variables privadas
    private float xRotation, yRotation;
    // Start is called before the first frame update
    void Start()
    {
        camRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (camRotate)
        Rotate();
         
        followTarget();
    }

    //rotacion de camara
    void Rotate()
    {
        //se consiguen los inputs del mouse
        xRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensitibity;
        yRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * sensitibity;

        //limitacion al eje y
        yRotation = Mathf.Clamp(yRotation, -65, 65);

        //rotamos los componentes X y Y
        transform.localRotation = Quaternion.Euler(0, xRotation, 0);
        cameraJointY.transform.localRotation = Quaternion.Euler(-yRotation, 0, 0);
    }

    //sigue al objetivo
    void followTarget()
    {
        transform.position = targetObject.position;
    }
}
