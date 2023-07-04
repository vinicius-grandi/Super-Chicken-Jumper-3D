using UnityEngine;

public class Decoration : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;
    private void Update()
    {
        Utilities.Enemy.MoveForward(transform, moveSpeed);
    }
}
