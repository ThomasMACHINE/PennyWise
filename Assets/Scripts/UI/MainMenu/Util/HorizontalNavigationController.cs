using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalNavigationController : MonoBehaviour
{
    [SerializeField] private Button leftArrow, rightArrow;

    [SerializeField] GameObject[] InstructionImages;
    private int currentIndex = 0;

    private void Awake()
    {
        InstructionImages[currentIndex].gameObject.SetActive(true);
    }

    public void ScrollRight() {
        InstructionImages[currentIndex].gameObject.SetActive(false);

        // Avoid out of bounds error
        if (currentIndex == InstructionImages.Length - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex += 1;
        }
        InstructionImages[currentIndex].gameObject.SetActive(true);
    }

    public void ScrollLeft()
    {
        // Deactivate previous Image
        InstructionImages[currentIndex].gameObject.SetActive(false);

        if (currentIndex == 0)
        {
            currentIndex = InstructionImages.Length - 1;
        }
        else
        {
            currentIndex -= 1;
        }
        // Set next image to active
        InstructionImages[currentIndex].gameObject.SetActive(true);
    }
}
