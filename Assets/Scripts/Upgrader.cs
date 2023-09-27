using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{
    public ResourceManager resourceManager;
    public float cost;
    public string text;

    public UnityEvent EventoCanonico;

    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();

        textMesh.text = text + " $ " + cost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //si tenemos suficientes recursos
            if(resourceManager.CurrentResources() >= cost)
            {
                //quitamos el costo de la mejora activamos el evento y nos destruimos
                resourceManager.RemoveResources(cost);
                EventoCanonico.Invoke();
                Destroy(gameObject);
            }
        }
    }

}
