using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{

    public static Settings i;

    [SerializeField] TextMeshProUGUI tmpSound, tmpMusic;

    RectTransform rect;
    private void Awake()
    {
        i = this;
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        PrepareDisplay();
    }

    private void PrepareDisplay()
    {
        tmpSound.text = AudioManager.i.IsSound() ? "Sound Off" : "Sound On";
        tmpMusic.text = AudioManager.i.IsMusic() ? "Music Off" : "Music On";
    }
    public void Show()
    {
        rect.anchoredPosition = Vector2.zero;
    }

    public void Hide()
    {
        rect.anchoredPosition = Vector2.one * 1000;
    }
    public void OnBack()
    {
        Hide();
    }
    public void OnSound()
    {
        AudioManager.i.SoundToggle();
        tmpSound.text = AudioManager.i.IsSound() ? "Sound Off" : "Sound On";

    }
    public void OnMusic()
    {
        AudioManager.i.MusicToggle();
        tmpMusic.text = AudioManager.i.IsMusic() ? "Music Off" : "Music On";
    }
    
}
