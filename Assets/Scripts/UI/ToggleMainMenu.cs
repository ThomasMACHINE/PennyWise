using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMainMenu : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject MenuPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                isPaused = true;
                Time.timeScale = 0;
                MenuPrefab.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
            else {
                isPaused = false;
                Time.timeScale = 1;
                MenuPrefab.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
