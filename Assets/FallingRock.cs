using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingRock : MonoBehaviour {

    
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {  
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update() {
        if (this.transform.position.y < -40) {
            Destroy(this.gameObject);
        }
    }
}
