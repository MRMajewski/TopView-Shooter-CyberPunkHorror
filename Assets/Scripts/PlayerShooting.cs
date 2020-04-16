using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    float BulletSpeed;

    [SerializeField]
    Vector2 ShootingPoint;

    private int bullets;
    public int Bullets
    {
        get
        {
            return bullets;
        }
        private set
        {
            bullets = value;
            if (OnBulletsChange != null)
                OnBulletsChange.Invoke(bullets);
        }
    }

    public event Action<int> OnBulletsChange;


    // Start is called before the first frame update
    void Start()
    {
        Bullets = 5;
    }

    // Update is called once per frame
    void Update()
    {
     //   if (Input.GetMouseButtonDown(0))
     //       ShootBullet();
        
    }

    public void ShootBullet()
    {
        if (Bullets == 0) return;

        Bullets--;

        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position + transform.rotation *(Vector3)ShootingPoint; //pozycja pocisku to pozycja gracza
        bullet.transform.rotation = transform.rotation;

        var rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.right * BulletSpeed;

    }

    public void CollectBullets(int amount)
    {
        if (amount < 0) amount = 0;
        Bullets += amount;

    }
}
