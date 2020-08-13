using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float speed = 15f;
    private bool isMove;
    Vector2 targetPos;

    private void Update()
    {
        if (isMove)
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Ball"))
        {
            isMove = true;
            AudioManager.i.PlayCoinHit();
            targetPos = Camera.main.ScreenToWorldPoint(GameController.i.coinTrarget.position);
            GameController.i.CollectCoin();
        }
    }
}
