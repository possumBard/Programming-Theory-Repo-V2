using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    // public static MenuUIHandler Instance;
    // public TextMeshProUGUI userName;
    public TMP_InputField userInput;
    public TextMeshProUGUI errorMessage;

    public bool validName;

    // ENCAPSULATION 
    private string m_userName;              // This is private/set only in this class
    public string UserName                  // This is for other classes to "get"/read-only
    {
        get { return m_userName; }
        set
        {
            if (validName)
            {
                m_userName = value;
            }
            else
            {
                ErrorMessage();
            }
        }
    }

    //private void Awake()
    //{
    //    // Use this script in other scripts
    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

        public void StartGame()
    {
        if (validName)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            ErrorMessage();
        }
        
    }

    public void SetName()
    {
        Debug.Log(userInput.text.Length);
        if (userInput.text.Length < 5 && userInput.text.Length > 0)
        {
            m_userName = userInput.text;
            validName = true;
        }
        else
        {
            validName = false;
        }
    }

    public void ResetName()
    {
        m_userName = "";
    }

    public void ErrorMessage()
    {
        errorMessage.gameObject.SetActive(true);
        errorMessage.text = "Error: Valid names are between 1 and 4 characters long.";
        ResetName();
    }

   
    


}
