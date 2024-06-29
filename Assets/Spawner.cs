using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // �A�C�e���̃v���n�u
    public GameObject[] obstaclePrefabs; // ��Q���̃v���n�u
    public float spawnInterval = 2f; // ��������Ԋu
    public float spawnY = 5;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }
    private void SpawnObject()
    {
        bool spawnLeft = Random.value > 0.5f;
        Vector3 spawnPosition = spawnLeft ? new Vector3(-3, spawnY, 0) : new Vector3(3, spawnY, 0);
        GameObject[] prefabs = Random.value > 0.5f ? itemPrefabs : obstaclePrefabs;
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
    
}
