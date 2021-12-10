using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private Button startButton;

    private void Start()
    {
        this.playerNameInput.onValueChanged.AddListener(this.OnPlayerNameInputChange);
    }

    public void SetBestScore(int score)
    {
        this.bestScoreText.text = "Best score: " + score;
    }

    public void SetPlayerName(string name)
    {
        this.playerNameInput.text = name;
        this.OnPlayerNameInputChange(name);
    }

    public string GetPlayerName()
    {
        return this.playerNameInput.text;
    }

    private void OnPlayerNameInputChange(string value)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            this.startButton.enabled = false;
        }
        else
        {
            this.startButton.enabled = true;
        }
    }
}
