
namespace Sunny.NPCs
{
    public class CheckCanMove : Node
    {
        private DinoBT guardBT;
        public CheckCanMove(DinoBT guard)
        {
            guardBT = guard;
        }
        public override NodeState Evaluate()
        {
            if (guardBT.CanMove)
            {
                state = NodeState.SUCCESS;
                return state;
            }

            state = NodeState.FAILURE;
            return state;
        }
    }
}

