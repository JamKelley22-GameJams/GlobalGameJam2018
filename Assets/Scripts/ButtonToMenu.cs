using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonToMenu : MonoBehaviour {
    public Button backButton;

	// Use this for initialization
	void Start () {
        backButton.onClick.AddListener(GoToMenu);
    }

    void GoToMenu() {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
