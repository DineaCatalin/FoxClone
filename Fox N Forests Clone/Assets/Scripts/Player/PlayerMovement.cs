using UnityEngine;

namespace fox
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string JUMP_ANIMATION_TRIGGER = "IsJumping";
        private const string FALL_ANIMATION_TRIGGER = "IsFalling";
        private const string JUMP_BUTTON = "Jump";
        private const string CROUCH_BUTTON = "Crouch";

        // TODO get this from config
        [SerializeField]
        private float movementSpeed = 40f;

        [SerializeField]
        private CharacterController _controller;

        [SerializeField]
        private Animator _animator;

        private float _horizontalMovement;

        private bool _jump;
        private bool _crouching;

        private void Start()
        {
            if (_controller == null)
            {
                _controller = GetComponent<CharacterController>();
            }

            if (_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
        }

        private void Update()
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
            _animator.SetFloat("Speed", Mathf.Abs(_horizontalMovement));

            if (Input.GetButtonDown(JUMP_BUTTON))
            {
                _jump = true;
            }

            if (Input.GetButtonDown(CROUCH_BUTTON))
            {
                _crouching = true;
            }
            else if (Input.GetButtonUp(CROUCH_BUTTON))
            {
                _crouching = false;
            }
        }

        private void FixedUpdate()
        {
            _controller.Move(_horizontalMovement * Time.fixedDeltaTime, _crouching, _jump);
            _jump = false;
        }

        public void OnStartFalling()
        {
            _animator.SetBool(JUMP_ANIMATION_TRIGGER, false);
            _animator.SetBool(FALL_ANIMATION_TRIGGER, true);
        }

        public void OnLanded()
        {
            _animator.SetBool(JUMP_ANIMATION_TRIGGER, false);
            _animator.SetBool(FALL_ANIMATION_TRIGGER, false);
        }

        public void OnJump()
        {
            _animator.SetBool(JUMP_ANIMATION_TRIGGER, true);
            _animator.SetBool(FALL_ANIMATION_TRIGGER, false);
        }
    }
}

