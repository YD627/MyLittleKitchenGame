using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance {  get; private set; }
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeSucceed;
    public event EventHandler OnRecipeFailed;
    [SerializeField] private RecipeListSO recipeSOList;
    [SerializeField] private float orderRate = 2f;
    [SerializeField] private int orderMaxCount = 5;

    private List<RecipeSO> orderRecipeSOList = new List<RecipeSO>();
    private float orderTimer = 0f;
    private bool isStartOrder = false; 
    private int orderCount = 0;
    private int successDeliveryCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnStateChange += GameManager_OnStateChange;
    }

    private void GameManager_OnStateChange(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGamePlayingState())
        {
            StartSpawnOrder();
        }
    }

    private void Update()
    {
        if (isStartOrder)
        {
            OrderUpdate();
        }
    }

    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if(orderTimer >= orderRate)
        {
            orderTimer = 0f;
            OrderANewRecipe();
        }
    }

    private void OrderANewRecipe()
    {
        if (orderCount >= orderMaxCount)
        {
            return;
        }
        orderCount++;
        int index = UnityEngine.Random.Range(0, recipeSOList.recipeSOList.Count);
        orderRecipeSOList.Add(recipeSOList.recipeSOList[index]);
        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void DeliveryRecipe(PlateKitchenObject plateKitchenObject)
    {
        RecipeSO correctRecipe = null;
        foreach(RecipeSO recipe in orderRecipeSOList)
        {
            if(IsCorrect(recipe, plateKitchenObject))
            {
                correctRecipe = recipe;
                break;
            }
        }
        if(correctRecipe != null)
        {
            orderRecipeSOList.Remove(correctRecipe);
            OnRecipeSucceed?.Invoke(this, EventArgs.Empty);
            print("上菜成功");
            successDeliveryCount++;
        }
        else
        {
            OnRecipeFailed?.Invoke(this, EventArgs.Empty);
            print("上菜失败");
        }
    }

    private bool IsCorrect(RecipeSO recipe, PlateKitchenObject plateKitchenObject)
    {
        List<KitchenObjectSO> list1 = recipe.kitchenObjectSOList;
        List<KitchenObjectSO> list2 = plateKitchenObject.GetKitchenObjectSOList();

        if(list1.Count != list2.Count)
        {
            return false;
        }
        foreach(KitchenObjectSO kitchenObjectSO in list1)
        {
            if (list2.Contains(kitchenObjectSO) == false)
            {
                return false;
            }
        }
        return true;
    }

    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOList;
    }
    public void StartSpawnOrder()
    {
        isStartOrder = true;
    }
    public int GetSuccessDeliveryCount()
    {
        return successDeliveryCount;
    }
}
