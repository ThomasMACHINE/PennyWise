using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFountain : MonoBehaviour
{
    [SerializeField] int maxCoins;
    private GameObject[] coins;
    [SerializeField] float coinFrequency;
    private float timeTracker = 0;

    [SerializeField] float startingCoinDepth = 0.5f;
    [SerializeField] float minCoinDistance = 1.0f;
    [SerializeField] float maxCoinDistance = 2.75f;

    [SerializeField] GameObject coin;
    private void Awake()
    {
        if (coin.tag != "Coin")
            Debug.LogError("The coin Prefab does not have the coin tag!");
    }

    private void Start()
    {
        coins = new GameObject[maxCoins];
    }

    void Update()
    {
        timeTracker += Time.deltaTime;
        if (timeTracker > coinFrequency)
        {
            int i = 0;
            for (; i <= maxCoins; i++)
            {
                if (i == maxCoins) break;
                if (coins[i] == null) break;
            }
            if (i < maxCoins)
                coins[i] = DispenseCoin();

            timeTracker -= coinFrequency;
        }
    }

    // a lot of this coin is taken from CoinDrop.cs
    // might be smart to generalize the functions and have both scripts call the same ones
    GameObject DispenseCoin()
    {
        GameObject newCoin = GameObject.Instantiate(coin);
        newCoin.gameObject.SetActive(true);

        Vector2 direction = Random.insideUnitCircle.normalized;
                                                                                                                                                        // using Y in place of Z cus the vector is along a 2d plane and thus only has 2 dimensions
        newCoin.transform.position = gameObject.transform.position + new Vector3(direction.x * Random.Range(minCoinDistance, maxCoinDistance),-startingCoinDepth, direction.y * Random.Range(minCoinDistance, maxCoinDistance));

        newCoin.GetComponent<Collider>().isTrigger = true;  
        newCoin.transform.rotation = Quaternion.Euler(new Vector3(90, 0, Random.Range(0, 361)));

        // changing tag means the coin cant be picked up
        newCoin.tag = "Untagged";
    
        StartCoroutine(FloatCoinUpwards(newCoin, transform.position.y + 0.5f));
        return(newCoin);
    }

    IEnumerator FloatCoinUpwards(GameObject coinToFloat, float desiredHeight, float speed = 0.25f)
    {
        while (coinToFloat.transform.position.y < desiredHeight)
        {
            coinToFloat.transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            yield return null;
        }

        // putting the tag back so it can be picked up
        coinToFloat.tag = "Coin";
    }
}
