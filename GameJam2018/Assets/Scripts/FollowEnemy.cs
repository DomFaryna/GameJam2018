using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowEnemy : MonoBehaviour
{
	public Vector3 targetVector;
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
		Vector3 currentVector = gameObject.GetComponent<Transform>().position;

		Vector3 movementVector = calulateMovement(targetVector, currentVector).normalized;
		gameObject.transform.Translate(movementVector);
	}

	Vector3 calulateMovement(Vector3 target, Vector3 current)
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
