using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

public class Dagger : MonoBehaviour
{
    [SerializeField] private Collider leftWingCollider;
    [SerializeField] private Collider rightWingCollider;
    [SerializeField] private float animationDuration = 2.0f;
    private Timer _timer;
    private void Start()
    {
        _timer = new Timer(2.0f);
        DisableAttack();
    }

    public void LeftAttack(InputAction.CallbackContext context)
    {
        Attack(0);
    }
    public void RightAttack(InputAction.CallbackContext context)
    {
        Attack(1);
    }

    private void DisableAttack()
    {
        leftWingCollider.enabled = false;
        rightWingCollider.enabled = false;
    }
    private void Attack(int leftOrRight)
    {
        if (_timer.IsInCooldown()) return;
        new[] { leftWingCollider, rightWingCollider }[leftOrRight].enabled = true;
        Invoke(nameof(DisableAttack), animationDuration);
    }
}