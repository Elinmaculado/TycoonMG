using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBooster : MonoBehaviour
{
    public float multiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Resources>() != null)
        {
            other.gameObject.GetComponent<Resources>().value *= multiplier;
        }
    }
}
