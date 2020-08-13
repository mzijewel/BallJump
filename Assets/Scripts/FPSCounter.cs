using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{

    public TextMeshProUGUI tmpFPS;

    float timeCounter;
    float refreshTime = 0.1f;
    int frameCounter;
    float minFrameRate = 1000f;
    float maxFrameRate;

    private void Awake()
    {
        //fix target frame rate
        //Application.targetFrameRate = 60;
    }
    private void Update()
    {
        if (timeCounter < refreshTime)
        {
            timeCounter += Time.deltaTime;
            frameCounter++;
        }
        else
        {
            float lastFrameRate = frameCounter / timeCounter;
            if (lastFrameRate < minFrameRate) minFrameRate = lastFrameRate;
            if (lastFrameRate > maxFrameRate) maxFrameRate = lastFrameRate;
            frameCounter = 0;
            timeCounter = 0;

            tmpFPS.text = "FPS: " + lastFrameRate.ToString("n2")
                + "\nMin: " + minFrameRate.ToString("n2")
                + "\nMax: " + maxFrameRate.ToString("n2");
        }
    }
}
