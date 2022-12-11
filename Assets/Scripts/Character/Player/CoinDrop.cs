using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    [SerializeField] GameObject coinUnPickAble;
    private Vector3 coinDropHeightOffset = new Vector3 (0,3,0);
    private int minCoinDropVelocity = 1;
    private int maxCoinDropVelocity = 5;
    private string coinString = "Coin";


    private void Awake()
    {
        if (coinUnPickAble.tag != coinString)
            Debug.LogError("The coin Prefab does not have the coin tag!");
    }

    /// <summary>
    /// Spawns a number of coins around the position
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="position"></param>
    public void DropCoins(int amount, Vector3 position) 
    {
        for (int i = 0; i < amount; i++) {
            GameObject newCoin = GameObject.Instantiate(coinUnPickAble);

            newCoin.transform.position = position + coinDropHeightOffset;
            newCoin.gameObject.SetActive(true);

            //Find a direction and give the coin a velocity in that direction. Range, inclusive on start/exclusive on end.
            int directionX = Random.Range(0, 2) == 0 ? -1 : 1;
            int directionZ = Random.Range(0, 2) == 0 ? -1 : 1;
            newCoin.GetComponent<Rigidbody>().velocity = new Vector3(directionX * Random.Range(minCoinDropVelocity, maxCoinDropVelocity), Random.Range(minCoinDropVelocity, maxCoinDropVelocity), directionZ * Random.Range(minCoinDropVelocity, maxCoinDropVelocity));
        }
    }
}
