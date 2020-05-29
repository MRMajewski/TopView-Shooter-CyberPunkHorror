using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ActivatorPC))]
[RequireComponent(typeof(GenerateLoot))]


public class Box : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ActivatorPC>().OnActivated += () =>
        {
            GetComponent<GenerateLoot>().Generate();
            Destroy(gameObject);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
