using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    // Use this for initialization
    public Button QuitButton;

    void Start (){
        QuitButton.onClick.AddListener(QuitApplication);
    }

    void QuitApplication() {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
    }

}

