using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fish
{
	public abstract class Fish : PlayerControls
	{
		protected Vector2 targetVector;
		protected GameObject player;
		protected Stats stats;
		protected Condition cond = Condition.Passive;
		private bool isInfected;
		
		// Use this for initialization
		new protected void Start ()
		{
			List<GameObject> allPlayerTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
			if (allPlayerTags[0] != null)
			{
				player = allPlayerTags[0];
//				player.tag = "Fudge";
			}
		}

		protected virtual Vector2 findTarget()
		{
			return player.GetComponent<Transform>().position;
		}
	 
		// Update is called once per frame
		new void Update ()
		{
			Vector2 currentVector = gameObject.GetComponent<Transform>().position;
			Vector2 movementVector;
			switch (cond)
			{
				case Condition.Passive:
					targetVector = player.GetComponent<Transform>().position;
					movementVector = calulateMovement(targetVector, currentVector);
					gameObject.GetComponent<Rigidbody2D>().AddForce(movementVector * stats.Speed);
					break;
				case Condition.Player:
					playerControl(stats);
					break;
				case Condition.Agressive:
					targetVector = findTarget();
					movementVector = calulateMovement(targetVector, currentVector);
					gameObject.GetComponent<Rigidbody2D>().AddForce(movementVector * stats.Speed);
					break;
					
				default:
					Debug.Log("Not implemented yet");
					break;
			}

			if (Input.GetKey(KeyCode.Space))
			{
				ability();
			}

			if (Input.GetKey(KeyCode.Backspace))
			{
				gameObject.GetComponent<Transform>().position = new Vector2(0, 0);
				
			}
			
		}

		protected virtual Vector2 calulateMovement(Vector2 target, Vector2 current)
		{
			Vector2 returnVector = target - current;
			return returnVector.normalized;
		}
		protected abstract void ability();
	}
}
