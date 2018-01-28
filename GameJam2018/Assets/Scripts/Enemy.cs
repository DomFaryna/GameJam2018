using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private GameObject entity;

	// Use this for initialization
	void Start ()
	{
		entity = gameObject;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			gameObject.GetComponent<Transform>().Translate(Vector3.up);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			gameObject.GetComponent<Transform>().Translate(Vector3.down);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			gameObject.GetComponent<Transform>().Translate(Vector3.left);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			gameObject.GetComponent<Transform>().Translate(Vector3.right);
		}
		else if(!gameObject.GetComponent<Renderer>().isVisible)
		{
			gameObject.GetComponent<Transform>().position = new Vector3(0,0);
		}
	}
}
