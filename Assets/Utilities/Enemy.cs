using Unity.VisualScripting;
using UnityEngine;

public struct Range
{
    public float Min { get; }
    public float Max { get; }

    public Range(float min, float max)
    {
        Min = min;
        Max = max;
    }
}

namespace Utilities
{
    public static class Enemy
    {
        public static void MoveForward(Transform transform, float moveSpeed)
        {
            transform.position += new Vector3(0, 0, -1 * moveSpeed * Time.deltaTime);
        }
        
        public static Vector3 NewPosition(Transform transform, Range x, Range y)
        {
            Vector3 newPosition = transform.position;
            
            newPosition.x = Random.Range(x.Min, x.Max);
            newPosition.y = Random.Range(y.Min, y.Max);
            
            var parentTransform = transform;
            parentTransform.position = newPosition;
            return parentTransform.position;
        }
    }
    public class Timer
    {
        private float _cooldown;
        private float _timer;

        public float Cooldown
        {
            get => _cooldown;
            set => _cooldown = value;
        }

        public Timer(float cd)
        {
            _cooldown = cd;
        }

        private void ResetTimer()
        {
            _timer = 0;
        }

        public bool IsInCooldown()
        {
            IncrementTimer();
            var isNotInCooldown = _timer > _cooldown;
            if (isNotInCooldown)
            {
                ResetTimer();
            }
            return !(isNotInCooldown);
        }

        private void IncrementTimer()
        {
            _timer += 1 * Time.deltaTime;
        }
    }
}
