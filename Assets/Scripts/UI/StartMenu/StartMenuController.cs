using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject LevelSelectionPanel;
    
    public void OpenLevelSelection()
    {
        MainPanel.SetActive(false);

        LevelSelectionPanel.SetActive(true);
    }

    public void OpenMainMenu()
    {
        DeactivateAll();

        MainPanel.SetActive(true);
    }

    private void DeactivateAll()
    {
        MainPanel.SetActive(false);
        LevelSelectionPanel.SetActive(false);
    }


    public void LoadTutorial() 
    {
        SceneManager.LoadScene("Tutorial_", LoadSceneMode.Single);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
