using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRockSpawner : MonoBehaviour
{

    [SerializeField] GameObject fallingRock;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {

        coroutine = WaitAndSpawnRock(0.5f);
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
            Vector3 location = new Vector3(Random.Range(-24f, 25f),178.4f,Random.Range(0f, 284f));
            Instantiate(fallingRock, location, transform.rotation *  Quaternion.Euler(180, 0, 0));
        }
    }
}
