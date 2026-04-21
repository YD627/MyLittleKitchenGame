using System;
using System.Collections.Generic;
using UnityEngine;

// 新增了menuName和fileName参数，方便在Unity右键菜单中创建
[CreateAssetMenu(fileName = "NewCuttingRecipeList", menuName = "Kitchen Chaos/Recipe Lists/Cutting Recipe List")]
public class CuttingRecipeListSO : ScriptableObject
{
    // 将内部类移出，作为公共可序列化类（可选，也可保持原样）
    [Serializable]
    public class CuttingRecipe
    {
        public KitchenObjectSO input;
        public KitchenObjectSO output;
        public int cuttingProgressMax; // 建议：将‘CuttingCountMax’改为更符合Unity命名规范的‘cuttingProgressMax’
    }

    public List<CuttingRecipe> recipeList; // 将‘list’改为更具描述性的‘recipeList’

    public KitchenObjectSO GetOutput(KitchenObjectSO input)
    {
        foreach (CuttingRecipe recipe in recipeList)
        {
            if (recipe.input == input)
            {
                return recipe.output;
            }
        }
        return null;
    }

    public bool TryGetCuttingRecipe(KitchenObjectSO input, out CuttingRecipe cuttingRecipe)
    {
        foreach (CuttingRecipe recipe in recipeList)
        {
            if (recipe.input == input)
            {
                cuttingRecipe = recipe;
                return true;
            }
        }
        cuttingRecipe = null;
        return false;
    }
}