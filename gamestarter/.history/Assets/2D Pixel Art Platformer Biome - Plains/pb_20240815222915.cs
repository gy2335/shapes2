using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pb : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 6;
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            grounded = false;
            anim.SetBool("In Air", !grounded);

        }
        else
        {
            anim.SetBool("Landing", true);
            anim.SetBool("In Air", false);
        }

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(8, 8, 1);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-8, 8, 1);
        }



        //if (grounded == true) { 
        anim.SetBool("Running", horizontalInput != 0);
        //  anim.SetBool("Idle", horizontalInput == 0);
        anim.SetBool("Idle", grounded);
    //}
      
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        } else 
        if (collision.gameObject.tag == "Slime")
        {
            Manager.instance(Restart);
        }
    }

}

