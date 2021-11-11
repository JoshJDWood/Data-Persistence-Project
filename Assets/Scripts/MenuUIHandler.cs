using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Text scorepos1;
    [SerializeField] Text namepos1;
    [SerializeField] Text scorepos2;
    [SerializeField] Text namepos2;
    [SerializeField] Text scorepos3;
    [SerializeField] Text namepos3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighScoreTable()
    {
        if (TopManager.Instance.HighScores[0] == null)
        {
            Debug.Log("its a null shit thing");
        }
        scorepos1.text = TopManager.Instance.HighScores[0].score.ToString();
        namepos1.text = TopManager.Instance.HighScores[0].name;
        scorepos2.text = TopManager.Instance.HighScores[1].score.ToString();
        namepos2.text = TopManager.Instance.HighScores[1].name;
        scorepos3.text = TopManager.Instance.HighScores[2].score.ToString();
        namepos3.text = TopManager.Instance.HighScores[2].name;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        TopManager.Instance.SaveHighScores();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
