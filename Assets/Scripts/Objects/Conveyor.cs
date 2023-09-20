using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed;

    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Resource") )
        {
            Transform colliderObject = collision.gameObject.transform;
            colliderObject.position = new Vector3(colliderObject.position.x + movementVector.x * Time.deltaTime, 
                                                  colliderObject.position.y + movementVector.y * Time.deltaTime,
                                                  colliderObject.position.z + movementVector.z * Time.deltaTime);
        }
    }
}
