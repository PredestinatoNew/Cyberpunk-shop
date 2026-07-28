using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightAll : MonoBehaviour
{
    public FirstPersonController fpc;
    public GameObject WeightPanel;
    public GameObject Character;
    [SerializeField]
    private Text WeightInformation;

    private void Start()
    {
        fpc = Character.GetComponent<FirstPersonController>();
        
    }

    // Update is called once per frame
    public virtual void Weight()
    {
        string temp = "";
        foreach (Products product in Customer.ProductsInBascet)
        {
            try
            {
                WeightProductInBascet pr = (WeightProductInBascet)product;
                if (pr.Weight == 0)
                {
                    pr.Weight = Random.Range(100, 3000) / 1000.0;
                }
                temp += pr.Name + ": " + pr.Weight.ToString() + "\n";
            } catch (System.Exception e)
            {

            }
            
        }
        WeightInformation.text = temp;
    }

    public void Close()
    {
        WeightPanel.SetActive(false);
        IsPanelActive.AnotherPanelIsActive = false;
        Cursor.visible = false;
        fpc.Go();
    }
}
