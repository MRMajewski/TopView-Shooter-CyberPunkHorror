﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [SerializeField]
    Vector3 offset;



    Rigidbody2D Player;
    UnityEngine.Camera MyCamera;


    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
        MyCamera = FindObjectOfType<UnityEngine.Camera>();
    }

    // Update is called once per frame
    void FixedUpdate() //ponieważ aktualizujemy względem obiektu fizycznego
    {
        UpdatePosition();
        UpdateFOV();
    }

    void UpdatePosition()
    {
        //var targetPosition =
        //    (Vector3)Player.position
        //    + (Vector3)offset
        //    - Player.velocity.magnitude * (Vector3)offset * Player.rotation
        //    + Vector3.back * 9f;

        var targetPosition =
              (Vector3)Player.position
              + (Vector3)Player.velocity * 3f
              + Vector3.back * 4f;

        transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                Time.deltaTime * 1f);
    }

    void UpdateFOV()
    {
        var speed = Player.velocity.magnitude;

        // obszar jaki obejmuje kamera
        var targetViewSize = .05f + (speed / 4f);

        MyCamera.orthographicSize = Mathf.Lerp(
            MyCamera.orthographicSize,
            targetViewSize,
            Time.deltaTime);
    }

}
