using UnityEngine;

public class FishEnemy : MonoBehaviour
{
    [SerializeField] private CharacterController fishController;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float horizontalSpeed = 2f;
    [SerializeField] private float gravity = 9.8f;
    private GameObject _colliderObject;
    private bool _isJumping;
    private float _jumpStartTime;
    private float _vSpeed;
    private float _x;

    private void Start()
    {
        _colliderObject = GameObject.FindWithTag("Finish");
        Physics.IgnoreLayerCollision(3, 3);
        transform.LookAt(_colliderObject.transform);
        if (transform.position.x < 0)
        {
            _x = 17;
        }

        _x = -17;
    }

    private void Update()
    {
        if (fishController.isGrounded)
        {
            _vSpeed = jumpHeight;
        }

        transform.LookAt(_vSpeed < 0 ? new Vector3(_x, 0, 0) : new Vector3(_x, jumpHeight, 0));

        _vSpeed -= gravity * Time.deltaTime;
        fishController.Move(new Vector3(horizontalSpeed * -1, _vSpeed) * Time.deltaTime);
    }
}