using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartButtonPressed()
    {
        SceneManager.LoadScene("Shopping");
    }

    public void EditingButtonPressed()
    {
        SceneManager.LoadScene("Editing");
    }

    public void GoBackButtonPressed()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitButtonPressed()
    {
        Debug.Log("Exit pressed!");
        Application.Quit();
    }
}
