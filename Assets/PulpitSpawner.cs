using UnityEngine;
using System.Collections;

public class PulpitSpawner : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public float minPulpitDestroyTime = 4f;
    public float maxPulpitDestroyTime = 5f;
    public float pulpitSpawnTime = 2.5f;
    public float spawnDistance = 0.0f; 

    private bool hasSpawned = false; 

    private void Start()
    {
        StartCoroutine(SpawnAndDestroyPulpit());
    }

    private IEnumerator SpawnAndDestroyPulpit()
    {
    yield return new WaitForSeconds(pulpitSpawnTime);

    if (!hasSpawned)
    {
        Vector3 spawnPosition = GetSpecificSpawnPosition();
        GameObject newPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);

        hasSpawned = true;


        PulpitSpawner newSpawner = newPulpit.AddComponent<PulpitSpawner>();
        newSpawner.pulpitPrefab = pulpitPrefab;
        newSpawner.minPulpitDestroyTime = minPulpitDestroyTime;
        newSpawner.maxPulpitDestroyTime = maxPulpitDestroyTime;
        newSpawner.pulpitSpawnTime = pulpitSpawnTime;
        newSpawner.spawnDistance = spawnDistance;

        float destroyTime = Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime);
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }
    ScoreManager.instance.IncreaseScore();
}


    private Vector3 GetSpecificSpawnPosition()
    {
        Vector3 currentPosition = transform.position;

        int direction = Random.Range(0, 4);

        Vector3 spawnPosition = currentPosition;

        switch (direction)
        {
            case 0:
                spawnPosition += new Vector3(0, 0, spawnDistance);
                break;
            case 1: 
                spawnPosition += new Vector3(spawnDistance, 0, 0);
                break;
            case 2: 
                spawnPosition += new Vector3(0, 0, -spawnDistance);
                break;
            case 3:
                spawnPosition += new Vector3(-spawnDistance, 0, 0);
                break;
        }

        return spawnPosition;
    }
}
