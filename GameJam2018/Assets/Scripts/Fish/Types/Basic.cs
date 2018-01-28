using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;


namespace Fish.Types
{
    public class Basic :Fish
    {
        protected new void Start()
        {
            stats = new Stats(200f, 10, 10, 10, 10, 10);
            if (gameObject.tag == "Player")
            {
                cond = Condition.Player;
            }
            else
            {
                cond = Condition.Passive;
            }
            
            base.Start();
        }


        protected override Vector2 findTarget()
        {
            Vector2 difference = targetVector - (Vector2)gameObject.GetComponent<Transform>().position;
            if (difference.magnitude < 5)
            {
                Random ran = new Random();
                Vector2 he = new Vector2(ran.Next(-75, 75), ran.Next(-25, 25));
                return he;
            }
            return targetVector;
        }

        protected override void ability()
        {
            
        }
    }
}