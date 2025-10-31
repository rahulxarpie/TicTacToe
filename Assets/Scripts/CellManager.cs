using UnityEngine;
using UnityEngine.UI;

public class CellManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image xImage;
    [SerializeField] private Image oImage;

    [SerializeField] private GameManager gameManager;

    private CellState currCellState = CellState.EMPTY;

    private void Awake()
    {
        xImage.gameObject.SetActive(false);
        oImage.gameObject.SetActive(false);

        button.interactable = true;
        button.onClick.AddListener(OnCellClicked);
    }

    private void OnCellClicked()
    {
        if (gameManager.currPlayer == PlayerType.PLAYER_X)
        {
            xImage.gameObject.SetActive(true);
            oImage.gameObject.SetActive(false);
            currCellState = CellState.X;
        }
        else
        {
            currCellState = CellState.O;
            oImage.gameObject.SetActive(true);
            xImage.gameObject.SetActive(false);
        }

        button.interactable = false;

        gameManager.OnACellClicked();
    }

    public CellState GetCellState() => currCellState;

    public void ResetForNewGame()
    {
        currCellState = CellState.EMPTY;
        xImage.gameObject.SetActive(false);
        oImage.gameObject.SetActive(false);
        button.interactable = true;
    }
}