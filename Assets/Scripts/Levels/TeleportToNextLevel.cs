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

    public GameObject[] objsByTags;

    public string tagToNextLevel = "SpawnNextLevel";

    public Dictionary<string, Vector3> dicOfCoordsToSpawnPoints =  new Dictionary <string, Vector3>();
    
    //The object to be teleported
    public GameObject beingTeleported;

  /*  dicOfCoordsToSpawnPoints.Add("2OAscene", Vector3(0,20,0));
    dicOfCoordsToSpawnPoints.Add("3OAscene", Vector3(0,20,0));*/

//8.12 4.10. -14.61
    
    







    // Start is called before the first frame update
    void Start()
    {
        //Locates the player GameObject
        beingTeleported = GameObject.FindWithTag("Player");
        
        //Have to manually enter the coords of platform to teleport to. NOTE: y must be above the platform in the end.
        dicOfCoordsToSpawnPoints.Add("OAscene", new Vector3(0,0,0));
        dicOfCoordsToSpawnPoints.Add("2OAscene", new Vector3(8.12f,4.10f,-14.61f));
        dicOfCoordsToSpawnPoints.Add("3OAscene", new Vector3(-7,4.10f,0.6f));
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
           if (other.gameObject.name.Contains("SMALL")) {
            Debug.Log("Contains small");
           } 
           StartCoroutine(LoadYourAsyncScene());
           ModelCheck(other);

        
           
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
                   
           //TeleportPlayerToTargetObjectSpawn();

			//TeleportPlayerToTargetObjectSpawn(spawnObjectsList);
		}
    }

    private void ModelCheck(Collider other) {
        //Determines which model was in use when entering the teleporter.Works
           Debug.Log(Dragon.globalModel + ":::::1");
           if(other.gameObject.name.Contains("SMALL")) {
            Dragon.globalModel = "SMALL";
           }
           else if (other.gameObject.name.Contains("MEDIUM")) {
            Dragon.globalModel = "MEDIUM";
           }
           else if (other.gameObject.name.Contains("LARGE")) {
            Dragon.globalModel = "LARGE";
           }
           else {
            Debug.Log("COULD NOT FIND CORRECT NAME FOR GAME OBJECT");
           }
           Debug.Log(Dragon.globalModel + ":::::2");
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
        Vector3 teleportObjcet = new Vector3(0,0,-20);

        //Name of the scene being teleported to. Note. The corutine have not yet "finished".
        Debug.Log(nextLevelScene);
        if (dicOfCoordsToSpawnPoints.ContainsKey(nextLevelScene)) {
            teleportObjcet = dicOfCoordsToSpawnPoints[nextLevelScene];
        }
        else {
             Debug.Log("ERROR");
            //Throw an error. Something went horribly wrong.
        }
  /*      beingTeleported.transform.position.x = teleportObjcet.x;
        beingTeleported.transform.position.y = teleportObjcet.y;
        beingTeleported.transform.position.z = teleportObjcet.z;

*/

        beingTeleported.transform.position = new Vector3(teleportObjcet.x, teleportObjcet.y + 1, teleportObjcet.z);
    
	/*	beingTeleported.transform.position = new Vector3(spawnObjectInScene.transform.position.x, 
			spawnObjectInScene.transform.position.y + 1, spawnObjectInScene.transform.position.z);
	*/}

}

//NOTE: pressing q will duplicate the number of players due to not destroying on load. Fix.

