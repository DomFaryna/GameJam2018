using System;
using System.Collections.Generic;
using System.ComponentModel;
using Fish.Types;
using UnityEditor;
using UnityEngine;

namespace Fish
{
	public abstract class Fish : PlayerControls
	{
		public Collider2D mouth;
        public Collider2D body;
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

		void OnTriggerEnter2D(Collider2D other)
		{
			if (mouth != null && mouth.IsTouching(other) && this.GetType() == typeof(Shark))
			{
				Debug.Log("NOM NOM NOM");
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (mouth != null && mouth.IsTouching(other) && this.GetType() == typeof(Shark))
			{
				Debug.Log("NOM NOM NOM");
			}
		}

		// Update is called once per frame
		new void Update ()
		{
			Vector2 currentVector = gameObject.GetComponent<Transform>().position;
			switch (cond)
			{
                case Condition.Player:
                    playerControl(stats);
                    break;

                case Condition.Passive:
					targetVector = player.GetComponent<Transform>().position;
                    AI_Movement(targetVector, currentVector);
					break;
				
				case Condition.Agressive:
					targetVector = findTarget();
                    AI_Movement(targetVector, currentVector);
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
        protected void AI_Movement(Vector2 targetVector, Vector2 currentVector)
        {
            Debug.Log(targetVector.x);
            
            Vector2 movementVector;

            Vector2 distanceToTarget = targetVector - currentVector;
            movementVector = calulateMovement(targetVector, currentVector);

            gameObject.GetComponent<Rigidbody2D>().AddForce(movementVector * stats.Speed);

            if (movementVector.x > 0 && distanceToTarget.x > 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (movementVector.x < 0 && distanceToTarget.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }



            }

        protected virtual Vector2 calulateMovement(Vector2 target, Vector2 current)
		{
			Vector2 returnVector = target - current;
			return returnVector.normalized;
		}

        protected virtual Vector2 calculateDistanceToTarget(Vector2 target, Vector2 current)
        {
            Vector2 returnVector = target - current;
            return returnVector.normalized;
        }

        protected abstract void ability();
	}
}
