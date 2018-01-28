using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    protected virtual void ability() { }

    protected virtual void attack() { }

    protected void playerControl(Stats stats) {

    }

    public float speed;
    private Rigidbody2D rb2d;

    protected void Start(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected void Update(){
        
    }

    protected void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }     
}
