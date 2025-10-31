using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerType currPlayer = PlayerType.PLAYER_X;

    public List<CellManager> row1;
    public List<CellManager> row2;
    public List<CellManager> row3;

    public GameOverManager gameOverManager;

    public GameState currGameState = GameState.ONGOING;

    public void OnACellClicked()
    {
        // 1. Check if any complete horizontal line is filled by X
        // 1.1. Is the top row all X
        if (row1[0].GetCellState() == CellState.X && row1[1].GetCellState() == CellState.X && row1[2].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }        // 1.2. Is the mid row all x
        else if (row2[0].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row2[2].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }
        // 1.3 Is the bottom row all x
        else if (row3[0].GetCellState() == CellState.X && row3[1].GetCellState() == CellState.X && row3[2].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }

        // 2. Check if any complete horizontal line is filled by O
        // 2.1. Is the top row all O
        else if (row1[0].GetCellState() == CellState.O && row1[1].GetCellState() == CellState.O && row1[2].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }
        // 2.2. Is the mid row all O
        else if (row2[0].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row2[2].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }
        // 2.3. Is the bottom row all O
        else if (row3[0].GetCellState() == CellState.O && row3[1].GetCellState() == CellState.O && row3[2].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }

        // 3. Check if any complete vertical line is filled by X
        // 3.1. Is left column all X
        else if (row1[0].GetCellState() == CellState.X && row2[0].GetCellState() == CellState.X && row3[0].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }
        // 3.2. Is mid column all X
        else if (row1[1].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row3[1].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }
        // 3.3. Is right column all X
        else if (row1[2].GetCellState() == CellState.X && row2[2].GetCellState() == CellState.X && row3[2].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }

        // 4. Check if any complete vertical line is filled by O
        // 4.1. Is left column all O
        else if (row1[0].GetCellState() == CellState.O && row2[0].GetCellState() == CellState.O && row3[0].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }
        // 4.2. Is mid column all O   
        else if (row1[1].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row3[1].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }
        // 4.3. Is right column all O 
        else if (row1[2].GetCellState() == CellState.O && row2[2].GetCellState() == CellState.O && row3[2].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }

        // 5. Check main diagonals all filled by X or O
        // 5.1. Is the diagonal (top-left to bottom-right) all X
        else if (row1[0].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row3[2].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }
        // 5.2. Is the diagonal (top-left to bottom-right) all O
        else if (row1[0].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row3[2].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }

        // 6. Check secondary diagonals all filled by X or O
        // 6.1. Is the diagonal (top-right to bottom-left) all X
        else if (row1[2].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row3[0].GetCellState() == CellState.X)
        {
            currGameState = GameState.X_WON;
        }
        // 6.2. Is the diagonal (top-right to bottom-left) all O
        else if (row1[2].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row3[0].GetCellState() == CellState.O)
        {
            currGameState = GameState.O_WON;
        }

        if (currGameState == GameState.X_WON)
        {
            Debug.Log("Game Ended. Player X Won");
            gameOverManager.ShowGameOver("Player X Won!");
            return;
        }
        else if (currGameState == GameState.O_WON)
        {
            Debug.Log("Game Ended. Player O Won");
            gameOverManager.ShowGameOver("Player O Won!");
            return;
        }

        // 7. are all cells filled? -> Draw
        bool isDraw = IsGameDraw();
        if (isDraw)
        {
            Debug.Log("Game Ended. It's a Draw");
            currGameState = GameState.DRAW;
            gameOverManager.ShowGameOver("It's a Draw!");
            return;
        }

        // 8. If NOT all cells are filled => then game continues => switch player
        if (currPlayer == PlayerType.PLAYER_X)
        {
            Debug.Log("Switching to Player O");
            currPlayer = PlayerType.PLAYER_O;
        }
        else
        {
            Debug.Log("Switching to Player X");
            currPlayer = PlayerType.PLAYER_X;
        }
    }

    private bool IsGameDraw()
    {
        bool allFilled = true;
        foreach (var cell in row1)
        {
            if (cell.GetCellState() == CellState.EMPTY)
                allFilled = false;
        }
        foreach (var cell in row2)
        {
            if (cell.GetCellState() == CellState.EMPTY)
                allFilled = false;
        }
        foreach (var cell in row3)
        {
            if (cell.GetCellState() == CellState.EMPTY)
                allFilled = false;
        }
        return allFilled; // if all filled, then draw
    }

    public void ResetForNextGame()
    {
        currGameState = GameState.ONGOING;
        // reset all grid to empty
        foreach (CellManager cell in row1)
            cell.ResetForNewGame();
        foreach (CellManager cell in row2)
            cell.ResetForNewGame();
        foreach (CellManager cell in row3)
            cell.ResetForNewGame();
    }
}
