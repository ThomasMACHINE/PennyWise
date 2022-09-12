using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToNextLevel : MonoBehaviour
{



	//The playable object (the one being teleported)
	public GameObject beingTeleported;

    // Name of the next scene/level to be loaded
    public string nextLevelScene;

    private GameObject[] gameObjectList55;




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

          
           // Debug.Log(SceneManager.GetActiveScene().name);

            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextLevelScene));
            //TODO: Active not foud
           // gameObjectList55 = Resources.FindObjectsOfTypeAll<GameObject>();
            gameObjectList55 = GameObject.FindGameObjectsWithTag("SpawnNextLevel");
            GameObject[] spawnObjectsList = gameObjectList55;
            
                   
           TeleportPlayerToTargetObjectSpawn(spawnObjectsList);

           


           

			//TeleportPlayerToTargetObjectSpawn(spawnObjectsList);
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
        
        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(beingTeleported, SceneManager.GetSceneByName(nextLevelScene));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);


        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextLevelScene));
        Debug.Log(SceneManager.GetActiveScene().name + " Co");
    }


    // Teleports player to the spawn object in the next scene.
	//To avoid being stuck, teleports a few meters(?) above the object. NOTE: Need to adjust from the CENTER of the object (so flat objects is the best)
	void TeleportPlayerToTargetObjectSpawn(GameObject[] spawnObjectsList) {
		//beingTeleported.transform.position = targetToTeleportTo.transform.position;
        GameObject spawnObjectInScene = null;

        foreach (GameObject obj in spawnObjectsList) {
         if (obj.scene == SceneManager.GetActiveScene() && obj.tag == "SpawnNextLevel") {
            spawnObjectInScene = obj;
            break;
         }
        }

        beingTeleported.transform.position = new Vector3(4,5,0);
    /*
		beingTeleported.transform.position = new Vector3(spawnObjectInScene.transform.position.x, 
			spawnObjectInScene.transform.position.y + 1, spawnObjectInScene.transform.position.z);*/
	}
/*
    GameObject FindCurrentActiveSpawn(GameObject[] spawnObjectsList){
        GameObject spawnObjectInScene = null;
        foreach (GameObject obj in spawnObjectsList) {
         if (obj.scene == SceneManager.GetActiveScene()) {
            spawnObjectInScene = obj;
         }
         //TODO: fix
        return spawnObjectInScene;
        }
    }*/
}