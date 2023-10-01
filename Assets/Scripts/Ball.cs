using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public TMP_Text PlayerScoreText;
    public TMP_Text EnemyScoreText;
    private int PlayerScore = 0;
    private int EnemyScore = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Score"))
        {
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("Player Score"))
        {
            PlayerScore++;
            PlayerScoreText.text = PlayerScore.ToString();
        }

        if (other.gameObject.name.Contains("Enemy Score"))
        {
            EnemyScore++;
            EnemyScoreText.text = EnemyScore.ToString();
        }
    }
}
