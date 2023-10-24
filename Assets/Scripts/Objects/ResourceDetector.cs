using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceDetector : MonoBehaviour
{
    // Start is called before the first frame update

    public ResourceManager resourceManager;

    //Si entra un objeto en el video
    private void OnTriggerEnter(Collider other)
    {
        //Si el objeto es un recurso
        if(other.gameObject.GetComponent<Resources>())
        {
            resourceManager.AddResources(other.gameObject.GetComponent<Resources>().value);
            Destroy(other.gameObject);
        }
    }
}
