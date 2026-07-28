using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInteraction : MonoBehaviour
{
    [SerializeField]
    private Text Information;
    private string SelectedItem;
    void Start()
    {
        //Information = GetComponent<Text>();
    }

    public void MilkInfo()
    {
        SelectedItem = "Milk";
        int count = 0;
        foreach(Products product in Customer.ProductsInBascet)
        {
            if(product.Name == "Milk")
            {
                count++;
            }
        }
        int i = Customer.ProductsToBuy.IndexOf("Milk");
        string temp = "Packs of milk: x" + count.ToString() + "\nNeed: x" + Customer.ProductsToBuy[i+1].ToString();
        Debug.Log(temp);
        Information.text = temp;
    }

    public void CheeseInfo()
    {
        SelectedItem = "Cheese";
        int count = 0;
        foreach (Products product in Customer.ProductsInBascet)
        {
            if (product.Name == "Cheese")
            {
                count++;
            }
        }
        int i = Customer.ProductsToBuy.IndexOf("Cheese");
        Information.text = "Pieces of cheese: x" + count.ToString() + "\nNeed: x" + Customer.ProductsToBuy[i+1].ToString();
    }

    public void CherryInfo()
    {
        SelectedItem = "Cherry";
        double weight = 0;
        foreach (Products product in Customer.ProductsInBascet)
        {
            if (product.Name == "Cherry")
            {
                weight += ((WeightProductInBascet)product).Weight;
            }
        }
        int i = Customer.ProductsToBuy.IndexOf("Cherry");
        Information.text = "Summary weight of cherry: " + weight.ToString() + " kg" + "\nNeed: " + Customer.ProductsToBuy[i + 1].ToString() + " kg";
    }

    public void WatermelonInfo()
    {
        SelectedItem = "Watermelon";
        double weight = 0;
        foreach (Products product in Customer.ProductsInBascet)
        {
            if (product.Name == "Watermelon")
            {
                weight += ((WeightProductInBascet)product).Weight;
            }
        }
        int i = Customer.ProductsToBuy.IndexOf("Watermelon");
        Information.text = "Summary weight of watermelon: " + weight.ToString() + " kg" + "\nNeed: " + Customer.ProductsToBuy[i + 1].ToString() + " kg";
    }

    public void MeatInfo()
    {
        SelectedItem = "Meat";
        double weight = 0;
        foreach (Products product in Customer.ProductsInBascet)
        {
            if (product.Name == "Meat")
            {
                weight += ((WeightProductInBascet)product).Weight;
            }
        }
        int i = Customer.ProductsToBuy.IndexOf("Meat");
        Information.text = "Summary weight of meat: " + weight.ToString() + " kg" + "\nNeed: " + Customer.ProductsToBuy[i + 1].ToString() + " kg";
    }
    
    public void BananaInfo()
    {
        SelectedItem = "Banana";
        double weight = 0;
        foreach (Products product in Customer.ProductsInBascet)
        {
            if (product.Name == "Banana")
            {
                weight += ((WeightProductInBascet)product).Weight;
            }
        }
        int i = Customer.ProductsToBuy.IndexOf("Banana");
        Information.text = "Summary weight of banana: " + weight.ToString() + " kg" + "\nNeed: " + Customer.ProductsToBuy[i + 1].ToString() + " kg";
    }

    public void DeleteItem()
    {
        int count = 0;
        foreach (Products product in Customer.ProductsInBascet.ToArray())
        {
            if(SelectedItem == product.Name && count == 0)
            {
                Customer.ProductsInBascet.Remove((IActions)product);
                Information.text = SelectedItem + " item was deleted!";
                count += 1;
            }
        }
    }
}
