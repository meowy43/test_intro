using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameInstance : MonoBehaviour
    {
        public static int score = 515;

        public Transform states;

        private void OnEnable()
        {
            score = PlayerPrefs.GetInt("TopScore");
        }

        public void OnDisable()
        {
            PlayerPrefs.SetInt("TopScore", score);
        }

        private void Start()
        {
            foreach (Transform child in states)
            {
                child.gameObject.SetActive(false);
            }
            PlayerPrefs.SetInt("TopScore", 515);

            states.GetChild(0).gameObject.SetActive(true);
        }
    }
}
