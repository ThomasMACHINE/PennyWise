using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenuSelection;
    [SerializeField] GameObject KeybindsMenu;
    [SerializeField] GameObject InstructionsMenu;
    /// <summary>
    /// Disables all other windows
    /// </summary>
    public void GoToStart() {
        DisableAll();
        MainMenuSelection.SetActive(true);
    }
    public void OpenKeybindsMenu() {
        DisableAll();
        KeybindsMenu.gameObject.SetActive(true);
    }
    public void GoToInstructions() {
        DisableAll();
        InstructionsMenu.gameObject.SetActive(true);
    }
    
    public void DisableAll()
    {
        InstructionsMenu.SetActive(false);
        KeybindsMenu.SetActive(false);
        MainMenuSelection.SetActive(false);
    }
    public void GoToStartUpMenu()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

}
