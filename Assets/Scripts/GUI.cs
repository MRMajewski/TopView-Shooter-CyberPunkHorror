using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    [SerializeField]
    Text BulletsCounter;


    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<PlayerShooting>().OnBulletsChange += bullets =>
         {
             BulletsCounter.text = bullets.ToString();
         };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
