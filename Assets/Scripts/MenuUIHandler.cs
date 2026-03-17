using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.Tilemaps;




#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{
    public TMP_InputField Input;

    public TMP_Text Title;


    private void Start()
    {
        if(DataManager.Instance && DataManager.Instance.HighestScoreName != null)
        {
            Title.text = "Best Score:" + DataManager.Instance.HighestScoreName + ":" + DataManager.Instance.HighestScore;
        } else
        {
            Title.text = "Best Score";
        }
    }

    public void StartNew()
    {
        string inputText = Input.text.Trim();
        if(string.IsNullOrWhiteSpace(inputText))
        {
            DataManager.Instance.PlayerName = "Anonymous";
            
        } 
        else
        {
            DataManager.Instance.PlayerName = inputText;
        }
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

    public void ClickClearHighestScore()
    {
        DataManager.Instance.ClearHighestScore();
        Title.text = "Best Score";
    }
}
