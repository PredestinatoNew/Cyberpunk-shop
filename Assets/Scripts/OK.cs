using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OK : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Character;
    public FirstPersonController fpc;
    void Start()
    {
        fpc = Character.GetComponent<FirstPersonController>();
    }

    public virtual void Ok()
    {
        Panel.SetActive(false);
        IsPanelActive.AnotherPanelIsActive = false;
        Cursor.visible = false;
        fpc.Go();
    }
}
