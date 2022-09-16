using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    [SerializeField] GameObject coin;
    private void Awake()
    {
        if (coin.tag != "Coin")
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
            GameObject newCoin = GameObject.Instantiate(coin);

            newCoin.transform.position = position;
            newCoin.gameObject.SetActive(true);

            int direction = Random.Range(0, 1) == 0 ? -1 : 1;
            newCoin.GetComponent<Rigidbody>().velocity = new Vector3(direction * Random.Range(1, 10), Random.Range(1, 10), direction * Random.Range(1, 10));
        }
    }
}
