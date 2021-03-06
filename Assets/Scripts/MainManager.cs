using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainManager : MonoBehaviour
{
    [SerializeField] public int eggIndex;
    [SerializeField] public float zMax = 18;
    [SerializeField] public float zRange;
    [SerializeField] public float xPos = 3.5f;
    [SerializeField] private float yPos = 30.0f;
    //[SerializeField] private float yMin = -25;
    public int score;
    public float spawnRate = 1.5f;
    //[SerializeField] public int lives = 3;
    public bool isGameActive;
    public static MainManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScoreText;
    public Button restartButton;

    

    public GameObject[] eggPrefabs;

    private MenuUIHandler menuUI;
    


    // Start is called before the first frame update
    private void Start()
    {
        // Use this script in other scripts
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Sets the game as active
        isGameActive = true;

        // Set score to zero on start
        score = 0;

        // Displays player's name at start
        menuUI = GameObject.Find("User Interface").GetComponent<MenuUIHandler>();
        playerNameText.text = "Player Name: \n" + menuUI.UserName;

        // Spawns random eggs at 1.5 second intervals
        StartCoroutine(SpawnRandomEgg());

        // Display high score
        DisplayHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: \n" + score;

        CheckHighScore();
    }



    // ABSTRACTION
    IEnumerator SpawnRandomEgg()
    {

        while (isGameActive)
        {
            // Wait some time between spawning eggs
            yield return new WaitForSeconds(spawnRate);

            // Pick a random egg index
            eggIndex = Random.Range(0, 3);

            // Currently spawns random eggs where the egg was originally put in the scene view
            Instantiate(eggPrefabs[eggIndex], GenerateSpawnPosition(), eggPrefabs[eggIndex].transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Generate random z coordinate for the egg to spawn at
        zRange = Random.Range(-zMax, zMax);

        // Generate random point for the egg to spawn at
        Vector3 randomPos = new Vector3(xPos, yPos, zRange);
        return randomPos;

    }

    

    public void CheckHighScore()
    {
        if(score > DataManager.Instance.highScore)
        {
            DataManager.Instance.highScore = score;
            DataManager.Instance.winnerName = menuUI.UserName;

            DataManager.Instance.SaveHighScore();
        }
    }

    public void DisplayHighScore()
    {
        highScoreText.text = "High Score: " + DataManager.Instance.winnerName + "\n" + DataManager.Instance.highScore;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
