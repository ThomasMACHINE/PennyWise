using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNextLevel : MonoBehaviour
{
    // Name of the next scene/level to be loaded
    public string nextLevelScene;
    private string playerString = "Player";

	
	// Checks if the player touches/enters the checkpoint. If true, start teleport rutine.
    void OnTriggerEnter(Collider other) {
		if(other.tag.Equals(playerString)) {
            //From doc. https://docs.unity3d.com/2020.3/Documentation/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
            StartCoroutine(LoadYourAsyncScene());
            UpdateGlobalModelCheck(other);
            CoinScore.tempGlobalCoinScore = CoinScore.globalCoinScore;
            CoinScore.tempglobalTotalCoinScore = CoinScore.globalTotalCoinScore;
            StartMenuController.currentLevel = nextLevelScene; 
    	}
    }

    //Checks the model of the player when entering teleporter and update the global variable.
    private void UpdateGlobalModelCheck(Collider other) {
        //Determines which model was in use when entering the teleporter
        if (other.gameObject.name.Contains(nameof(PlayerStatController.GlobalModelENUM.SMALL))) {
            PlayerStatController.globalModel = PlayerStatController.GlobalModelENUM.SMALL;
        }
        else if (other.gameObject.name.Contains(nameof(PlayerStatController.GlobalModelENUM.MEDIUM))) {
            PlayerStatController.globalModel = PlayerStatController.GlobalModelENUM.MEDIUM;
        }
        else if (other.gameObject.name.Contains(nameof(PlayerStatController.GlobalModelENUM.LARGE))) {
            PlayerStatController.globalModel = PlayerStatController.GlobalModelENUM.LARGE;
        }
        else {
            // Should not be able to reach this bit
            Debug.Log("COULD NOT FIND CORRECT NAME FOR GAME OBJECT");
        }
    }
    
    //From doc. https://docs.unity3d.com/2020.3/Documentation/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
     IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextLevelScene, LoadSceneMode.Single);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
       
    }
   
}

