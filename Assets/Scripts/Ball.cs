using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

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
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //GetComponent<AudioSource>().Play();

        if (other.gameObject.name.Contains("EnemyScore"))
        {
            playerScore++;
            PlayerScoreText.text = playerScore.ToString();
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
