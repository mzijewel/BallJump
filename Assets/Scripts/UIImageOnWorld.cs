using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageOnWorld : MonoBehaviour
{
    public RectTransform imageRect;
    public RectTransform canvas;
    public Camera uiCamera;
    public Transform target;

    public Vector3 worldPos;


    private void Update()
    {
        worldPos = uiCamera.ScreenToWorldPoint(imageRect.anchoredPosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            PlaceOnUI(Input.mousePosition);
        }
    }

    void PlaceOnUI(Vector2 screenPoint)
    {
        Vector2 anchorPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, screenPoint, null, out anchorPos);
        imageRect.anchoredPosition = anchorPos;

    }

    void PlaceOnWorld(Vector3 uiPos)
    {
        Vector2 pos = uiCamera.ScreenToWorldPoint(uiPos);
        target.position = pos;
    }
}
