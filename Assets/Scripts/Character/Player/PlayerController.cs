using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{   
    int coinScore;
    [SerializeField] EvolveBar evolveBar;

    private void Awake()
    {
        coinScore = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && coinScore >= 5)
        {
            GetComponent<Transform>().gameObject.transform.localScale = new Vector3(3,1,1);
            coinScore += -5;
            evolveBar.UpdateSlider(coinScore);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Guard")) {
            ReloadLevel();
        }

        if (collider.gameObject.CompareTag("Coin")) {
            Destroy(collider.gameObject);
            coinScore += 1;
            evolveBar.UpdateSlider(coinScore);
        }
    }
    
    public void ReloadLevel() {
        Debug.Log("You were caught by the Guard!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
