using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerType currPlayer = PlayerType.PLAYER_X;

    public List<CellManager> row1;
    public List<CellManager> row2;
    public List<CellManager> row3;

    public GameState currGameState = GameState.ONGOING;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnACellClicked()
    {
        // We check, if game is ENDED or NOT

        // 1. Check if any complete horizontal line is filled by X
        // 1.1. Is the top row all X
        if (row1[0].GetCellState() == CellState.X && row1[1].GetCellState() == CellState.X && row1[2].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }
        // 1.2. Is the mid row all x
        if (row2[0].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row2[2].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }
        // 1.3 Is the bottom row all x
        if (row3[0].GetCellState() == CellState.X && row3[1].GetCellState() == CellState.X && row3[2].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }

        // 2. Check if any complete horizontal line is filled by O
        // 2.1. Is the top row all O
        if (row1[0].GetCellState() == CellState.O && row1[1].GetCellState() == CellState.O && row1[2].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }
        // 2.2. Is the mid row all O
        if (row2[0].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row2[2].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }
        // 2.3. Is the bottom row all O
        if (row3[0].GetCellState() == CellState.O && row3[1].GetCellState() == CellState.O && row3[2].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }

        // 3. Check if any complete vertical line is filled by X
        // 3.1. Is left column all X
        if (row1[0].GetCellState() == CellState.X && row2[0].GetCellState() == CellState.X && row3[0].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }
        // 3.2. Is mid column all X
        if (row1[1].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row3[1].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }
        // 3.3. Is right column all X
        if (row1[2].GetCellState() == CellState.X && row2[2].GetCellState() == CellState.X && row3[2].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }

        // 4. Check if any complete vertical line is filled by O
        // 4.1. Is left column all O
        if (row1[0].GetCellState() == CellState.O && row2[0].GetCellState() == CellState.O && row3[0].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }
        // 4.2. Is mid column all O   
        if (row1[1].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row3[1].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }
        // 4.3. Is right column all O 
        if (row1[2].GetCellState() == CellState.O && row2[2].GetCellState() == CellState.O && row3[2].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }

        // 5. Check main diagonals all filled by X or O
        // 5.1. Is the diagonal (top-left to bottom-right) all X
        if (row1[0].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row3[2].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }
        // 5.2. Is the diagonal (top-left to bottom-right) all O
        if (row1[0].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row3[2].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }

        // 6. Check secondary diagonals all filled by X or O
        // 6.1. Is the diagonal (top-right to bottom-left) all X
        if (row1[2].GetCellState() == CellState.X && row2[1].GetCellState() == CellState.X && row3[0].GetCellState() == CellState.X)
        {
            Debug.Log("Game Ended. Winner is X");
            currGameState = GameState.X_WON;
            return;
        }
        // 6.2. Is the diagonal (top-right to bottom-left) all O
        if (row1[2].GetCellState() == CellState.O && row2[1].GetCellState() == CellState.O && row3[0].GetCellState() == CellState.O)
        {
            Debug.Log("Game Ended. Winner is O");
            currGameState = GameState.O_WON;
            return;
        }

        // 7. are all cells filled? -> Draw
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
        if (allFilled)
        {
            Debug.Log("Game Ended. It's a Draw");
            currGameState = GameState.DRAW;
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
}
