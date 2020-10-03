using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Zombie : MonoBehaviour
{
    Rigidbody2D Rigidbody;

    Vector2 TargetPosition;

    PlayerPC TargetPlayer;

    [SerializeField]
    float WalkingSpeed=1f;

    [SerializeField]
    float AttackingDistance = 2f;

    [SerializeField]
    public float AttackingDamage = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeTargetPositionCoroutine());
    }

    IEnumerator ChangeTargetPositionCoroutine()
    {
        while(true)
        {
             TargetPosition = (Vector2)transform.position + Random.insideUnitCircle*10f;

           // TargetPosition = TargerPositionFirst;
            yield return new WaitForSeconds(Random.Range(5, 10));
         //   TargetPosition = TargerPositionSecond;
            //  yield return new WaitForSeconds(1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateAttack();
    }

    public void UpdateMovement()
    {
        var targetSpeed = WalkingSpeed;

        if (TargetPlayer != null)
        {
            TargetPosition = TargetPlayer.transform.position;
            targetSpeed *= 2f;
        }

        var direction = (Vector3)TargetPosition - transform.position;
        var targetVelocity = direction.normalized * targetSpeed;

        Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, targetVelocity, Time.deltaTime / 2f);

        transform.right = (Vector2)direction;
    }

    void UpdateAttack()
    {
        if (TargetPlayer == null) return;

        var distance = (TargetPlayer.transform.position - transform.position).magnitude;

        if (distance > AttackingDistance) return;

        TargetPlayer.GetComponent<Entity>().Health -= AttackingDamage * Time.deltaTime;

        StartCoroutine(UpdateColor(TargetPlayer));
    

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckIfPlayer(collision))
            TargetPlayer = collision.gameObject.GetComponent<PlayerPC>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(CheckIfPlayer(collision))
        TargetPlayer = null;
    }

    bool CheckIfPlayer(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerPC>();
        if (player == null)
            return false;
        else return true;
    }


    IEnumerator UpdateColor(PlayerPC TargetPlayer)
    {


        // TargetPlayer.GetComponent<SpriteRenderer>().material.color = Color.red;

         TargetPlayer.GetComponent<SpriteRenderer>().material.color = Color.Lerp(Color.red, Color.white, Time.deltaTime*5f);

        //Color targetColor = Color.red;

        //targetColor *= (Mathf.Sin(Time.timeSinceLevelLoad * 10f) ) / 10f;

        //TargetPlayer.GetComponent<Renderer>().material.color = targetColor;
        yield return new WaitForSeconds(2f);
        TargetPlayer.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
