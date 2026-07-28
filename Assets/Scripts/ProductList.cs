using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProductList : MonoBehaviour
{
    private string temp;
    public int ListBorder = 2;
    public List<string> mytypes = new List<string>() { "Milk", "Cheese", "Cherry", "Watermelon", "Meat", "Banana" };
    private Text listText;
    protected virtual void Start()
    {
        listText = GetComponent<Text>();
        GenerateProductList();
    }

    public virtual void GenerateProductList()
    {

        Customer.ProductsToBuy.Clear();
        for (int i = 0; i < mytypes.Count; i++)
        {
            if (i < ListBorder)
            {
                Customer.ProductsToBuy.Add(mytypes[i]);
                Customer.ProductsToBuy.Add((int)Random.Range(1, 10));
                Debug.Log(Customer.ProductsToBuy[i]);
                Debug.Log(Customer.ProductsToBuy[i + 1]);
            }
            else
            {
                Customer.ProductsToBuy.Add(mytypes[i]);
                Customer.ProductsToBuy.Add((Random.Range(100, 3000)) / 1000.0);
                Debug.Log(Customer.ProductsToBuy[i]);
                Debug.Log(Customer.ProductsToBuy[i + 1]);
            }
        }
        temp = "\n";
        for (int i = 0; i < Customer.ProductsToBuy.Count; i++)
        {
            if (i % 2 == 0)
            {
                temp += Customer.ProductsToBuy[i];
            }
            else
            {
                temp += ": " + Customer.ProductsToBuy[i] + " \n";
            }
            Debug.Log(temp);
        }
        Debug.Log(Customer.ProductsToBuy);
        listText.text = temp;
    }
}
