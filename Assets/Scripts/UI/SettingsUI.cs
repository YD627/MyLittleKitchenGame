using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI Instance { get; private set; }
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button soundButton;
    [SerializeField] private TextMeshProUGUI soundButtonText;
    [SerializeField] private Button musicButton;
    [SerializeField] private TextMeshProUGUI musicButtonText;
    [SerializeField] private Button closeButton;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Hide();
        UpdataVisual();
        soundButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdataVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdataVisual();
        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    void UpdataVisual()
    {
        soundButtonText.text = "音效大小: " + SoundManager.Instance.GetVolume().ToString();
        musicButtonText.text = "音乐大小: " + MusicManager.Instance.GetVolume().ToString();
    }
}
