using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddingData : MonoBehaviour
{
    public InputField NameInput;
    public InputField AgeInput;
    public InputField BalanceInput;
    public InputField BonusesInput;
    public void AddName()
    {
        Customer.Name = NameInput.text;
        Debug.Log(Customer.Name);
    }
    public void AddAge()
    {
        
        Customer.Age = Mathf.Abs(int.Parse(AgeInput.text)); 
        Debug.Log(Customer.Age);
    }
    public void AddBalance()
    {

        Customer.Balance = Mathf.Abs(int.Parse(BalanceInput.text));
        Debug.Log(Customer.Balance);
    }
    public void AddBonuses()
    {

        Customer.Bonuses = Mathf.Abs(int.Parse(BonusesInput.text));
        Debug.Log(Customer.Bonuses);
    }
}
