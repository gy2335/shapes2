using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pb : MonoBehaviour
{
    [SerializeField] private float speed;
    private RigidBody2D body;
    private bool grounded;
    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<RigidBody2d>();
    }


    // Update is called once per frame
    void Update()
    {body.velocity = new Vector2(body.velocity.x, speed);
    
    if( Input.GetKey(KeyCode.Space) && grounded == true ) {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    if( body.velocity.y == 0) {
        grounded = true;
    }
    }    
    }

