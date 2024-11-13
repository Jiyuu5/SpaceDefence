using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int gameScore = 0;
    public int lives = 3;
    public int moveDirection = -1;
    public float movementSpeed = 2f;
    public float acceleration = 0.005f;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject gameOverText;
    public GameObject enemyGroup;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameScore;
        livesText.text = "Lives: " + lives;

        if (enemyGroup.transform.childCount == 0)
        {
            GameOver();
        }

        movementSpeed += acceleration * Time.deltaTime;
    }

    public void IncreaseGameScore(int score)
    {
        gameScore += score;
    }

    public void LoseOneLife()
    {
        if (lives > 0)
        {
            lives--;
            Instantiate(player);
        } else
        {
            GameOver();
        }
    }

    public void SetMoveDirection(int moveDirection)
    {
        this.moveDirection = moveDirection;
        enemyGroup.transform.Translate(new Vector3(0, -0.25f, 0));
        
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Invoke("ReloadLevel", 5f);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
