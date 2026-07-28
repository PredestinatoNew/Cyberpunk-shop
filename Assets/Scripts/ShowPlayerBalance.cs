using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerBalance : MonoBehaviour
{
    private Text playerBalance;
    void Start()
    {
        playerBalance = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerBalance = GetComponent<Text>();
        playerBalance.text = Customer.Balance.ToString() + "$$";
        //Debug.Log(Customer.Balance.ToString() + "$");
    }
}
