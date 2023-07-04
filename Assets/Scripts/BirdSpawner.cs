using UnityEngine;

public class BirdSpawner : SpawnerBase
{
    [SerializeField] private GameObject birdPrefab;

    private void Update()
    {
        if (Timer.IsInCooldown()) return;
        Instantiate(birdPrefab, ParentPosition(0f, 0f), Quaternion.identity);
    }
}