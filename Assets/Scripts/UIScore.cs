
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    
    void Update()
    {
        ScoreText.text = TokenBehavior.Score.ToString();
    }
}
