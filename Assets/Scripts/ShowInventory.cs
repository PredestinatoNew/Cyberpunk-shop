using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInventory : MonoBehaviour
{
    public GameObject Inventory1;
    public GameObject Inventory2;
    public GameObject Character;
    public Text Information;
    public FirstPersonController fpc;
    private void Start()
    {
        Inventory1.gameObject.SetActive(false);
        Inventory2.gameObject.SetActive(false);
        fpc = Character.GetComponent<FirstPersonController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I) && !IsPanelActive.AnotherPanelIsActive)
        {
            Inventory1.gameObject.SetActive(true);
            Inventory2.gameObject.SetActive(true);
            Cursor.visible = true;
            IsPanelActive.AnotherPanelIsActive = true;
            fpc.Stop();
        }
        if (Input.GetKeyUp(KeyCode.Escape) && (Inventory1.activeSelf) && (Inventory2.activeSelf))
        {
            Inventory1.SetActive(false);
            Inventory2.SetActive(false);
            Cursor.visible = false;
            Information.text = "";
            IsPanelActive.AnotherPanelIsActive = false;
            fpc.Go();
        }
    }
    public void Close()
    {
        Inventory1.gameObject.SetActive(false);
        Inventory2.gameObject.SetActive(false);
        Information.text = "";
        IsPanelActive.AnotherPanelIsActive = false;
        Cursor.visible = false;
        fpc.Go();
    }
}
