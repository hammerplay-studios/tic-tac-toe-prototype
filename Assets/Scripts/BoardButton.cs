using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoardButton : MonoBehaviour
{
    private Button button;
    private TextMeshProUGUI buttonText;

    private int index;

    public void SetIndex (int index)
    {
        this.index = index;
        gameObject.name = string.Format("Button_{0}", index);
    }

    private void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = "";

        button = GetComponent<Button>();

        button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }


    private void OnClick ()
    {
        int currentTurn = GameManager.Instance.CurrentTurn;
        
        if (GameManager.Instance.AssignSlot(currentTurn, index))
        {
            buttonText.text = currentTurn == 1 ? "X" : "O";
        }
    }
    
}
