using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{

    [SerializeField]
    float Time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Time);
    }

}
