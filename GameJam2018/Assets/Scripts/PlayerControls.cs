using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    protected virtual void ability() { }
    private Rigidbody2D rb2d;
    protected virtual void attack() { }

    protected float speed = 500;
    protected void playerControl(Stats stats) {
        speed = stats.Speed;
        
    }
    

    protected void Start(){
        rb2d = GetComponent<Rigidbody2D>();

    }

    protected void Update(){
        
    }

    protected void FixedUpdate()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "Player")
        {
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if ((transform.position.x < -64 && moveHorizontal < 0) || (transform.position.x > 64 && moveHorizontal > 0))
            {
                moveHorizontal = 0f;
            }
            if ((transform.position.y < -38 && moveVertical < 0) || (transform.position.y > 20 && moveVertical > 0))
            {
                moveVertical = 0f;
            }
            int xRotation = 0;
            int zRotation = 0;
            if (moveHorizontal < 0)
            {
                xRotation = 180;
            }

            if (moveVertical < 0 && moveHorizontal == 0)
            {
                zRotation = 270;
            }
            else if (moveVertical > 0 && moveHorizontal == 0)
            {
                zRotation = 90;
            }
            else if (moveVertical > 0 && moveHorizontal > 0)
            {
                zRotation = 45;
            }
            else if (moveVertical > 0 && moveHorizontal < 0)
            {
                xRotation = 180;
                zRotation = 45;
            }
            else if (moveVertical < 0 && moveHorizontal < 0)
            {
                xRotation = 180;
                zRotation = 315;
            }
            else if (moveVertical < 0 && moveHorizontal > 0)
            {
                zRotation = 315;
            }

            transform.localRotation = Quaternion.Euler(0, xRotation, zRotation);
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb2d.AddForce(movement * speed);
        }

    }     
}
