using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
       {
           SceneManager.LoadScene(0);
       });
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
}
