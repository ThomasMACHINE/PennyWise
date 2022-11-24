using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSpawner : MonoBehaviour
{
    

    [SerializeField] GameObject fallingRock;
    // area to spawn
    [SerializeField] float x_coord1;
    [SerializeField] float x_coord2;
    [SerializeField] float y_coord1;
    [SerializeField] float y_coord2;
    [SerializeField] float z_coord1;
    [SerializeField] float z_coord2;

    [SerializeField] float waitTime;


    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {

        coroutine = WaitAndSpawnRock(waitTime);
        StartCoroutine(coroutine);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     // every 2 seconds spawn a falling rock
    private IEnumerator WaitAndSpawnRock(float waitTime)
    {

        //x, -24 -> 25, y, 0 -> 284
       // Vector3 location = new Vector3(Random.Range(-24f, 25f),178.4f,Random.Range(0f, 284f));
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //Instantiate(fallingRock, location, Quaternion.identity);
            Vector3 location = new Vector3(Random.Range(x_coord1, x_coord2),Random.Range(y_coord1, y_coord2),Random.Range(z_coord1, z_coord2));
            Instantiate(fallingRock, location, transform.rotation *  Quaternion.Euler(180, 0, 0));
        }
    }
}
