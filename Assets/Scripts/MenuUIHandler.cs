using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TMP_InputField userInput;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName()
    {
        userName.text = userInput.text;
    }
}
