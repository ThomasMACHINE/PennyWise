using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingRock : MonoBehaviour {

    private string playerString = "Player";
    private int worldHeightToDestroyFallingRock = -40;
    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == playerString) {  
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update() {
        if (this.transform.position.y < worldHeightToDestroyFallingRock) {
            Destroy(this.gameObject);
        }
    }
}
