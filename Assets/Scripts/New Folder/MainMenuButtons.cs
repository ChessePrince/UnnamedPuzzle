using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _clicClip;
    [SerializeField] private GameObject goMain, goCredits, goOptions;

    private void Awake()
    {
        goMain.SetActive(true);
        goCredits.SetActive(false);
        goOptions.SetActive(false);
        _audioSource = GetComponent<AudioSource>();

        /*
        if (0 == SceneManager.GetActiveScene().buildIndex)
        {
            goCredits.SetActive(false);
        }
        */
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
        PlayClic();
    }
    public void Credits()
    {
        goMain.SetActive(false);
        goCredits.SetActive(true);
        PlayClic();
    }
    public void Options()
    {
        goMain.SetActive(false);
        goOptions.SetActive(false);
        PlayClic();
    }
    public void Back()
    {
        goMain.SetActive(true);
        goCredits.SetActive(false);
        PlayClic();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void PlayClic()
    {
        _audioSource.PlayOneShot(_clicClip, 0.2f);
    }
}
