using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{


    [SerializeField]
    GameObject ZombiePrefab;

    [SerializeField]
    float AreaRadius = 3f;

    [SerializeField]
    float Duration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombieCoroutine());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, AreaRadius);
    }

    IEnumerator SpawnZombieCoroutine()
    {
        while(true)
        {
            SpawnZombie();
            yield return new WaitForSeconds(Duration);
           
        }
    }

    void SpawnZombie()
    {
        var position = (Vector2)transform.position + Random.insideUnitCircle * AreaRadius;

        var zombie =Instantiate(ZombiePrefab);
        zombie.transform.position = position;
    }
}
