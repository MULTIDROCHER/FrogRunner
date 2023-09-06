using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    private void Start()
    {
        Initialize(_prefabs);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);

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