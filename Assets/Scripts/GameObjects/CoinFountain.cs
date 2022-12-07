using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFountain : MonoBehaviour
{
    [SerializeField] int maxDeployedCoins;
    // how many coins to spew out first, before aiming for enogh for a specific size
    [SerializeField] int initialCoinsDeployed;
    private GameObject[] coins;
    [SerializeField] float coinFrequency;
    private float timeTracker = 0;

    // should have made this as a global enum for other scripts
    // but this is written in the last week, so too late to implement a standard like this
    enum dragonType
    {
        small,
        medium,
        large
    }
    [SerializeField] dragonType targetLevel;
    private int targetLevelValue;
    // toggle that makes us ignore the coins loaded in the level and only consider how many coins the player has
    [SerializeField] bool ignoreLevelCoins = false;
    // value to keep track of every coin the player has and can get in the scene
    private int totalCoins;

    private float scanFrequency = 0.25f;

    [SerializeField] float startingCoinDepth = 0.5f;
    [SerializeField] float minCoinDistance = 1.0f;
    [SerializeField] float maxCoinDistance = 2.75f;

    [SerializeField] GameObject coin;
    private void Awake()
    {
        if (coin.tag != "Coin")
            Debug.LogError("The coin Prefab does not have the coin tag!");
        if (initialCoinsDeployed > maxDeployedCoins)
            Debug.LogError("initial number of deployed coins is greater than max number, we will go out of bounds");
    }

    private void Start()
    {
        coins = new GameObject[maxDeployedCoins];
        // find the gameobject that's parent of dragon models
        // need to do this in a roundabout way since GameObject.Find CANNOT find disabled objects
        GameObject dragonModels = GameObject.Find("Player_Models");
        switch (targetLevel)
        {
            case dragonType.small:
                // you dont need any coins to evolve into the small dragon
                // this should possibly not be an option
                // guess it's useful if you want an initial burst of coins only
                targetLevelValue = 0;
                break;
            case dragonType.medium:
                targetLevelValue = dragonModels.transform.Find("Dragon_SMALL").GetComponent<Dragon>().CoinToEvolve;
                break;
            case dragonType.large:
                targetLevelValue = dragonModels.transform.Find("Dragon_MEDIUM").GetComponent<Dragon>().CoinToEvolve;
                break;
        }
        StartCoroutine(GetTotalCoins());
        for (int i = 0; i <= initialCoinsDeployed; i++){
            coins[i] = DispenseCoin();
        }
    }

    void Update()
    {
        timeTracker += Time.deltaTime;
        if (timeTracker > coinFrequency)
        {
            int i = 0;
            for (; i <= maxDeployedCoins; i++)
            {
                if (i == maxDeployedCoins) break;
                if (coins[i] == null) break;
            }
            if (i < maxDeployedCoins)
                if (totalCoins < targetLevelValue)
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

        totalCoins++;
    
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
    IEnumerator GetTotalCoins()
    {
        int totalCoins = 0;
        // definitely more performant ways to do this
        // but this pseudo-while(true) loop is much easier to implement
        // should use the fancy job system but dont want to install the package and relearn all that
        while(this.enabled) {
            totalCoins = CoinScore.globalCoinScore;
            if (!ignoreLevelCoins)
                totalCoins += GameObject.FindGameObjectsWithTag("Coin").Length;
            yield return new WaitForSeconds(scanFrequency);
        }
    }
}
