using System.Collections.Generic;
using UnityEngine;

namespace Sunny.NPCs
{
    public class GuardBT : Trees
    {
        public bool CanMove;
        public Transform Target;

        public static float speed = 2f;
        public static float fovRange = 6f;
        public static float attackRange = 1f;

        protected override Node SetupTree()
        {
            Node root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    // new CheckCanMove(this),
                    new TaskGoToTarget(transform)
                }),
                new TaskIdles(),
            });

            return root;
        }
    }
}
