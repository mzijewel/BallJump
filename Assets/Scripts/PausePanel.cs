using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    public static PausePanel i;

    RectTransform rect;

    private void Awake()
    {
        i = this;
        rect = transform.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.one * 1000f;
    }


    public void Show()
    {
        rect.anchoredPosition = Vector2.zero;
    }

    public void OnClose()
    {
        rect.anchoredPosition = Vector2.one * 1000f;
        Time.timeScale = 1;
    }
    public void OnReplay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public void OnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
