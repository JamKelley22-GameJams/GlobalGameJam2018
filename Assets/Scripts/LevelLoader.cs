using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public Button Level1;

    // Use this for initialization
    void Start () {
        Level1.onClick.AddListener(GoToLevel1);
    }

    void GoToLevel1() {
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
