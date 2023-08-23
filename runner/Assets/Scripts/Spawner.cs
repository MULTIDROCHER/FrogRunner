using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private float _elapsedTime = 0f;

    void Start()
    {
        Initialize(_prefabs);
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnRate)
        {
            if (TryGetEnemy(out GameObject prefab))
            {
                _elapsedTime = 0;

                int randomPointNumber = Random.Range(0, _spawnPoints.Length);

                SetObject(prefab, _spawnPoints[randomPointNumber].position);
            }
        }
    }

    private void SetObject(GameObject prefab, Vector3 spawnPoint)
    {
        prefab.gameObject.SetActive(true);
        prefab.transform.position = spawnPoint;
    }
}