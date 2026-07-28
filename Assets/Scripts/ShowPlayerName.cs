using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlayerName : MonoBehaviour
{
    private Text playerName;
    void Start()
    {
        playerName = GetComponent<Text>();
        
    }

    void Update()
    {
        playerName = GetComponent<Text>();
        playerName.text = Customer.Name;
        //Debug.Log(Customer.Name);
    }
}
