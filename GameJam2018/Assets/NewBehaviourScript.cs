using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		Console.Out.WriteLine("Whatever");
		
	}
	
	// Update is called once per frame
	public void Update ()
	{
		int he = 2;
		Console.Out.WriteLine(++he);

	}
}
