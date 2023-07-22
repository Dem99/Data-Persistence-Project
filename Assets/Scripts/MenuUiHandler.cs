using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    public Text BestScore;
    void Start()
    {
        if (Manager.bestScore != 0)
        {
            BestScore.text = $"Best Player {Manager.bestPlayer} : {Manager.bestScore}";
        } else BestScore.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
