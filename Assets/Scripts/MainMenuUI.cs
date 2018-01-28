using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    // Use this for initialization
    public Button PlayButton;
    public Button CreditsButton;
    public Button QuitButton;
    public Button SettingsButton;

    void Start (){
        PlayButton.onClick.AddListener(GoToLevelSelect);
        SettingsButton.onClick.AddListener(GoToSettings);
        CreditsButton.onClick.AddListener(GoToCredits);
        QuitButton.onClick.AddListener(QuitApplication);
    }

    void GoToLevelSelect() {
        SceneManager.LoadScene("LevelLoader", LoadSceneMode.Single);
    }

    void GoToCredits() {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    void GoToSettings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    void QuitApplication() {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
    }

}

