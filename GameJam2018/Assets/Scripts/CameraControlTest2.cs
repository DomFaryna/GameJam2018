using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraControlTest2 : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    public Transform playerToFollow;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Use this for initialization
    void Start()
    {
        List<GameObject> allPlayerTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (allPlayerTags[0] != null)
        {
            player = allPlayerTags[0];
        }
        playerToFollow = player.transform;

        minX = -55;
        maxX = 55;

        minY = -30;
        maxY = 13;
        
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {
        if (playerToFollow.position.x > minX && playerToFollow.position.x < maxX &&
            playerToFollow.position.y > minY && playerToFollow.position.y < maxY)
        {
            transform.position = new Vector3(playerToFollow.position.x, playerToFollow.position.y, -10);
        }
        else if (playerToFollow.position.x > minX && playerToFollow.position.x < maxX &&
            !(playerToFollow.position.y > minY && playerToFollow.position.y < maxY))
        {
            transform.position = new Vector3(playerToFollow.position.x, transform.position.y, -10);
        }
        else if (!(playerToFollow.position.x > minX && playerToFollow.position.x < maxX) &&
            (playerToFollow.position.y > minY && playerToFollow.position.y < maxY))
        {
            transform.position = new Vector3(transform.position.x, playerToFollow.position.y, -10);
        }

    }



}