using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovePanel : MonoBehaviour
{
    public GameObject Panel2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Panel2.transform.position = new Vector3(65f, 0f, 90f);
            Debug.Log("Space key was pressed.");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Panel2.transform.position = new Vector3(163f, 0f, 90f);
            Debug.Log("Space key was released.");
        }

    }
}
