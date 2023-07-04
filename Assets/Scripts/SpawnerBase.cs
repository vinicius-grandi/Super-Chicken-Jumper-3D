using UnityEngine;
using Utilities;

public abstract class SpawnerBase : MonoBehaviour
{
    [SerializeField] protected float cooldown = 2.0f;
    protected Timer Timer;

    protected virtual void Start()
    {
        Timer = new Timer(cooldown);
    }

    protected Vector3 ParentPosition(float minY, float maxY)
    {
        return Enemy.NewPosition(
            transform,
            new Range(-2.39f, 2.48f),
            new Range(minY, maxY)
        );
    }
}