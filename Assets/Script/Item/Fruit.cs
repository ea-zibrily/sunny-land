using UnityEngine;

namespace Sunny.Item
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private string fruitName;
        public string FruitName => fruitName;
    }
}
