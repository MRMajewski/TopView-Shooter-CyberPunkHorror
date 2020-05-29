using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Entity))]

public class PlayerPC : MonoBehaviour
{
    [SerializeField]
    FieldOfView FieldOfView;

    [SerializeField]
    float WalkingSpeed = 2f;

    [SerializeField]
    float RunningSpeed = 3.5f;

    Rigidbody2D Rigidbody;
    CrosshairPC Crosshair;

    private void Awake() // tu inicjalizujemy Rigidbody
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Crosshair = FindObjectOfType<CrosshairPC>();
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<Entity>().OnKilled += () => Application.Quit();
    }

    void Update()
    {
        UpdateMovement();
        UpdateRotation();

        FieldOfView.SetAimDirection(transform.right);
        FieldOfView.SetOrigin(transform.position);
    }

    void UpdateMovement()
    {
        var WalkingDirection = Vector3.zero; // kierunek chodzenia domyślnie

        WalkingDirection += Vector3.up * Input.GetAxis("Vertical"); // uniwersalne pobranie osi
        WalkingDirection += Vector3.right * Input.GetAxis("Horizontal");
        WalkingDirection = WalkingDirection.normalized;//normalized oznacza, że wektor ma zawsze tą sama długość 1
        WalkingDirection *= Input.GetKey(KeyCode.LeftShift) ? RunningSpeed : WalkingSpeed; //warunek jeśli shift jest wciśnięty

        Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, WalkingDirection, Time.deltaTime * 4f); // 'łagodzimy' poruszanie się
    }

    void UpdateRotation()
    {
        var delta = Crosshair.transform.position - transform.position; // różnica odlłegości między graczem a celownikiem
        var targetRotation = (Vector2)delta; //player patrzy się w kierunku kursora

        transform.right = Vector3.Lerp(transform.right, targetRotation, Time.deltaTime * 2f); // nadajemy płynniejszy obrót
    }
}
