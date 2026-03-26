using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.CameraUI;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private CuttingCounterVisual cuttingCounterVisual;
    private int cuttingCount = 0;
    public override void Interact(Player player)
    {
        if (player.GetKitchenObject())
        {
            // 手上有食材
            if (IsHaveKitchenObject() == false)
            {
                cuttingCount = 0;
                // 当前柜台上没有食材
                TransferKitchenObject(player, this);
            }
        }
        else
        {
            // 手上没食材
            if (IsHaveKitchenObject())
            {
                // 柜台上有食材
                TransferKitchenObject(this, player);
                progressBarUI.Hide();
            }
        }
    }
    public override void InteractOperate(Player player)
    {
        // 判断是否有食材
        if (IsHaveKitchenObject())
        {
            // 获取当前食材是否能被切
            if (cuttingRecipeList.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO(), out CuttingRecipe cuttingRecipe)) 
            {
                Cut();

                progressBarUI.UpdateProgress((float)cuttingCount/cuttingRecipe.CuttingCountMax);

                if(cuttingCount == cuttingRecipe.CuttingCountMax)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(cuttingRecipe.output.prefab);
                }
                
            }
            
        }
    }
    private void Cut()
    {
        cuttingCount++;
        cuttingCounterVisual.PlayCut();
    }
}
