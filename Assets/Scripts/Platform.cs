using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform coin, body;
    private Vector2 size;
    private bool isMoveable;
    float moveSpeed = 6f;
    Vector3 dir;

    private void Update()
    {
        if (isMoveable)
        {
            transform.position = Vector3.MoveTowards(transform.position, dir, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, dir) < 0.1)
            {
                dir.x *= -1;
            }
        }
    }
    public void Init(float scale)
    {
        body.localScale = new Vector3(scale, 1, 1);
        size = body.GetComponent<SpriteRenderer>().bounds.size;

        bool isCoin = Random.Range(0, 2) == 1;

        if (isCoin)
        {
            coin.gameObject.SetActive(true);
            float coinSize = coin.GetComponent<SpriteRenderer>().bounds.size.x;
            Vector2 pos = new Vector2(Random.Range(-size.x / 2f + coinSize, size.x / 2f - coinSize), coin.position.y);
            coin.position = pos;
        }




    }
    public void SetPos(Vector2 pos)
    {
        transform.position = pos;
        dir = transform.position;
        dir.x = GameController.i.GetMaxWidth() - size.x * 0.5f;
        moveSpeed = Random.Range(2f, 5f);
        isMoveable = Random.Range(0, 3) == 1;
    }
    public float GetSize()
    {
        return size.x;
    }
}
