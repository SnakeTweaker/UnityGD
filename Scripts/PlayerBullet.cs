using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D RB;

    public GameObject impactEffect;

    public GameObject splatEffect;

    public int damageToGive = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = transform.right * speed;
    }
    //when two trigger colliders overlap one of them is a trigger and this function will be called... other is the object
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);

            Instantiate(splatEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
       
        
    
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
