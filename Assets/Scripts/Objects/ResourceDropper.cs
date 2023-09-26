using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceDropper : MonoBehaviour
{
    public GameObject[] resources;
    public float spawnTime;

    private int dropperTier;


    // Start is called before the first frame update
    void Start()
    {
        dropperTier = 1;
        InvokeRepeating("DropResource", spawnTime, 1f);

    }

    void DropResource()
    {
        if (resources[dropperTier-1] != null || dropperTier <= resources.Length) { }
        Instantiate(resources[dropperTier -1], transform.position, Quaternion.identity);

    }

    public void UpdateDropper()
    {
        dropperTier++;
    }



}
