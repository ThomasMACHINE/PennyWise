using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    //[SerializeField] AudioSource audioSource; //Add AudioSource here



    IEnumerator Start()
    {
        yield return new WaitForSeconds(33);

        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

}
