using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunny.NPCs
{
        public class TaskIdles : Node
    {
        public override NodeState Evaluate()
        {
            Debug.Log("run idle task!");
            state = NodeState.RUNNING;
            return state;
        }

    }

}
