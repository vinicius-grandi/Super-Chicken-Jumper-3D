using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    private const int _swimState = 0;
    private const int _zigZagAtkState = 1;
    private const int _bubbleAtkState = 2;
    private const int _biteAtkState = 3;
    private bool _isStateFinished;
    [SerializeField] private float moveSpeed;
    private int _nextState;

    private void Start()
    {
        SetState(_swimState);
    }

    private void Update()
    {
        if (_isStateFinished)
        {
            SetState(_nextState);
        }
    }

    private void SetState(int state)
    {
        switch (state)
        {
            case _swimState:
                OnSwimState();
                break;
            case _biteAtkState:
                OnBiteAtkState();
                break;
            case _bubbleAtkState:
                OnBubbleAtkState();
                break;
            case _zigZagAtkState:
                OnZigZagAtkState();
                break;
        }
    }

    private void NextState()
    {
        _nextState = Random.Range(0, 4);
        _isStateFinished = true;
    }
    private void OnSwimState()
    {
        Utilities.Enemy.MoveForward(transform, moveSpeed);
        _nextState = Random.Range(1, 4);
        _isStateFinished = true;
    }
    private void OnZigZagAtkState()
    {
        NextState();
    }
    private void OnBubbleAtkState()
    {
        NextState();
    }
    private void OnBiteAtkState()
    {
        var rotation = transform.rotation;
        transform.Rotate(new Vector3(27.025f, 117.67f, 42.400f));
        NextState();
    }
}
