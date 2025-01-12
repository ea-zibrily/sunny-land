using UnityEngine;

namespace Sunny.NPCs
{
    public class TaskIdle : Node
    {
        private readonly DinoController dino;

        public TaskIdle(DinoController controller)
        {
            dino = controller;
        }
        
        public override NodeState Evaluate()
        {
            // if (dino.DinoState != DinoState.Idle)
            // {
            //     currentState = NodeState.Failure;
            //     return currentState;
            // }
            
            Debug.Log("run idle node!");
            state = NodeState.RUNNING;
            return state;
        }
    }
}