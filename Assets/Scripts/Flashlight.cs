using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var activator = GetComponent<ActivatorPC>();
        activator.OnActivated += () =>
        {
       
           
            var fieldOfView = FindObjectOfType<FieldOfView>();
            fieldOfView.GetComponent<FieldOfView>().enabled = true;         
            Destroy(gameObject);
        };
    }

}
  

