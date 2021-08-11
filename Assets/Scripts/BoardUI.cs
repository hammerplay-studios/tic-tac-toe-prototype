using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUI : MonoBehaviour
{
    [SerializeField]
    private BoardButton boardButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            BoardButton boardButton = Instantiate(boardButtonPrefab, transform);
            boardButton.SetIndex(i);
        }
    }

}
