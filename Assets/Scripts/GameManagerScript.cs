using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    private int playerNo;
    private int[] board = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };

    public Button[] cells;
    public GameObject[] resultPanel, playerWinShow, winLineShow;

    public void SelectCell(int index)
    {
        board[index] = playerNo;

        cells[index].transform.GetChild(playerNo).gameObject.SetActive(true);
        cells[index].interactable = false;

        int winIndex = checkWin(playerNo);
        if (winIndex != -1)
        {
            resultPanel[1].SetActive(true);
            playerWinShow[playerNo].SetActive(true);
            winLineShow[winIndex].SetActive(true);
            return;
        }

        if (checkDraw())
        {
            resultPanel[0].SetActive(true);
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
        new int[] {1, 4, 7},
        new int[] {2, 5, 8},
        new int[] {0, 4, 8},
        new int[] {2, 4, 6},
    };

    private int checkWin(int playerIndex)
    {
        for (int i = 0; i < winConditions.Length; i++)
        {
            int[] condition = winConditions[i];
            if (board[condition[0]] == playerIndex &&
                board[condition[1]] == playerIndex &&
                board[condition[2]] == playerIndex)
            {
                return i;
            }
        }
        return -1;
    }

    private bool checkDraw()
    {
        foreach (int cell in board)
        {
            if (cell == -1) return false;
        }
        return true;
    }

    public void playAgain()
    {
        PlayerPrefs.SetInt("flagged", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }
}
