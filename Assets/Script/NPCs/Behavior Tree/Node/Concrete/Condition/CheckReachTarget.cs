using Sunny.NPCs;
using UnityEngine;

namespace Sunny
{
    public class CheckReachTarget : Node
    {
        // Neccesary
        private readonly DinoController dino;
        private readonly bool isOriginTarget;

        private Transform moveTarget;

        public CheckReachTarget(DinoController controller, Transform target = null, bool isOrigin = false)
        {
            dino = controller;
            moveTarget = target;
            isOriginTarget = isOrigin;
        }
        
        public override NodeState Evaluate()
        {
            if (moveTarget == null)
            {
                Transform item = (Transform)GetData("Fruit");
                if (item == null)
                {
                    state = NodeState.FAILURE;
                    return state;
                }
                moveTarget = item;
            }
            
            var targetPos = new Vector2(moveTarget.position.x, dino.transform.position.y);
            if (Vector2.Distance(dino.transform.position, targetPos) <= 0.1f)
            {
                var direction = isOriginTarget 
                    ? dino.InitialDirection : Vector2.zero;

                Debug.Log($"check reach {moveTarget.name}");
                dino.LookAt(direction);
                dino.ChangeState(DinoState.Idle);
                state = NodeState.SUCCESS;
                return state;
            }
            
            Debug.Log($"failure reach {moveTarget.name}");
            state = NodeState.FAILURE;
            return state;
        }
    }
}
