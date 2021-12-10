using TMPro;
using UnityEngine;

public class MenuCanvasController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField playerNameInput;

    public void SetBestScore(int score)
    {
        this.bestScoreText.text = "Best score: " + score;
    }

    public void SetPlayerName(string name)
    {
        this.playerNameInput.text = name;
    }

    public string GetPlayerName()
    {
        return this.playerNameInput.text;
    }
}
