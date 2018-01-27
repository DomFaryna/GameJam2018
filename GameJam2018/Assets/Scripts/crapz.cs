using System;
using NUnit.Framework.Constraints;
using UnityEngine;

    public class Crapz : Test
    {
        new void Start()
        {
            Debug.Log("Started child");
        }

        new void Update()
        {
            base.crap();
        }

        new void crap()
        {
            Debug.Log("This is crap");
        }
        
        
        
    }