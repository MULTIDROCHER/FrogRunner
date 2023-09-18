using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        Initialize(_prefabs);
        StartCoroutine(Spawn());
        _waitForSeconds = new WaitForSeconds(_spawnRate);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return _waitForSeconds;

            if (TryGetEnemy(out GameObject prefab))
            {
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