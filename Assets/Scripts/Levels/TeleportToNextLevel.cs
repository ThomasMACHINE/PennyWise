using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNextLevel : MonoBehaviour
{



	//The playable object (the one being teleported)
	//public GameObject beingTeleported;

    // Name of the next scene/level to be loaded
    public string nextLevelScene;


    
    //The object to be teleported
    //public GameObject beingTeleported;

    // Start is called before the first frame update
    void Start()
    {      

    }

    // Update is called once per frame
    void Update()
    {

    }

	
	// Checks if the player touches/enters the checkpoint.
    void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
            Debug.Log("Teleporting to next level!");
            //From doc. https://docs.unity3d.com/2020.3/Documentation/ScriptReference/SceneManagement.SceneManager.MoveGameObjectToScene.html
            StartCoroutine(LoadYourAsyncScene());
            UpdateGlobalModelCheck(other);
                       
    	}
    }

    //Checks the model of the player when entering teleporter and update the global variable.
    //TODO: ADD A COINSCORE VARIABLE TO BE UPDATED ON ENTERING
    private void UpdateGlobalModelCheck(Collider other) {
        //Determines which model was in use when entering the teleporter
        if (other.gameObject.name.Contains(nameof(PlayerStatController.GlobalModelENUM.SMALL))) {
            PlayerStatController.globalModel = PlayerStatController.GlobalModelENUM.SMALL;
        }
        //else if (other.gameObject.name.Contains(Dragon.GlobalModelENUM.MEDIUM)) {
        else if (other.gameObject.name.Contains(nameof(PlayerStatController.GlobalModelENUM.MEDIUM))) {
            PlayerStatController.globalModel = PlayerStatController.GlobalModelENUM.MEDIUM;
        }
        //else if (other.gameObject.name.Contains(Dragon.GlobalModelENUM.LARGE)) {
        else if (other.gameObject.name.Contains(nameof(PlayerStatController.GlobalModelENUM.LARGE))) {
            PlayerStatController.globalModel = PlayerStatController.GlobalModelENUM.LARGE;
        }
        else {
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


        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextLevelScene));
       
    }
   
}

