using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    public static GamePauseUI Instance { get; private set; }
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button menuButton;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Hide();
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpasued += GameManager_OnGameUnpasued;
        resumeButton.onClick.AddListener(() => {
            GameManager.Instance.ToggleGame();
        });
        settingsButton.onClick.AddListener(() => {
            SettingsUI.Instance.Show();
            Hide();
        });
        menuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.GameMenuScene); 
        });
    }

    private void GameManager_OnGameUnpasued(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    public void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
