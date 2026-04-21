using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI upKeyText;
    [SerializeField] private TextMeshProUGUI downKeyText;
    [SerializeField] private TextMeshProUGUI leftKeyText;
    [SerializeField] private TextMeshProUGUI rightKeyText;
    [SerializeField] private TextMeshProUGUI interactKeyText;
    [SerializeField] private TextMeshProUGUI operateKeyText;
    [SerializeField] private TextMeshProUGUI pauseKeyText;

    private void Start()
    {
        GameManager.Instance.OnStateChange += GameManager_OnStateChange;
    }

    private void GameManager_OnStateChange(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsWaitingToStart())
        {
            Show();
        }
        else
        {
            Hide() ;
        }
    }
    private void Show()
    {
        UpdateVisual();
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
    private void UpdateVisual()
    {
        upKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Up);
        downKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Down);
        leftKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Left);
        rightKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Right);
        interactKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Interact);
        operateKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Operate);
        pauseKeyText.text = GameInput.Instance.GetBingdingDisplayString(GameInput.BindingTypes.Pause);
    }
}
