using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    private const string IS_SHAKE = "IsShake";
    [SerializeField] private TextMeshProUGUI numberText;
    private Animator animator;
    private int preNumber = -1;
    private void Start()
    {
        GameManager.Instance.OnStateChange += GameManager_OnStateChange;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (GameManager.Instance.IsCountDownState())
        {
            int nowNumber = Mathf.CeilToInt(GameManager.Instance.GetCountDownTimer());
            numberText.text = nowNumber.ToString();
            if (nowNumber!=preNumber)
            {
                preNumber = nowNumber;
                animator.SetTrigger(IS_SHAKE);
                SoundManager.Instance.PlayCountDownSound();
            }
            
        }
    }
    private void GameManager_OnStateChange(object sender, System.EventArgs e)
    {
        if(GameManager.Instance.IsCountDownState())
        {
            numberText.gameObject.SetActive(true);
        }
        else
        {
            numberText.gameObject.SetActive(false);
        }
    }
    
}
