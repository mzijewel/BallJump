using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        string tag = collision.gameObject.tag;
        if (tag.Equals("Platform"))
        {
            Destroy(collision.gameObject);
        }
        else if (tag.Equals("Player"))
        {
            GameController.i.GameOver();
        }
    }
}
