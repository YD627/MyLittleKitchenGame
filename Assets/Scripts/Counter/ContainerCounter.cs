using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ≤÷ø‚πÒÃ®¿‡
public class ContainerCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private CountainerCounterVisual countainerCounterVisual;

    public override void Interact(Player player)
    {
        if (!IsHaveKitchenObject() && !player.IsHaveKitchenObject())  
        {
            CreateKitchenObject(kitchenObjectSO.prefab);
            TransferKitchenObject(this, player);
            countainerCounterVisual.PlayOpen();
        }
        else
        {
            return;
        }
    }
    public void CreateKitchenObject(GameObject kitchenObjectPrefab)
    {
        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectPrefab, GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}
