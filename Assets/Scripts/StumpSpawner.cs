using UnityEngine;

public class StumpSpawner : SpawnerBase
{
    private Object[] _prefabs;

    protected override void Start()
    {
        base.Start();
        _prefabs = Resources.LoadAll("Prefabs/Stumps");
    }

    private void Update()
    {
        if (Timer.IsInCooldown()) return;
        var prefabIndex = Random.Range(0, 2);

        var instantiatedObj = (GameObject)Instantiate(_prefabs[prefabIndex],
            ParentPosition(prefabIndex == 1 ? 1.5f : 0.5f, prefabIndex == 1 ? 1.5f : 0.5f), Quaternion.identity);
        instantiatedObj.transform.Rotate(0, Random.Range(0, 180), 0);
    }
}