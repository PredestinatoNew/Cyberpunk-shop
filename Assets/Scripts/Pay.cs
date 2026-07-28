using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pay : MonoBehaviour
{
    public Text bonuses;
    public Text balance;
    public Text summary;
    public Text basket;
    public GameObject PayPanel;
    public GameObject GrayPanel;
    public GameObject Character;
    public FirstPersonController fpc;
    private double summaryPrice;
    private int count;

    private void Start()
    {
        fpc = Character.GetComponent<FirstPersonController>();
        
    }

    public virtual void ApplyBonuses()
    {
        if (Customer.Bonuses >= summaryPrice)
        {
            Customer.Bonuses -= (int)summaryPrice;
            summaryPrice = 0;
        }
        else
        {
            summaryPrice -= Customer.Bonuses;
            Customer.Bonuses = 0;
        }
        bonuses.text = Customer.Bonuses.ToString();
        summary.text = summaryPrice.ToString() + "$$";
    }

    public virtual void Payment()
    {
        if (Customer.Balance >= summaryPrice)
        {
            Customer.Balance -= (int)summaryPrice;
            PayPanel.SetActive(false);
            Customer.ProductsInBascet.Clear();
            IsPanelActive.AnotherPanelIsActive = false;
            Cursor.visible = false;
            fpc.Go();
        }
        else
        {
            GrayPanel.SetActive(true);
            PayPanel.SetActive(false);
            Cursor.visible = true;
        }
        count = 0;
    }

    void Update()
    {
        if (PayPanel.activeSelf && count == 0)
        {
            summaryPrice = 0;
            string temp = "";
            bonuses.text = Customer.Bonuses.ToString();
            balance.text = Customer.Balance.ToString();
            foreach (IActions product in Customer.ProductsInBascet)
            {
                summaryPrice += product.CalculatePrice();
                try
                {
                    WeightProductInBascet pr = (WeightProductInBascet)product;
                    temp += pr.Name + ": " + pr.Weight.ToString() + " kg " + pr.CalculatePrice().ToString() + " $$ \n";
                }
                catch (System.Exception e)
                {
                    //Debug.Log(e);
                }
                try
                {
                    PieceProductInBascet pr = (PieceProductInBascet)product;
                    temp += pr.Name + ": x1 " + pr.CalculatePrice().ToString() + " $$ \n";
                }
                catch (System.Exception e1)
                {
                    //Debug.Log(e1);
                }

            }
            summaryPrice = (int)summaryPrice;
            basket.text = temp;
            summary.text = summaryPrice.ToString() + "$$";
            count += 1;
        }
    }
}
