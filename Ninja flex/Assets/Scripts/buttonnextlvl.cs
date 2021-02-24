using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonnextlvl : MonoBehaviour
{
    public Button btnplay;


    void Start()
    {
        Button btn = btnplay.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Dungeon Map");
    }
}
