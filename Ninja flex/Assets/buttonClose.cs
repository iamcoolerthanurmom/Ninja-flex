using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonClose : MonoBehaviour
{

    public Button btnclose;


    void Start()
    {
        Button btn = btnclose.GetComponent<Button>();
        btn.onClick.AddListener(QuitGame);
    }
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
