using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivatorChecker : MonoBehaviour
{

    bool Active=false;
    // public event Action OnActivated;

    // Start is called before the first frame update
     private Collider2D UseableObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Use()
    {
        
        if (!Active) return;
        UseableObject.gameObject.GetComponent<Activator>().Use();
    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CheckIfActivator(collision)) return;
        Active = true;
        UseableObject = collision;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CheckIfActivator(collision)) return;
        Active = false;
        UseableObject = null;
       
    }

    bool CheckIfActivator(Collider2D collider)
    {
        return (collider.gameObject.GetComponent<Activator>() != null);
    }
}
