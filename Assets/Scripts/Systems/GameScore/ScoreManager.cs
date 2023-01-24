using System;
using UnityEngine;

namespace Systems.GameScore
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        
        private int _score = 0;

        public delegate void ScoreChanged(int score);
        public event ScoreChanged OnScoreChanged;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;

                if (_score <= 0)
                {
                    _score = 0;
                }
                OnScoreChanged?.Invoke(_score);
            }
        }
    }
}
