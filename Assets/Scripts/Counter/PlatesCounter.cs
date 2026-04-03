using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private KitchenObjectSO plateSO;
    [SerializeField] private int platesCountMax = 5;
    private float timer = 0f;
    private List<KitchenObject> plateList = new List<KitchenObject>();
    
    private void Update()
    {
        if(plateList.Count < platesCountMax)
        {
            timer += Time.deltaTime;
            if (timer > spawnRate)
            {
                timer = 0f;
                GeneratePlates();
            }
        }
    }
    public override void Interact(Player player)
    {
        if (player.GetKitchenObject() == false)
        {
            if(plateList.Count > 0)
            {
                player.AddKitchenObject(plateList[plateList.Count - 1]);
                plateList.RemoveAt(plateList.Count - 1);
            }
        }
    }
    private void GeneratePlates()
    {
        KitchenObject kitchenObject = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<KitchenObject>();
        kitchenObject.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * plateList.Count;
        plateList.Add(kitchenObject);
    }
}
