using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text BulletsCounter;

    [SerializeField]
    Text HealthCounter;

    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<PlayerPC>().GetComponent<Entity>().OnHealthChanged += health =>
         {
             HealthCounter.text = health.ToString("N0"); //"NO" powoduje, że liczba zmiennoprzecinkowa jeset pokazywana jako int
         };

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
