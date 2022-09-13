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

    public GameObject[] objsByTags;

    public string tagToNextLevel = "SpawnNextLevel";

    public Dictionary<string, Vector3> dicOfCoordsToSpawnPoints =  new Dictionary <string, Vector3>();
   // dicOfCoordsToSpawnPoints.Add("OAscene", Vector3(0,20,0));
  /*  dicOfCoordsToSpawnPoints.Add("2OAscene", Vector3(0,20,0));
    dicOfCoordsToSpawnPoints.Add("3OAscene", Vector3(0,20,0));*/

//8.12 4.10. -14.61
    
    







    // Start is called before the first frame update
    void Start()
    {
       // GameObject[] objsByTags = FindInActiveObjectsByTag("SpawnNextLevel");
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

          
            Debug.Log(SceneManager.GetActiveScene());

            //SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextLevelScene));
            //TODO: Active not foud
           // gameObjectList55 = Resources.FindObjectsOfTypeAll<GameObject>();
            //var gameObjectList = FindObjectOfType<Material>(true);
           /* 
           GameObject[] objsByTags = FindInActiveObjectsByTag(tagToNextLevel);
           GameObject[] spawnObjectsList = objsByTags;
           Debug.Log("Hello " + spawnObjectsList.Length);
           Debug.Log(spawnObjectsList.Length + " Before teleport");
            */
                   
           TeleportPlayerToTargetObjectSpawn();

			//TeleportPlayerToTargetObjectSpawn(spawnObjectsList);
		}
    }
/*
//https://stackoverflow.com/questions/44456133/find-inactive-gameobject-by-name-tag-or-layer?rq=1
   GameObject[] FindInActiveObjectsByTag(string tag)
{
    List<GameObject> validTransforms = new List<GameObject>();
    Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
    Debug.Log(objs.Length + " Number of elements found");
    for (int i = 0; i < objs.Length; i++)
    { 
        
        if (objs[i].hideFlags == HideFlags.None)
        {
            Debug.Log("The tag: " + objs[i].gameObject.tag);
            if (objs[i].gameObject.tag == tag)
            {
                Debug.Log("Found it");
                validTransforms.Add(objs[i].gameObject);
            }
        }
    }
    return validTransforms.ToArray();
}*/
    
    
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
       
    }


    // Teleports player to the spawn object in the next scene.
	//To avoid being stuck, teleports a few meters(?) above the object. NOTE: Need to adjust from the CENTER of the object (so flat objects is the best)
	void TeleportPlayerToTargetObjectSpawn() {
		//beingTeleported.transform.position = targetToTeleportTo.transform.position;
       


        beingTeleported.transform.position = new Vector3(4,5,-5);
    
	/*	beingTeleported.transform.position = new Vector3(spawnObjectInScene.transform.position.x, 
			spawnObjectInScene.transform.position.y + 1, spawnObjectInScene.transform.position.z);
	*/}

}