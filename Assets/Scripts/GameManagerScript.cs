using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private int playerNo;
    private int[] board = { -1, -1, -1, -1, -1, -1, -1, -1, -1};

    public Button[] cells;

    public void SelectCell(int index)
    {
        board[index] = playerNo;

        cells[index].transform.GetChild(playerNo).gameObject.SetActive(true);
        cells[index].interactable = false;

        if (checkWin(playerNo))
        {
            Debug.Log("player " + playerNo + " won");
        }
        if (checkDraw())
        {
            Debug.Log("dra3w");
        }

        playerNo++;
        if (playerNo >= 2) playerNo = 0;
    }

    private int[][] winConditions = new int[][]
    {
        new int[] {0, 1, 2},
        new int[] {3, 4, 5},
        new int[] {6, 7, 8},
        new int[] {0, 3, 6},
        new int[] {2, 5, 8},
        new int[] {1, 4, 7},
        new int[] {2, 4, 6},
        new int[] {0, 4, 8},
    };

    private bool checkWin(int playerIndex)
    {
        foreach(var conditon in winConditions)
        {
            if(board[conditon[0]] == playerIndex && board[conditon[1]] == playerIndex && board[conditon[2]] == playerIndex)
                return true;
        }
        return false;
    }

    private bool checkDraw()
    {
        foreach(int cell in board)
        {
            if (cell == -1) return false;
        }
        return true;
    }
}
