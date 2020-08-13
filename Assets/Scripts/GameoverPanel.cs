using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameoverPanel : MonoBehaviour
{
    public static GameoverPanel i;

    [SerializeField] TextMeshProUGUI txtScore, txtBestScore;

    RectTransform rect;

    private void Awake()
    {
        i = this;
        rect = GetComponent<RectTransform>();
    }

    public void Show(int score)
    {
        int bestScore = PlayerPrefs.GetInt(Constants.BEST_SCORE);
       
        txtScore.text = score.ToString();
        txtBestScore.text = bestScore.ToString();

        rect.anchoredPosition = Vector2.zero;
        
    }

    public void Hide()
    {
        rect.anchoredPosition = Vector2.one * 1000;
    }
    public void OnReplay()
    {
        GameController.i.Replay();
    }
    public void OnMainMenu()
    {
        GameController.i.MainMenu();
    }
}
