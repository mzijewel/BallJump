using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePanel : MonoBehaviour
{
    public static GamePanel i;

    [SerializeField] TextMeshProUGUI txtScore, txtBestScore;

    RectTransform rect;

    private void Awake()
    {
        i = this;
        rect = GetComponent<RectTransform>();
    }

    public void Show()
    {
        rect.anchoredPosition = Vector2.zero;
    }
    public void Hide()
    {
        rect.anchoredPosition = Vector2.one*1000;
    }

    public void ShowScore(int score)
    {      
        txtScore.text = score.ToString();        
    }
    public void ShowBestScore(int score)
    {
        txtBestScore.text = score.ToString();
    }

    public void OnPause()
    {
       
        GameController.i.Pause();
    }
}
