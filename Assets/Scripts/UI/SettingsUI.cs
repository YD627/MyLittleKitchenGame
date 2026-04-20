using System;
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

    [SerializeField] private Button upKeyButton;
    [SerializeField] private Button downKeyButton;
    [SerializeField] private Button leftKeyButton;
    [SerializeField] private Button rightKeyButton;
    [SerializeField] private Button interactKeyButton;
    [SerializeField] private Button operateKeyButton;
    [SerializeField] private Button pauseKeyButton;

    [SerializeField] private TextMeshProUGUI upKeyButtonText;
    [SerializeField] private TextMeshProUGUI downKeyButtonText;
    [SerializeField] private TextMeshProUGUI leftKeyButtonText;
    [SerializeField] private TextMeshProUGUI rightKeyButtonText;
    [SerializeField] private TextMeshProUGUI interactKeyButtonText;
    [SerializeField] private TextMeshProUGUI operateKeyButtonText;
    [SerializeField] private TextMeshProUGUI pauseKeyButtonText;

    [SerializeField] private GameObject rebindingHint;
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
            GamePauseUI.Instance.Show();
            Hide();
        });
        upKeyButton.onClick.AddListener(() => 
        {
            ReBinding(GameInput.BindingTypes.Up);
        });
        downKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingTypes.Down);
        });
        leftKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingTypes.Left);
        });
        rightKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingTypes.Right);
        });
        interactKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingTypes.Interact);
        });
        operateKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingTypes.Operate);
        });
        pauseKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingTypes.Pause);
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

        upKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Up);
        downKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Down);
        leftKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Left);
        rightKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Right);
        interactKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Interact);
        operateKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Operate);
        pauseKeyButtonText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Pause);
    }
    private void ReBinding(GameInput.BindingTypes bindingType)
    {
        rebindingHint.SetActive(true);
        GameInput.Instance.ReBinding(bindingType, () =>
        {
            UpdataVisual();
            rebindingHint.SetActive(false);
        });
    }
}
