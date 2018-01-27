using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		
		Debug.Log("Started Base");
		
	}
	
	// Update is called once per frame
	public void Update ()
	{
		crap();
		this.crap();
	}

	public virtual void crap()
	{
		Debug.Log("Callled in base class");
	}
}
