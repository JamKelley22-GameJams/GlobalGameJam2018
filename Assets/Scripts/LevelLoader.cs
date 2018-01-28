using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public Button Level1;
    public Button Level2;
    public Button Level3;

    // Use this for initialization
    void Start () {
        Level1.onClick.AddListener(GoToLevel1);
        Level2.onClick.AddListener(GoToLevel2);
        Level3.onClick.AddListener(GoToLevel3);
    }

    void GoToLevel1() {
        SceneManager.LoadScene("test", LoadSceneMode.Single);
    }

    void GoToLevel2()
    {
        SceneManager.LoadScene("test1", LoadSceneMode.Single);
    }

    void GoToLevel3()
    {
        SceneManager.LoadScene("test2", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
