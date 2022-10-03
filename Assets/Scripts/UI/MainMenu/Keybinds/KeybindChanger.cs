using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeybindChanger : MonoBehaviour
{
    [SerializeField] KeybindButtonsController controller;
    [SerializeField] private UserControlConstants.Keybinds keybindType;
    [SerializeField] private TextMeshProUGUI text;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = controller.Get(keybindType);
    }
    /// <summary>
    /// 
    /// </summary>
    public void OnButtonPress() {
        
    }
}
