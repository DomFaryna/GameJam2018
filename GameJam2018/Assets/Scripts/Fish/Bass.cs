using NUnit.Framework.Constraints;
using UnityEngine;

namespace Fish
{
    public class Bass : Fish
    {
        new void Start()
        {
            stats = new Stats(10, 10, 10, 10, 10, 10);
            
        }

        protected override Vector2 calulateMovement(Vector2 target, Vector2 current)
        {
            Vector2 returnVector = target - current;
            return returnVector.normalized;
        }
    }
}