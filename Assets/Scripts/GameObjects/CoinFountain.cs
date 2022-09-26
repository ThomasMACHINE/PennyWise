using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFountain : MonoBehaviour
{
    [SerializeField] int maxCoins;
    private GameObject[] coins;
    [SerializeField] float coinFrequency;
    private float timeTracker = 0;

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
        newCoin.transform.position = gameObject.transform.position + new Vector3(0,1.5f,0);
        newCoin.gameObject.SetActive(true);

        //Find a direction and give the coin a velocity in that direction
        int directionX = Random.Range(0, 2) == 0 ? -1 : 1;
        int directionZ = Random.Range(0, 2) == 0 ? -1 : 1;
        newCoin.GetComponent<Rigidbody>().velocity = new Vector3(directionX * Random.Range(1, 2), Random.Range(1, 2), directionZ * Random.Range(1, 2));
        return(newCoin);
    }
}
