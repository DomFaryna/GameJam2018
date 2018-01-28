using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowEnemy : MonoBehaviour
{
	public Vector2 targetVector;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		List<GameObject> allPlayerTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
		if (allPlayerTags[0] != null)
		{
			player = allPlayerTags[0];
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		targetVector = player.GetComponent<Transform>().position;
		Vector2 currentVector = gameObject.GetComponent<Transform>().position;

		Vector2 movementVector = calulateMovement(targetVector, currentVector).normalized;
        
		gameObject.GetComponent<Transform>().Translate(movementVector);
	}

	Vector2 calulateMovement(Vector2 target, Vector2 current)
	{
        Vector2 returnVector = target - current;

        return returnVector;
	}
}
