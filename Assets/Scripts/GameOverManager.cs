using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject view;
    public TextMeshProUGUI winnerText;

    public Button replayButton;

    public GameManager gameManager;

    private void Awake()
    {
        view.SetActive(false);
        replayButton.onClick.AddListener(OnReplayClicked);
    }

    public void ShowGameOver(string textToShow)
    {
        view.SetActive(true);
        winnerText.text = textToShow;
    }

    private void OnReplayClicked()
    {
        gameManager.ResetForNextGame();
        view.SetActive(false);
    }
}