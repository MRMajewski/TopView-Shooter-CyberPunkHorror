using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




[RequireComponent(typeof(Collider2D))]
public class Activator : MonoBehaviour
{

   // [SerializeField]
  //  Button useButton;

    [SerializeField]
    bool AutoInteract = false;

    public bool Active
    {
        get;
        private set;
    }

    public event Action OnActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        UpdateColor();
        UpdateInteraction();
    }

    // Update is called once per frame
    void UpdateColor()
    {
       Color targetColor = Color.white;

        if (Active)
            //   targetColor *= (Mathf.Sin(Time.timeSinceLevelLoad *5f ) + 9f) / 10f;
            targetColor *= (Mathf.Sin(Time.timeSinceLevelLoad * 8f) +10f ) / 10f;

        GetComponent<Renderer>().material.color = targetColor;
    }

    void UpdateInteraction()
    {

    
     //   Debug.Log("dupa");


        //if (Input.GetKeyDown(KeyCode.Space) || AutoInteract)
        //    if (OnActivated != null)
        //        OnActivated.Invoke();
    }


    public void Use()
    {
        if (!Active) return;
        if (OnActivated != null) OnActivated.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CheckIfPlayer(collision)) return;
        Active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CheckIfPlayer(collision)) return;
            Active = false;
    }

    bool CheckIfPlayer(Collider2D collider)
    {
        return (collider.gameObject.GetComponent<Player>() != null);
    }
}
