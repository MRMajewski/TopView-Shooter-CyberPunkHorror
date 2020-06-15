using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstGun : MonoBehaviour
{

    [SerializeField]
    Sprite spriteWithGun;

    [SerializeField]
    Image AmmoImage;

    [SerializeField]
    Text AmmoCounter;


    // Start is called before the first frame update
    void Start()
    {
        AmmoImage.enabled = false;
        AmmoCounter.enabled = false;

        var activator = GetComponent<ActivatorPC>();
        activator.OnActivated += () =>
        {
            Destroy(gameObject);

            var player = FindObjectOfType<PlayerPC>();
            player.GetComponent<SpriteRenderer>().sprite = spriteWithGun;

            player.GetComponent<PlayerShooting>().enabled = true;

            AmmoImage.enabled = true;
            AmmoCounter.enabled = true;

        };
    }

}
