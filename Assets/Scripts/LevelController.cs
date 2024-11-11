using System;
using System.Collections;
using System.Collections.Generic;
using Golf;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public Stick stick;
        public StoneSpawner stoneSpawner;
        public RatingSpawner ratingSpawner;
        public RhythmCheck rhythmCheck;
        public RhythmController rhythmController;
        private float m_timer;
        [SerializeField]
        private int m_score = 0;

        private List<Stone> m_stones = new List<Stone>();

        public event Action<int> onGameEnd;
        public event Action<int> onScoreInc;

        public void OnEnable()
        {
            //m_timer = AudioSettings.dspTime - m_delay;
            //stick.onCollisionStick += OnCollisionStick;
            rhythmCheck.onBeatBad += OnBeatBad;
            rhythmCheck.onBeatGood += OnBeatGood;
            rhythmCheck.onBeatMid += OnBeatMid;
            rhythmController.OnBeatStoneSync += OnBeatStoneSync;
            rhythmController.OnMusicEnd += OnMusicEnd;

            m_score = 0;

            ClearStones();
        }

        private void OnDisable()
        {
            // if (stick)
            // {
            //     //stick.onCollisionStick -= OnCollisionStick;
            // }
            if (rhythmCheck)
            {
                rhythmCheck.onBeatBad -= OnBeatBad;
                rhythmCheck.onBeatGood -= OnBeatGood;
                rhythmCheck.onBeatMid -= OnBeatMid;
            }
            if (rhythmController)
            {
                rhythmController.OnBeatStoneSync -= OnBeatStoneSync;
                rhythmController.OnMusicEnd -= OnMusicEnd;
            }
        }

        private void ClearStones()
        {
            foreach (var stone in m_stones)
            {
                Destroy(stone.gameObject);
            }

            m_stones.Clear();
        }

        private void OnBeatStoneSync()
        {
            var go = stoneSpawner.Spawn();
            var stone = go.GetComponent<Stone>();
            //stone.onCollisionStone += OnCollisionStone;
            m_stones.Add(stone);
        }

        // private void OnCollisionStick()
        // {
        //     m_score++; 
        //     Debug.Log($"score: {m_score}");
        //     onScoreInc?.Invoke(m_score);
        // }
        private void OnBeatGood()
        {
            m_score+=10; 
            Debug.Log($"Good! score: {m_score}");
            ratingSpawner.Spawn(0);
            onScoreInc?.Invoke(m_score);
        }
        private void OnBeatMid()
        {
            m_score+=5; 
            Debug.Log($"Eh.. score: {m_score}");
            ratingSpawner.Spawn(1);
            onScoreInc?.Invoke(m_score);
        }
        private void OnBeatBad()
        {
            m_score-=5; 
            Debug.Log($"Bad! score: {m_score}");
            ratingSpawner.Spawn(2);
            onScoreInc?.Invoke(m_score);
        }

        private void OnMusicEnd()
        {
            Debug.Log("GAME END");
            onGameEnd?.Invoke(m_score);
        }
    }
}