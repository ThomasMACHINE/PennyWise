using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] public static string currentLevel;
    [SerializeField] private GameObject MainPanel;
    [SerializeField] private GameObject LevelSelectionPanel;

    [SerializeField] GameObject loadFromSaveButton;
    [SerializeField] public TextMeshProUGUI saveButtonText;

    public void OpenLevelSelection()
    {
        MainPanel.SetActive(false);
        CheckSaved();
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


    public void LoadNew() 
    {
        SceneManager.LoadScene("Tutorial_", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void LoadFromSave()
    {
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    private void CheckSaved()
    {
        if(currentLevel != null)
        {
            loadFromSaveButton.SetActive(true);
            saveButtonText.text = currentLevel;
        }
        else
        {
            loadFromSaveButton.SetActive(false);
        }
    }
}
