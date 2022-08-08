using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private GameObject goMain, goCredits, goOptions;

    [SerializeField] private AudioClip _buttonClick;
    [SerializeField] private AudioClip _buttonHover;

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
    }
    public void Credits()
    {
        goMain.SetActive(false);

        goCredits.SetActive(true);
        goOptions.SetActive(true);
    }
    public void Options()
    {
        goMain.SetActive(false);

        goCredits.SetActive(false);
        goOptions.SetActive(true);
    }
    public void BackToMain()
    {
        goMain.SetActive(true);

        goCredits.SetActive(false);
        goOptions.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void PlayClick()
    {
        SoundManager.Instance.PlaySound(_buttonClick);
    }
    public void PlayHover()
    {
        SoundManager.Instance.PlaySound(_buttonHover);
    }
}
