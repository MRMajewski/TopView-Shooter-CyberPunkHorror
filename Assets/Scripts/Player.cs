using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    FieldOfView FieldOfView;

    [SerializeField]
    float WalkingSpeed = 3f;

    public Animator animator;


    [SerializeField]
    Joystick joystick;


    // [SerializeField]
    //  float MaxPositionX = 5f;

    //  [SerializeField]
    //  float MaxPositionY = 5f;

    Rigidbody2D rigidbody;

    CrosshariJoystick crosshair;

    private void Start()
    {

    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        crosshair = FindObjectOfType<CrosshariJoystick>();
       
    }
    // Update is called once per frame
    void Update()
    {
      //  Vector3 WalkingDirection = Vector3.zero;

      Vector3  WalkingDirection = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if((WalkingDirection != Vector3.zero))
            animator.SetBool("IsMoving", true);
        else animator.SetBool("IsMoving", false);



        UpdateMovement(WalkingDirection);
        UpdateRotation2();
        FieldOfView.SetAimDirection(transform.right);
        FieldOfView.SetOrigin(transform.position);


     //   UpdateRotation(WalkingDirection);
    }
    //var WalkingDirection = Vector3.zero;

    //WalkingDirection += Vector3.up * Input.GetAxis("Vertical");
    //WalkingDirection += Vector3.right * Input.GetAxis("Horizontal");

    //WalkingDirection = WalkingDirection.normalized * WalkingSpeed;

    //var rigidbody = GetComponent<Rigidbody2D>();
    //rigidbody.velocity = WalkingDirection;

    //transform.right = WalkingDirection;


    void UpdateMovement(Vector3 WalkingDirection)
    {


        //  WalkingDirection = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (WalkingDirection != Vector3.zero)
        {

            //    transform.Translate(WalkingDirection * Time.deltaTime * 4f, Space.World);

            // var positionX = Mathf.Clamp(transform.position.x, -MaxPositionX, MaxPositionX);
            //  var positionY = Mathf.Clamp(transform.position.y, -MaxPositionY, MaxPositionY);
            //funkcja Clamp zwraca daną wartość z  określonego przedziału
            //jeżeli ta wartość x zawiera się w przedziale to jest zwracana, w innym przypadku zwracana jest skrajna wartość

            //  transform.position = new Vector3(positionX, positionY);
            WalkingDirection *= WalkingSpeed;
            rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, WalkingDirection, Time.deltaTime * 1f);

          //  animator.SetBool("IsMoving", true);

            //     var targetRotation = rigidbody.velocity;

            //   transform.right = Vector3.Lerp(transform.right, WalkingDirection, Time.deltaTime * 5f);
        }
      //  else animator.SetBool("IsMoving", false);
    }

    void UpdateRotation(Vector3 WalkingDirection)
    {
         //var targetRotation = WalkingDirection;

        var delta = crosshair.transform.position - transform.position; // różnica odlłegości między graczem a celownikiem

        var targetRotation = (Vector2)delta; //player patrzy się w kierunku kursora
        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 9f); // nadajemy płynniejszy obrót
    }

    void UpdateRotation2()
    {

        //  transform.right = crosshair.AimDirection;
        transform.right = Vector3.Lerp(transform.right, crosshair.AimDirection, Time.deltaTime * 5f);
    }
}


