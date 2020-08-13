using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixOrthographicSize : MonoBehaviour
{

    [SerializeField] SpriteRenderer box;
    [SerializeField] bool isVertical;

    private void Start()
    {
        if (isVertical)
        {
            Vertically();
        }
        else
        {
            Horizontaly();
        }
    }

    void Vertically()
    {
        float size = box.bounds.size.y / 2f;
        Camera.main.orthographicSize = size;
    }

    void Horizontaly()
    {
        float ratio = Screen.height / (float)Screen.width;
        float size = box.bounds.size.x / 2f;
        Camera.main.orthographicSize = size * ratio;
    }
}
