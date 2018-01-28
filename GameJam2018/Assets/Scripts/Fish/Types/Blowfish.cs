using JetBrains.Annotations;
using UnityEngine;

namespace Fish.Types
{
    public class Blowfish : Fish
    {
        protected new void Start()
        {
            stats = new Stats(100f, 10, 10, 10, 10, 10);
            cond = Condition.Agressive;
            base.Start();
        }

        protected override Vector2 findTarget()
        {
            return targetVector;
        }
        
        protected override void ability()
        {
            throw new System.NotImplementedException();
        }
    }
}