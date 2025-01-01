using UnityEngine;
using Sunny.Data;

namespace Sunny.NPCs
{
    public class DinoController : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private DinoData dinoData;
        [SerializeField] private DinoState dinoState;
        [SerializeField] private Vector2 dinoDirection;
        [SerializeField] private bool isRight;

        public DinoData Data => dinoData;
        public DinoState DinoState => dinoState;
        public Vector2 DinoDirection => dinoDirection;
        public Vector2 InitialDirection { get; private set; }

        // References
        private SpriteRenderer _dinoSr;

        #region Unity Methods

        private void Awake()
        {
            _dinoSr = GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            dinoState = DinoState.Idle;
            InitialDirection = dinoDirection;
        }

        #endregion  
        
        #region Methods

        public void ChangeState(DinoState state)
        {
            if (state == dinoState) return;
            dinoState = state;
        }

        public void LookAt(Vector2 direction)
        {
            var directionX = dinoDirection.x;
            dinoDirection = direction;

            if (directionX > 0 && !isRight)
            {
                NPCFlip();
            }
            else if (directionX < 0 && isRight)
            {
                NPCFlip();
            }
        }
        
        private void NPCFlip()
        {
            isRight = !isRight;
            _dinoSr.flipX = !_dinoSr.flipX;
        }

        #endregion
    }
}
