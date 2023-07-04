using UnityEngine;
using UnityEngine.InputSystem;

public class InputComponent
{
    private Player _player;
    private bool _isJumping;
    private bool _isMoving;
    private bool _isJumpCanceled;
    private float _x;


    public InputComponent(Player player)
    {
        _player = player;
    }

    private void Move()
    {
        if (_isMoving)
        {
            _player.characterController.Move(new Vector3(_x * Time.deltaTime * _player.moveSpeed, 0, 0));
        }
    }

    private void Jump()
    {
        if (_player.characterController.isGrounded)
        {
            _isJumpCanceled = false;
        }

        if (_player.transform.position.y > _player.maxJumpHeight)
        {
            _isJumpCanceled = true;
        }
        if (_isJumping && _player.transform.position.y < _player.maxJumpHeight && !_isJumpCanceled)
        {
            _player.characterController.Move(new Vector3(0, 1 * Time.deltaTime * _player.jumpHeight, 0));
        }
    }

    public void HandleInput(InputAction.CallbackContext context)
    {
        var vector2 = context.ReadValue<Vector2>();
        var x = vector2.x;
        var y = vector2.y;
        _isJumping = y != 0;
        if (x != 0)
        {
            _isMoving = true;
            _x = x;
        }
        if (x == 0)
        {
            _isMoving = false;
        }

        if (y == 0 && context.canceled)
        {
            _isJumpCanceled = true;
        }
    }

    public void ApplyMovement()
    {
        Move();
        Jump();
    }
}

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed = 2.0f;
    public float gravity = 9.8f;
    public float jumpHeight = 25.0f;
    public float maxJumpHeight = 4.0f;
    private readonly InputComponent _inputComponent;

    public Player()
    {
        _inputComponent = new InputComponent(this);
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        _inputComponent.ApplyMovement();
    }
    public void HandleInput(InputAction.CallbackContext context)
    {
        _inputComponent.HandleInput(context);
    }

    private void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            characterController.Move(new Vector3(0, -1 * Time.deltaTime * gravity, 0));
        }
    }
}
