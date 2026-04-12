using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private Transform kitchenObjectParent;
    [SerializeField] private Image iconTemplate;
    private void Start()
    {
        iconTemplate.gameObject.SetActive(false);
    }
    public void UpdateUI(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;
        foreach(KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
            Image newIcon = GameObject.Instantiate(iconTemplate);
            newIcon.transform.SetParent(kitchenObjectParent);
            newIcon.sprite = kitchenObjectSO.sprite;
            newIcon.gameObject.SetActive(true);
        }
    }
}
