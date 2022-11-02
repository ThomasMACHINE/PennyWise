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

        coroutine = WaitAndSpawnRock(2.0f);
        StartCoroutine(coroutine);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     // every 2 seconds spawn a falling rock
    private IEnumerator WaitAndSpawnRock(float waitTime)
    {
        Vector3 location = new Vector3(-1.2f,178.4f,69.6f);
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //Instantiate(fallingRock, location, Quaternion.identity);
            Instantiate(fallingRock, location, transform.rotation *  Quaternion.Euler(180, 0, 0));
        }
    }
}
