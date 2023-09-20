using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text resourceText;

    private float currentResources;

    // Start is called before the first frame update
    void Start()
    {
     //Inicializar variables
     currentResources = 0;
     UpdateUI();
    }

    //Agregar recursos
    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }
    //Quitar recursos
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();
    }

    //Devolver los recursos actuales
    public float CurrentResources()
    {
        return currentResources;
    }

    //Actualizar UI
    public void UpdateUI()
    {
        resourceText.text = "Pezetas: $" + currentResources;
    }
}
