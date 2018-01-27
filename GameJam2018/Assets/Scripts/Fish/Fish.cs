using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fish
{
	public abstract class Fish : PlayerControls
	{
		public Vector2 targetVector;
		private GameObject player;
		protected Stats stats;
		private Condition cond = Condition.Passive;

			// Use this for initialization
			new void Start ()
		{
			List<GameObject> allPlayerTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
			if (allPlayerTags[0] != null)
			{
				player = allPlayerTags[0];
			}

		}
	
		// Update is called once per frame
		new void Update ()
		{
			switch (cond)
			{
				case Condition.Passive:
					targetVector = player.GetComponent<Transform>().position;
					Vector2 currentVector = gameObject.GetComponent<Transform>().position;

					Vector2 movementVector = calulateMovement(targetVector, currentVector).normalized;
					gameObject.GetComponent<Rigidbody2D>().AddForce(movementVector * 10);
					break;
				case Condition.Player:
					playerControl(stats);
					break;
				default:
					Debug.Log("Not implemented yet");
					break;
			}
			
		}

		protected abstract Vector2 calulateMovement(Vector2 target, Vector2 current);
	}
}
