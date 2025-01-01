using UnityEngine;

namespace Sunny.Player
{
    public class FoxyController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector2 playerDirection;
        [SerializeField] private bool isRight;

        private Rigidbody2D _playerRb;
        private SpriteRenderer _playerSr;
        private Animator _playerAnim;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            _playerSr = GetComponentInChildren<SpriteRenderer>();
            _playerAnim = GetComponentInChildren<Animator>();
        }

        private void FixedUpdate()
        {
            PlayerMove();
        }

        private void Update()
        {
            PlayerDirection();
            HandleAnimation();
        }

        private void PlayerMove()
        {
            var horizontal = Input.GetAxisRaw("Horizontal");

            playerDirection = new Vector2(horizontal, playerDirection.y);
            playerDirection.Normalize();
            _playerRb.velocity = playerDirection * moveSpeed;
        }

        private void PlayerDirection()
        {
            var direction = playerDirection.x;
            if (direction > 0 && !isRight)
            {
                PlayerFlip();
            }
            else if (direction < 0 && isRight)
            {
                PlayerFlip();
            }
        }

        private void PlayerFlip()
        {
            isRight = !isRight;
            _playerSr.flipX = !_playerSr.flipX;
        }

        private void HandleAnimation()
        {
            var isRun = playerDirection.x != 0;
            _playerAnim.SetBool("IsRun", isRun);
        }
    }
}