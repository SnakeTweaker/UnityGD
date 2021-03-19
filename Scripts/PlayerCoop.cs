using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoop : MonoBehaviour
{
    public static PlayerCoop instance;
    public float moveSpeed;
    private Vector2 moveInput;

    public Rigidbody2D RB;

    //public Transform playerAim;

    //private Camera theCam;

    public Animator anim;

    public GameObject bulletToFire;
    public Transform firePoint;

    public float timeBetweenShots;
    private float shotCounter;




    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        //theCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {


        moveInput.Normalize();

        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0f);

        RB.velocity = moveInput * moveSpeed;

        /*Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = theCam.WorldToScreenPoint(transform.localPosition);*/



        /*determines if the mouse is to the left of the player, also Vector3.one is a shortcut for inputting 1f,1f,1f these are floats
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            playerAim.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            playerAim.localScale = Vector3.one;
        }*/

        //rotate gun arm
        /*Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        playerAim.rotation = Quaternion.Euler(0, 0, angle);*/



        //Movement and control scheme block.... Left mouse = 0 right = 1, middle = 2
        if (Input.GetKey(KeyCode.Keypad5))
        {
            Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
            shotCounter = timeBetweenShots;
        }

        if (Input.GetKey(KeyCode.Keypad5))
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                Instantiate(bulletToFire, firePoint.position, firePoint.rotation);

                shotCounter = timeBetweenShots;
            }
        }
        if (Input.GetKey(KeyCode.Keypad4))
         {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad8))
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }

        //movement animation block
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

    }
}





