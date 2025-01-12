using UnityEngine;
using Sunny.Data;

namespace Sunny.NPCs
{
    public class TaskMove : Node
    {
        // Neccesary
        private readonly DinoController dino;
        private readonly DinoData data;

        private readonly float moveDelay = 2f;
        private float _currentTime;
        private Transform _moveTarget;
        private Vector3 _targetPosition;

        public TaskMove(DinoController controller, Transform target = null)
        {
            // Set main fields
            dino = controller;
            data = dino.Data;
            _moveTarget = target;

            // Other
            moveDelay = 2f;
            if (target != null)
            {
                _targetPosition = new Vector2(_moveTarget.position.x, dino.transform.position.y);
            }
        }
        
        public override NodeState Evaluate()
        {
            if (_moveTarget == null)
            {
                Transform item = (Transform)GetData("Fruit");
                if (item != null)
                {
                    _moveTarget = item;
                    _targetPosition = new Vector2(_moveTarget.position.x, dino.transform.position.y);
                }
            }

            _currentTime += Time.deltaTime;
            if (_currentTime >= moveDelay)
            {
                Debug.Log($"move at {_targetPosition}");
                var direction = (_targetPosition - dino.transform.position).normalized;

                dino.LookAt(direction);
                dino.ChangeState(DinoState.Walk);
                dino.transform.position = Vector2.MoveTowards(dino.transform.position, 
                    _targetPosition, data.MoveSpeed * Time.deltaTime);
            }
            
            state = NodeState.RUNNING;
            return state;
        }
    }
}
