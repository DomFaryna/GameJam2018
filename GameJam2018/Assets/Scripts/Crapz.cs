using System;
using NUnit.Framework.Constraints;
using UnityEngine;

    public class Crapz : Test
    {
        public new void Start()
        {
            Debug.Log("Started child");
        }

        public new void Update()
        {
            base.Update();
        }

        public override void crap()
        {
            Debug.Log("This is crap");
        }
        
    }