using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;


namespace Fish
{
    public class Basic :Fish
    {
        protected new void Start()
        {
            stats = new Stats(100f, 10, 10, 10, 10, 10);
            cond = Condition.Agressive;
            base.Start();
        }


        protected override Vector2 findTarget()
        {
            Vector2 difference = targetVector - (Vector2)gameObject.GetComponent<Transform>().position;
            Debug.Log(targetVector + "-" + gameObject.GetComponent<Transform>().position);
            Debug.Log("Difference!!!!" + difference.ToString());
            if (difference.magnitude < 5)
            {
                Random ran = new Random();
                Vector2 he = new Vector2(ran.Next(-75, 75), ran.Next(-25, 25));
                Debug.Log(he);
                return he;
            }
            Debug.Log(difference);
            return targetVector;
        }

        protected override void ability()
        {
            
        }
    }
}