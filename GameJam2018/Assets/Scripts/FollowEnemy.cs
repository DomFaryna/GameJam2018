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
		gameObject.GetComponent<Rigidbody2D>().AddForce(movementVector * 10);
	}

	Vector2 calulateMovement(Vector2 target, Vector2 current)
	{
		int x = 0;
		int y = 0;
		if (Math.Abs(target.x - current.x) > 2)
		{
			x = (target.x - current.x > 0) ? 1 : -1;
		}
		if (Math.Abs(target.y - current.y) > 2)
		{
			y = (target.y - current.y > 0) ? 1 : -1;
		}
		
		return new Vector3(x, y);
	}
}
