using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TMP_InputField userInput;
    public TextMeshProUGUI errorMessage;

    public bool validName;

    public void StartGame()
    {
        if (validName)
        {
            SceneManager.LoadScene(1);
            Debug.Log(userInput.text.Length);
            Debug.Log(userName.text);
        }
        else
        {
            errorMessage.gameObject.SetActive(true);
            errorMessage.text = "Error: Valid names are between 1 and 4 characters long.";
            ResetName();
        }
        
    }

    public void SetName()
    {
        if(userInput.text.Length > 4 && userInput.text.Length > 0)
        {
            userName.text = userInput.text;
            validName = true;
        }
        else
        {
            validName = false;
        }
    }

    public void ResetName()
    {
        userName.text = "";
    }
}
