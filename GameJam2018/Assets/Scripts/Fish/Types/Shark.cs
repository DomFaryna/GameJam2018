using UnityEngine;
using Random = System.Random;
namespace Fish.Types
{
    public class Shark : Fish
    {

        private Vector2 currentMouth;
        new void Start()
        {
            stats = new Stats(50f, 10, 10, 10, 10, 10);
            cond = Condition.Agressive;
            base.Start();
            
        }

        /*protected override Vector2 findTarget()
        {
            return player.GetComponent<Transform>().position;
        }*/

        protected override Vector2 findTarget()
        {
            currentMouth.y = transform.position.y - 1.5f;
            if (transform.localRotation.eulerAngles.y == 0)
            {
                currentMouth.x = transform.position.x - 7.5f;

            }
            else
            {
                currentMouth.x = transform.position.x + 7.5f;
            }

            Vector2 PlayerTarget = player.GetComponent<Transform>().position;
            Vector2 targetDifference = PlayerTarget - currentMouth;
            if (targetDifference.magnitude > 20)
            {
                Vector2 difference = targetVector - currentMouth;
                if (difference.magnitude < 5)
                {
                    Random ran = new Random();
                    Vector2 he = new Vector2(ran.Next(-60, 60), ran.Next(-34, 23));
                    return he;
                }
                return targetVector;
            }

            return PlayerTarget;
        }

        protected override Vector2 calulateMovement(Vector2 target, Vector2 current)
        {
            currentMouth.y = transform.position.y - 1.5f;
            if (transform.localRotation.eulerAngles.y == 0)
            {
                currentMouth.x = transform.position.x - 7.5f;
                
            } else
            {
                currentMouth.x = transform.position.x + 7.5f;
            }
            
            Vector2 returnVector = target - currentMouth;
            return returnVector.normalized;
            
        }


        protected override void ability()
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = (findTarget() * 2);
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
        }

        protected override void attack()
        {
            base.attack();
        }
    }
}