using System;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBird : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField] private float verticalSpeed = 1.0f;
    private bool _alreadyReachedPlayer;
    [SerializeField]
    private CharacterController enemyController;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        var playerPosition = player.transform.position;
        var enemyPosition = transform.position;
        if (_alreadyReachedPlayer)
        {
            Utilities.Enemy.MoveForward(transform, moveSpeed);
            return;
        }
        if (Physics.Raycast(enemyPosition, playerPosition))
        {
            enemyController.Move(new Vector3(0, 1 * verticalSpeed * Time.deltaTime, -moveSpeed * Time.deltaTime));
            return;
        }
        MoveTowardsPlayer(enemyPosition, playerPosition);
        
    }

    private void MoveTowardsPlayer(Vector3 enemyPosition, Vector3 playerPosition)
    {
        float distance = Vector3.Distance(playerPosition, enemyPosition);
        if (distance < 5)
        {
            _alreadyReachedPlayer = true;
        }

        transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, moveSpeed * Time.deltaTime);
    }
}
