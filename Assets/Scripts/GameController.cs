using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;
using System;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI tmpTest;

    public static GameController i;
    [SerializeField] Ball ball;

    public Transform coinTrarget;


    [SerializeField] SpriteRenderer background;
    [SerializeField] Transform collector, firstPlatform;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    Transform camTrans;
    int score, bestScore;
    float orthographicSize;

    Vector2 camLastPos;
    float lastPlatformY;
    float lastCamPosY;
    bool isCamMoving;

    private void Awake()
    {
        i = this;
        FixedOrthographicSize();
    }
    private void Start()
    {
        camTrans = Camera.main.transform;
        camLastPos = camTrans.position;
        lastCamPosY = camLastPos.y;

        bestScore = PlayerPrefs.GetInt(Constants.BEST_SCORE);
        GamePanel.i.ShowBestScore(bestScore);
        GamePanel.i.ShowScore(score);

        GeneratePlatforms();

        Time.timeScale = 1;
    }

    private void FixedOrthographicSize()
    {

        orthographicSize = background.bounds.size.x * 0.5f * Screen.height / Screen.width;
        virtualCamera.m_Lens.OrthographicSize = orthographicSize;

        float d = orthographicSize - Mathf.Abs(firstPlatform.position.y) - 1f;
        virtualCamera.transform.position = new Vector3(0, d, 0);
        collector.localPosition = new Vector2(0, -orthographicSize - 0.3f);


    }
    private void Update()
    {
        if (camTrans.position.y - camLastPos.y > 10)
        {
            camLastPos = camTrans.position;
            GeneratePlatforms();
        }

        isCamMoving = camTrans.position.y > lastCamPosY + 0.02f;
        lastCamPosY = camTrans.position.y;
    }

    public bool IsCamMoving()
    {
        return isCamMoving;
    }

    public void GeneratePlatforms()
    {
        for (int i = 0; i < 10; i++)
        {
            float size = UnityEngine.Random.Range(0.5f, 1f);

            Platform platform = Instantiate(GameAssets.i.pfPlatform, Vector3.zero, Quaternion.identity).GetComponent<Platform>();
            platform.Init(size);

            float platformSize = platform.GetSize() / 2f;

            Vector2 pos = new Vector2(UnityEngine.Random.Range(-GetMaxWidth() + platformSize, GetMaxWidth() - platformSize), lastPlatformY + 0.8f + UnityEngine.Random.Range(0.2f, 1f));

            platform.SetPos(pos);

            lastPlatformY = pos.y;
        }

    }

    public float GetMaxWidth()
    {
        return background.bounds.size.x*0.5f;
    }

    public float OrthographicSize()
    {
        return orthographicSize;
    }

    public void CollectCoin()
    {
        score++;

        GamePanel.i.ShowScore(score);
        if (score > bestScore)
        {
            bestScore = score;
            GamePanel.i.ShowBestScore(bestScore);
            PlayerPrefs.SetInt(Constants.BEST_SCORE, bestScore);
        }
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");

    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.i.Show();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameoverPanel.i.Show(score);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
