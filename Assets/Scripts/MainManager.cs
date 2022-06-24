using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField] public int eggIndex;
    [SerializeField] public float zMax = 18;
    [SerializeField] public float zRange;
    [SerializeField] public float xPos = 3.5f;
    [SerializeField] private float yPos = 30.0f;
    [SerializeField] private float yMin = -25;



    public GameObject[] eggPrefabs;


    // Start is called before the first frame update
    void Start()
    {
        
        // Spawns random egg starting at 2 seconds at 1.5 second intervals
        InvokeRepeating("SpawnRandomEgg", 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy eggs after a certain point
        
    }

    // ABSTRACTION
    void SpawnRandomEgg()
    {
        // Pick a random egg index
        eggIndex = Random.Range(0, 3);

        // Currently spawns random eggs where the egg was originally put in the scene view
        Instantiate(eggPrefabs[eggIndex], GenerateSpawnPosition(), eggPrefabs[eggIndex].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Generate random z coordinate for the egg to spawn at
        zRange = Random.Range(-zMax, zMax);

        // Generate random point for the egg to spawn at
        Vector3 randomPos = new Vector3(xPos, yPos, zRange);
        return randomPos;

    }
}
