using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public TMP_Text PlayerScoreText;
    public TMP_Text EnemyScoreText;
    public int playerScore = 0;
    public int enemyScore = 0;

    public AudioSource goalSound;
    public AudioSource wallSound;

    public float respawnCooldown;
    float respawnTimer;

    public Transform DeathPoint;
    public bool shouldRespawn;

    bool goalTextActive = false;
    float goalTextTimer = 0f;
    float goalTextDuration = 2.0f;

    public TMP_Text playerGoalText;
    public TMP_Text enemyGoalText;

    Vector3 respawnPosition;

    private void Start()
    {
        respawnTimer = respawnCooldown;
    }

    void Update()
    {
        if (shouldRespawn)
        {
            respawnTimer -= Time.deltaTime;
            if (respawnTimer <= 0)
            {
                transform.position = respawnPosition;
                respawnTimer = respawnCooldown;
                shouldRespawn = false;
            }
        }

        if (goalTextActive)
        {
            goalTextTimer += Time.deltaTime;

            if (goalTextTimer >= goalTextDuration)
            {
                playerGoalText.text = "";
                enemyGoalText.text = "";
                goalTextActive = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //GetComponent<AudioSource>().Play();

        if (other.gameObject.name.Contains("EnemyScore"))
        {
            playerScore++;
            PlayerScoreText.text = playerScore.ToString();

            playerGoalText.text = "GOAL!";
            goalTextActive = true;
            goalTextTimer = 0f;

            goalSound.Play();
            respawnPosition = Vector3.right;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            transform.position = DeathPoint.position;
            shouldRespawn = true;

            if (playerScore >= 7)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (other.gameObject.name.Contains("PlayerScore"))
        {
            enemyScore++;
            EnemyScoreText.text = enemyScore.ToString();

            enemyGoalText.text = "GOAL!";
            goalTextActive = true;
            goalTextTimer = 0f;

            goalSound.Play();
            respawnPosition = Vector3.left;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            transform.position = DeathPoint.position;
            shouldRespawn = true;

            if (enemyScore >= 7)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (other.gameObject.name.Contains("Wall"))
        {
            wallSound.Play();
        }
    }
}
