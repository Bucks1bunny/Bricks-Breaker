using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [field: SerializeField]
    public TextMeshProUGUI HighScoreText
    {
        get;
        private set;
    }
    [field: SerializeField]
    public TextMeshProUGUI ScoreText
    {
        get;
        private set;
    }
    [field: SerializeField]
    public TextMeshProUGUI LivesText
    {
        get;
        private set;
    }
}
