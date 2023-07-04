using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] protected float cooldown = 2.0f;
    private Timer _timer;
    [SerializeField] private GameObject fishPrefab;

    private void Start()
    {
        _timer = new Timer(cooldown);
    }

    private void Update()
    {
        if (_timer.IsInCooldown()) return;
        Instantiate(fishPrefab, transform.position, Quaternion.identity);
        _timer.Cooldown = Random.Range(2.0f, 10.0f);
    }
}