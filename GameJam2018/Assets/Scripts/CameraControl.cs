using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraControl : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    private Vector3 correction;
    private Vector3 temp;
    private List<Collider2D> fuckThis = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fuckThis.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        fuckThis.Remove(collision);
    }

    // Use this for initialization
    void Start()
    {
        List<GameObject> allPlayerTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        if (allPlayerTags[0] != null)
        {
            player = allPlayerTags[0];
        }

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        correction = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        temp = player.transform.position;
        correction.x = 0;
        correction.y = 0;
        offset = transform.position - player.transform.position;
        Debug.Log("camera: " + transform.position.x + "," + transform.position.y);
        Debug.Log("player: " + player.transform.position.x + "," + player.transform.position.y);
        Debug.Log("offset: " + "(" + offset.x + "," + offset.y + "," + offset.z + ")");
        //Debug.Log(fuckThis.Count);
        if (fuckThis.Count == 0 ||
            (player.transform.position.x < 40 &&
            player.transform.position.x > -40 &&
            player.transform.position.y > -22 &&
            player.transform.position.y < 5.8))
        {
            // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
            transform.position = player.transform.position + correction;

        } else if (fuckThis.Count > 0)
        {
            if ((player.transform.position.x > 38 && offset.x > 0) ||
            (player.transform.position.x < -38 && offset.x < 0))
            {
                temp.x = transform.position.x;
            }

            if ((player.transform.position.y > -22 && offset.y > 0) ||
                (player.transform.position.y < 5.8 && offset.y < 0))
            {
                temp.y = transform.position.y;
            }

            transform.position = temp + correction;
        }
    }



}