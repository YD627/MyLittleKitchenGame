using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI numberText;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        GameManager.Instance.OnStateChange += GameManager_OnStateChange;
    }

    private void GameManager_OnStateChange(object sender, System.EventArgs e)
    {
        if(GameManager.Instance.IsGameOverState())
        {
            Show();
        }
    }
    private void Show()
    {
        uiParent.SetActive(true);
        numberText.text = OrderManager.Instance.GetSuccessDeliveryCount().ToString();
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
