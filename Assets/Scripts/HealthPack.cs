using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    [SerializeField]
    int HealthAmount = 5;

    // Start is called before the first frame update
    void Start()
    {
        var activator = GetComponent<ActivatorPC>();

        activator.OnActivated += () =>
        {
            var player = FindObjectOfType<PlayerPC>();
            player.GetComponent<Entity>().Health +=HealthAmount;
            Destroy(gameObject);
        };
    }

}
