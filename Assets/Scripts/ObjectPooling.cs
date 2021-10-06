using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    // Array of Columns
    private GameObject[] columns;

    // Size of array
    public int columnPoolSize = 3;

    // The position (8f, -40f) that is Off Screen 
    private Vector2 objectPoolPosition = new Vector2(-10f, -30f);
    
    // That's the thing we are gonna instantiate 
    public GameObject columnPrefab;

    // How much time has passed since we last put the column in front of player 
    float timeSinceLastSpawned;

    public float columnMin = -2;
    public float columnMax = 2;
    private int currentColumn = 0;

    // X position gonna be fixed
    float spawnXPosition = 0f;

    // How often are we gonna position a new column in front of player 
    public float spawnRate = 3f;


    // Start is called before the first frame update
    void Start()
    {
        // Set up the array. So we create empty array of gameobject with five empty slots
        columns = new GameObject[columnPoolSize];
        
        // Fill that with new spawned column prefab objects
        for(int i=0; i < columnPoolSize; i++)
        {
           // We are going to Instantiate at the beginning of our game our columns and it is goona happen once 
            columns[i] =Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
       // check if it is time to reposition new column in front of our player
        // we gonna count the time that's elapsed
        timeSinceLastSpawned += Time.deltaTime;

       // If it is time to spawn a new column or to position a new column
        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {
            // Reset the time
            timeSinceLastSpawned = 0;

            // Generate a random position along the Y and position our column there, so we are going to have random offset vertically to position the columns 
            float spawnYPosition = Random.Range(columnMin, columnMax);

            // transform of position of that column
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;

           // If gets to be more than five, then we just want to reset. So we are looping to our pool we are gonna position 0 1 2 3 4 5, once we get 5 we are going to go back and grab 0 and keep repeating
           if (currentColumn >= columnPoolSize)
           {
               currentColumn = 0;
           }
        }
    }
}
