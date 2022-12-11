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

     // every # seconds spawn a falling rock (value from editor)
    private IEnumerator WaitAndSpawnRock(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 location = new Vector3(Random.Range(x_coord1, x_coord2),Random.Range(y_coord1, y_coord2),Random.Range(z_coord1, z_coord2));
            // since the falling rock model is actually a mountain, one would need to turn the prefab model on its head
            Instantiate(fallingRock, location, transform.rotation *  Quaternion.Euler(180, 0, 0));
        }
    }
}
