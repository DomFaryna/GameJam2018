using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour {

    public Vector2 targetVector;
    private GameObject player;
    public float speed;
    // Use this for initialization
    void Start()
    {
        List<GameObject> allPlayerTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (allPlayerTags[0] != null)
        {
            player = allPlayerTags[0];
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetVector = player.GetComponent<Transform>().position;
        Vector2 currentVector = gameObject.GetComponent<Transform>().position;
        Vector2 movementVector = targetVector - currentVector;
        Debug.Log(movementVector.magnitude);

        if(movementVector.magnitude > 1.8) {
            movementVector = movementVector.normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(movementVector * speed);
        }
        
        
    }
}
