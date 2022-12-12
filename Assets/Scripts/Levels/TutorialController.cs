using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutorialController : MonoBehaviour
{


    [SerializeField] Image mainImage;

    IEnumerator Start()
    {


        yield return new WaitForSeconds(20);

        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }


}
