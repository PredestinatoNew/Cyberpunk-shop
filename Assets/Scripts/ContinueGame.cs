using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    public FirstPersonController fpc;
    public GameObject BackPanel;
    public GameObject Character;
    public void Start()
    {
        fpc = Character.GetComponent<FirstPersonController>();
    }
    
    public void ContinueYourGame()
    {
        BackPanel.SetActive(false);
        Cursor.visible = false;
        fpc.Go();
    }
}
