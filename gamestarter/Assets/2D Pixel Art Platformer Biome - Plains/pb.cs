using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pb : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = 6;
    }


    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);
    
    if( Input.GetKey(KeyCode.Space) && grounded == true ) {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

        


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}

