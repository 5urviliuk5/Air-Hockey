using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public TMP_Text PlayerScoreText;
    public TMP_Text EnemyScoreText;
    public int playerScore = 0;
    public int enemyScore = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<AudioSource>().Play();

        if (other.gameObject.name.Contains("EnemyScore"))
        {
            playerScore++;
            PlayerScoreText.text = playerScore.ToString();

            transform.position = Vector3.right;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("PlayerScore"))
        {
            enemyScore++;
            EnemyScoreText.text = enemyScore.ToString();

            transform.position = Vector3.left;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
