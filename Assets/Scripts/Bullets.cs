using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActivatorPC))]

public class Bullets : MonoBehaviour
{
    public int Amount = 10;

    // Start is called before the first frame update
    void Start()
    {
        var activator = GetComponent<ActivatorPC>();
        activator.OnActivated += () =>
        {
            var player = FindObjectOfType<PlayerShooting>();
            player.CollectBullets(10);
            Destroy(gameObject);
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
