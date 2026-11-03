using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    //Input Action
    public InputAction spawnAction;

    // in the inspector
    public GameObject[] animalPrefabs;

    // Private Variables
    private float spawnRangeX = 15;
    private float spawnRangeZ = 20;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Spawn animals at regular intervals
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);

        spawnAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnAction.triggered)
        {

            SpawnRandomAnimal();
        }

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);

        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
