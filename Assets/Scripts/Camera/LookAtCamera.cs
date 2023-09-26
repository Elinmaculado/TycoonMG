using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //Conseguir transform de la camara
        mainCamera = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera);
    }
}
