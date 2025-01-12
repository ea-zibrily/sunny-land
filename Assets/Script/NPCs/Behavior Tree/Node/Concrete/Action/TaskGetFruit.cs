using UnityEngine;
using Sunny.Item;

namespace Sunny.NPCs
{
    public class TaskGetFruit : Node
    {
        private readonly DinoController dino;
        
        public TaskGetFruit(DinoController controller)
        {
            dino = controller;
        }

        public override NodeState Evaluate()
        {
            Transform item = (Transform)GetData("Fruit");
            
            if (item != null)
            {
                if (item.TryGetComponent<Fruit>(out var fruit))
                {
                    Debug.Log($"run get {fruit.FruitName} node");
                    ClearData("Fruit"); 
                    MonoBehaviour.Destroy(fruit.gameObject);
                }
            }

            state = NodeState.RUNNING;
            return state;   
        }
    }
}
