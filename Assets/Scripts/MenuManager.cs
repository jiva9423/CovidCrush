using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject HowToPlayPanel;
    public GameObject SettingsPanel;
    public GameObject LoadingPanel;
    // Start is called before the first frame update
    private void Start()
    {
        LoadingPanel.SetActive(true);
        LoadScreen();
    }

    public void LoadScreen() {
        StartCoroutine(TimeToLoad());
    }

    IEnumerator TimeToLoad()
    {
        yield return new WaitForSecondsRealtime(1);
        LoadingPanel.SetActive(false);
    }



    public void StartButtonPressed() {
        SceneManager.LoadScene(1); //loads the game scene
    }

    public void HowToPlayButtonPressed() {
        //open how to play panel and close all other panels
        HowToPlayPanel.SetActive(true); 
        SettingsPanel.SetActive(false);
    }

    public void SettingsButtonPressed()
    {
        //open settings panel
        HowToPlayPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void BackButtonPressed() {
        //go back to main menu panel
        HowToPlayPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
}
