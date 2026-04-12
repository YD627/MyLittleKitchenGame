using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeListSO fryingRecipeList;
    [SerializeField] private FryingRecipeListSO burningRecipeList;
    [SerializeField] private StoveCounterVisual stoveCounterVisual;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private AudioSource sound;

    public enum StoveState
    {
        Idle,
        Frying,
        Burning
    }

    private float fryingTimer = 0f;
    private FryingRecipe fryingRecipe;
    private StoveState state = StoveState.Idle;
    public override void Interact(Player player)
    {
        if (player.GetKitchenObject())
        {
            // 手上有食材
            if (IsHaveKitchenObject() == false) 
            {
                if (fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe newfryingRecipe))
                {
                    // 当前柜台上没有食材且传递的食材可以煎
                    TransferKitchenObject(player, this);
                    StartFrying(newfryingRecipe);
                }
                else if(burningRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe newburningRecipe)){
                    // 当前柜台上没有食材且传递的食材不可以煎
                    TransferKitchenObject(player, this);
                    StartFrying(newburningRecipe);
                }
                else { }

            }
        }
        else
        {
            // 手上没食材
            if (IsHaveKitchenObject())
            {
                // 柜台上有食材
                TurnToIdle();
                TransferKitchenObject(this, player);
            }
        }
    }
    private void Update()
    {
        switch (state)
        {
            case StoveState.Idle:
                break;
            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.fryingTime);
                if(fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);

                    burningRecipeList.TryGetFryingRecipe(fryingRecipe.output,out FryingRecipe newFryingRecipe);
                    StartBurning(newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.fryingTime);
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    TurnToIdle();
                }
                break;
            default:
                break;
        }
    }
    public void StartFrying(FryingRecipe fryingRecipe)
    {
        fryingTimer = 0f;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Frying;
        stoveCounterVisual.ShowStoveEffect();
        sound.Play();
    }
    public void StartBurning(FryingRecipe fryingRecipe)
    {
        if(fryingRecipe == null)
        {
            Debug.LogWarning("无法获取Burning的食谱，无法进行Burning。");
            TurnToIdle();
            return;
        }
        stoveCounterVisual.ShowStoveEffect();
        fryingTimer = 0f;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Burning;
        sound.Play();
    }
    private void TurnToIdle()
    {
        state = StoveState.Idle;
        stoveCounterVisual.HideStoveEffect();
        progressBarUI.Hide();
        sound.Pause();
    }
}
