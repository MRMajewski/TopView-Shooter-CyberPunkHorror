using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class MainCameraPC : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;

    [SerializeField]

    Rigidbody2D Player;
    UnityEngine.Camera MyCamera;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerPC>().GetComponent<Rigidbody2D>();
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
              + (Vector3)Player.velocity * 2f
              + Vector3.back * 9f;

        transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                Time.deltaTime * 1f);
    }

    void UpdateFOV()
    {
        var speed = Player.velocity.magnitude;


        var targetViewSize = .6f + (speed / 2.5f);

        MyCamera.orthographicSize = Mathf.Lerp(
            MyCamera.orthographicSize,
            targetViewSize,
            Time.deltaTime*1.3f);

        //var targetViewSize = .6f + (speed / 2f);

        //MyCamera.orthographicSize = Mathf.Lerp(
        //    MyCamera.orthographicSize,
        //    targetViewSize,
        //    Time.deltaTime);
    }

}
