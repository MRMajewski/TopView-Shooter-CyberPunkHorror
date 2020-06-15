using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLootBox : MonoBehaviour
{

    public int[] table = { 60, 30, 10 };
    public List<GameObject> packs;
    public int total;
    public int randomNumber;

    void Start()
    {
        GetComponent<ActivatorPC>().OnActivated += () =>
        {
            Generate();
            Destroy(gameObject);
        };



        void Generate()
        {
            foreach (var item in table)
            {
                total += item;
            }

            randomNumber = Random.Range(0, total);

            for (int i = 0; i < table.Length; i++)
            {
                if (randomNumber <= table[i])
                {
                    Destroy(gameObject);
                    Instantiate(packs[i],transform.position,transform.rotation);
                    return;
                }
                else
                {
                    randomNumber -= table[i];
                }
            }
        }
        
    }

}
