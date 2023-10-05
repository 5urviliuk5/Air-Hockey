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
        if (other.gameObject.name.Contains("Score"))
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("EnemyScore"))
        {
            playerScore++;
            PlayerScoreText.text = playerScore.ToString();
        }

        if (other.gameObject.name.Contains("PlayerScore"))
        {
            enemyScore++;
            EnemyScoreText.text = enemyScore.ToString();
        }
    }
}
