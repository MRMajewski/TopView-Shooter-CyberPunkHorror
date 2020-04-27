using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Entity))]

public class ExplosiveObject : MonoBehaviour
{
    [SerializeField]
    float ExplosionRadius = 4f;

    [SerializeField]
    float ExplosionDamage = 15f;

    [SerializeField]
    GameObject ExplosionEffect;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Entity>().OnKilled += () => Explode();
    }

    // Update is called once per frame
    void Explode()
    {
        EntityDoDamage();
        Instantiate(ExplosionEffect, transform.position,Quaternion.Euler(0,90f,90f));
        Destroy(gameObject,2f);
    }

    void EntityDoDamage()
    {
        Physics2D.OverlapCircleAll(transform.position, ExplosionRadius)
            .Select(obj => obj.GetComponent<Entity>())
            .Where(obj => obj != null)
            .Where(obj => obj.transform.name != transform.name)
            .ToList()
            .ForEach(obj => obj.Health -= ExplosionDamage);

    }


}
