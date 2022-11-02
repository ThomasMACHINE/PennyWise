using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TutorialController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip introSoundClip;

    [SerializeField] Sprite dragonSprite;
    [SerializeField] Image mainImage;

    IEnumerator Start()
    {
        audioSource.PlayOneShot(introSoundClip);

        yield return new WaitForSeconds(10);
        ShowDragonIcon();
        yield return new WaitForSeconds(introSoundClip.length - 10);

        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }

    void ShowDragonIcon()
    {
        mainImage.sprite = dragonSprite;
    }
}
