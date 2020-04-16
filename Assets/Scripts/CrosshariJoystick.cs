using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshariJoystick : MonoBehaviour
{


    [SerializeField]
    float MaxPositionX = 5f;

    [SerializeField]
    float MaxPositionY = 5f;

    [SerializeField]
    Joystick joystick;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var AimDirection = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        transform.Translate(AimDirection * Time.deltaTime * 4f, Space.World);

        var positionX = Mathf.Clamp(transform.position.x, -MaxPositionX, MaxPositionX);
        var positionY = Mathf.Clamp(transform.position.y, -MaxPositionY, MaxPositionY);

        transform.position = new Vector3(positionX, positionY);

        var targetRotation = AimDirection;

        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 5f);

    }
}
