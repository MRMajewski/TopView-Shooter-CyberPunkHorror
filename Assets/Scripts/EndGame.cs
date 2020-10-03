using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject EndGameUIWin;

    [SerializeField]
    GameObject EndGameUILose;

    private void Start()
    {
        EndGameUIWin.SetActive(false);
        EndGameUILose.SetActive(false);
        var player = FindObjectOfType<PlayerPC>();
        var camera = FindObjectOfType<MainCameraPC>();

        player.GetComponent<Entity>().OnKilled += () => EndGameProcedureLose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerPC>() != null)
            EndGameProcedureWin();


    }

    public void EndGameProcedureLose()
    {

        Time.timeScale = 3f;
        EndGameUILose.SetActive(true);
    }


     void EndGameProcedureWin()
    {

        Time.timeScale = 0.5f;
        EndGameUIWin.SetActive(true);
    }
}
