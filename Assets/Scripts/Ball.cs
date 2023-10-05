using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Ball : MonoBehaviour
{
    public TMP_Text PlayerScoreText;
    public TMP_Text EnemyScoreText;
    public int playerScore = 0;
    public int enemyScore = 0;

    public AudioSource goalSound;
    public AudioSource wallSound;


    void OnCollisionEnter2D(Collision2D other)
    {
        //GetComponent<AudioSource>().Play();

        if (other.gameObject.name.Contains("EnemyScore"))
        {
            playerScore++;
            PlayerScoreText.text = playerScore.ToString();
            goalSound.Play();
            transform.position = Vector3.right;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("PlayerScore"))
        {
            enemyScore++;
            EnemyScoreText.text = enemyScore.ToString();
            goalSound.Play();
            transform.position = Vector3.left;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (other.gameObject.name.Contains("Wall"))
        {
            wallSound.Play();
        }
    }
}
