using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Rigidbody2D RB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;
    public Animator anim;
    public int health = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerCunt.instance.transform.position) < rangeToChasePlayer)
        {
            moveDirection = PlayerCunt.instance.transform.position - transform.position;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
        if (Vector3.Distance(transform.position, PlayerCoop.instance.transform.position) < rangeToChasePlayer)
        {
            moveDirection = PlayerCoop.instance.transform.position - transform.position;
        }
        else

            moveDirection.Normalize();

        RB.velocity = moveDirection * moveSpeed;

        //movement animation block
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
    public void DamageEnemy(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
            
            /*int selectedSplatter = Random.Range(0, deathSplatters.Length);

            int rotation = Random.Range(0, 4);

            Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, rotation * 90f));
            //Instantiate(deathSplatter, transform.position, transform.rotation);*/
        }
    }
}
