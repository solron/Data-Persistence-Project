using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField inputField;

    private void Awake()
    {
        ScoreManager.instance.LoadScoreValue();
    }

    public void StartGame()
    {
        if (inputField.text != "")
        {
            ScoreManager.instance.currentPlayer = inputField.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            inputField.text = "Enter a name";
        }
    }
}
