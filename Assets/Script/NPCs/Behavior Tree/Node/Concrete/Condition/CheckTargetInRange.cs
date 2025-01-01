using UnityEngine;

namespace Sunny.NPCs
{
    public class CheckTargetInRange : Node
    {
        // Neccesary
        private readonly float areaRadius;
        private readonly Transform dinoTransform;
        private readonly LayerMask targetLayer;
        
        public CheckTargetInRange(float radius, Transform transform, LayerMask layer)
        {
            areaRadius = radius;
            dinoTransform = transform;
            targetLayer = layer;
        }

        public override NodeState Evaluate()
        {
            object target = GetData("Fruit");
            if (target == null)
            {
                Collider2D collider = Physics2D.OverlapCircle(dinoTransform.position, areaRadius, targetLayer);
                if (collider)
                {
                    if (collider.CompareTag("Item"))
                    {
                        Debug.Log($"detect target {collider.transform.name}");
                        parent.parent.SetData("Fruit", collider.transform);
                        state = NodeState.SUCCESS;
                        return state;
                    }
                }
                
                state = NodeState.FAILURE;
                return state;
            }
            
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
