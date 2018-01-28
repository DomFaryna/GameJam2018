using NUnit.Framework.Constraints;
using UnityEngine;

namespace Fish
{
    public class Shark : Fish
    {
        new void Start()
        {
            stats = new Stats(100f, 10, 10, 10, 10, 10);
            base.Start();
        }

        protected override Vector2 findTarget()
        {
            return player.GetComponent<Transform>().position;
        }

        protected override Vector2 calulateMovement(Vector2 target, Vector2 current)
        {
            Vector2 returnVector = target - current;
            return returnVector.normalized;
        }

        protected override void ability()
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (findTarget() * 2);
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
        }
    }
}