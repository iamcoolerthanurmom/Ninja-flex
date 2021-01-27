using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttontrain : MonoBehaviour
{
    public Button btnplay;


    void Start()
    {
        Button btn = btnplay.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ&list=PLj1tSxNb7AbklL7GQzOMMLjGTGtdRRjSP&index=168");
    }

}
