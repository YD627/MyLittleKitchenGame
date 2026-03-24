using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO cuttingRecipeList;
    public override void Interact(Player player)
    {
        if (player.GetKitchenObject())
        {
            // 手上有食材
            if (IsHaveKitchenObject() == false)
            {
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
            }
        }
    }
    public override void InteractOperate(Player player)
    {
        if (IsHaveKitchenObject())
        {
            KitchenObjectSO output = cuttingRecipeList.GetOutput(GetKitchenObject().GetKitchenObjectSO());
            if (output != null) 
            {
                DestroyKitchenObject();
                CreateKitchenObject(output.prefab);
            }
            
        }
    }
}
