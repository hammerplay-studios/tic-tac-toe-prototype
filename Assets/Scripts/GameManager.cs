using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int[] board = new int[] {
        0, 0, 0,
        0, 0, 0,
        0, 0, 0
    };

    private bool HasEmptySlot ()
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == 0)
                return true;
        }

        return false;
    }

    private int GetWinner ()
    {
        // Horizontal Checks
        // 0, 1, 2
        if (board[0] == board[1] && board[1] == board[2] && board[2] != 0)
            return board[0];
        // 3, 4, 5
        if (board[3] == board[4] && board[4] == board[5] && board[5] != 0)
            return board[3];
        // 6, 7, 8
        if (board[6] == board[7] && board[7] == board[8] && board[8] != 0)
            return board[6];

        // Verticals Checks
        // 0, 3, 6
        if (board[0] == board[3] && board[3] == board[6] && board[6] != 0)
            return board[0];
        // 1, 4, 7
        if (board[1] == board[4] && board[4] == board[7] && board[7] != 0)
            return board[7];
        // 2, 5, 8
        if (board[2] == board[5] && board[5] == board[8] && board[8] != 0)
            return board[8];

        // Diagonals
        // 0, 4, 8
        if (board[0] == board[4] && board[4] == board[8] && board[8] != 0)
            return board[0];
        // 2, 4, 6
        if (board[2] == board[4] && board[4] == board[6] && board[6] != 0)
            return board[2];


        return 0;
    }

    public int CurrentTurn { get; private set; }

    public bool AssignSlot (int playerIndex, int slotIndex)
    {
        // If it's not his turn return false
        if (CurrentTurn != playerIndex || CurrentTurn == 0)
            return false;

        if (board[slotIndex] == Defines.EMPTY_SLOT)
        {
            board[slotIndex] = playerIndex;
            SwitchTurn();
            return true;
        }

        return false;
    }

    private void SwitchTurn ()
    {
        int winner = GetWinner();

        
        if (winner == 0)
        {
            if (HasEmptySlot())
            {
                CurrentTurn = CurrentTurn == 1 ? Defines.PLAYER_2 : Defines.PLAYER_1;
            }
            else
            {
                CurrentTurn = 0;
                Debug.Log("Draw");
            }
        } else
        {
            CurrentTurn = 0;
            Debug.LogFormat("Winner: {0}", winner);
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CurrentTurn = Defines.PLAYER_1;
    }

    public static GameManager Instance { get; private set; }

}
