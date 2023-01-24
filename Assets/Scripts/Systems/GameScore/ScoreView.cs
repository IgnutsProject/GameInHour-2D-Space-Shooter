using System;
using TMPro;
using UnityEngine;

namespace Systems.GameScore
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Awake()
        {
            ScoreManager.Instance.OnScoreChanged += score =>
            {
                scoreText.text = $"{score}";
            };
        }
    }
}
