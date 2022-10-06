using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenuSelection;
    [SerializeField] GameObject KeybindsMenu;
    [SerializeField] GameObject InstructionsMenu;
    /// <summary>
    /// Disables all other windows
    /// </summary>
    public void GoToStart() {
        KeybindsMenu.gameObject.SetActive(false);
        InstructionsMenu.gameObject.SetActive(false);
    }
    public void OpenKeybindsMenu() {
        KeybindsMenu.gameObject.SetActive(true);
    }
    public void GoToInstructions() {
        InstructionsMenu.gameObject.SetActive(true);
    }
    

}
