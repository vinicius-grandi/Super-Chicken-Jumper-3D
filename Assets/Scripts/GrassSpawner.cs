using UnityEngine;
using Utilities;

public class GrassSpawner : SpawnerBase
{
    [SerializeField] private GameObject grassPrefab;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private void Update()
    {
        if (Timer.IsInCooldown()) return;
        var instantiatedObj = Instantiate(grassPrefab, ParentPosition(minY, maxY), Quaternion.identity);
        instantiatedObj.transform.localScale = Vector3.one * Random.Range(1.0f, 1.8f);
    }
}