using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform defencePoint;
    public Transform ball;
    private float speed = 5;
    public Vector3 targetPosition;
    public float attackSpeed = 20;
    public float defenceSpeed = 10;

    public AudioSource enemySound;

    void Update()
    {
        bool ballInRange = ball.position.x >= 0;

        if (ballInRange)
        {
            targetPosition = ball.position;
            speed = attackSpeed;
        }
        else
        {
            targetPosition = defencePoint.position;
            speed = defenceSpeed;
        }

        var finalPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Ball"))
        {
            enemySound.Play();
        }
    }
}
