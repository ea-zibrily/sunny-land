using UnityEngine;

namespace Sunny.Data
{
    [CreateAssetMenu(fileName = "NewDinoData", menuName = "Data/DinoData", order = 0)]
    public class DinoData : ScriptableObject
    {
        [Header("Stats")]
        [SerializeField] private string dinoName;
        [SerializeField] private float moveSpeed;

        // Getter
        public string DinoName => dinoName;
        public float MoveSpeed => moveSpeed;
    }
}
