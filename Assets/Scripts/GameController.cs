using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject BlackMask;

    [SerializeField]
    GameObject BehindMask;

    [SerializeField]
    GameObject MainMenu;

    [SerializeField]
    GameObject HUD;




    // Start is called before the first frame update
    void Start()
    {
        HUD.SetActive(false);

        MainMenu.SetActive(true);

        Time.timeScale = 0f;

        BlackMask.SetActive(true);

        MoveToLayer(BehindMask.transform, 11);
        // BehindMask.layer = 0;


    }

    // Update is called once per frame
    void Update()
    {

    }


    void MoveToLayer(Transform root, int layer)
    {
        root.gameObject.layer = layer;
        foreach (Transform child in root)
            MoveToLayer(child, layer);
    }

    public void startGame()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1f;
        HUD.SetActive(true);
    }

}
