using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeListSO fryingRecipeList;

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
            if (IsHaveKitchenObject() == false && fryingRecipeList.TryGetFryingRecipe(player.GetKitchenObject().GetKitchenObjectSO(), out FryingRecipe newfryingRecipe)) 
            {
                // 当前柜台上没有食材
                TransferKitchenObject(player, this);
                StartFrying(newfryingRecipe);
            }
        }
        else
        {
            // 手上没食材
            if (IsHaveKitchenObject())
            {
                // 柜台上有食材
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
                if(fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);

                    fryingRecipeList.TryGetFryingRecipe(fryingRecipe.output,out FryingRecipe newFryingRecipe);
                    StartBurning(newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                if(fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.prefab);
                    state = StoveState.Idle;
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
    }
    public void StartBurning(FryingRecipe fryingRecipe)
    {
        if(fryingRecipe == null)
        {
            Debug.LogWarning("无法获取Burning的食谱，无法进行Burning。");
            state = StoveState.Idle;
            return;
        }
        fryingTimer = 0f;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Burning;
    }
}
