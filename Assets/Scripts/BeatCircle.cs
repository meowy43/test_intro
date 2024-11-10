using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class BeatCircle : MonoBehaviour
    {
        [SerializeField] private RhythmController rhythmController;
        private float timeToScroll;
        private Vector3 hitButtonPos;
        private Vector3 startPos;
        private float timer;

        void Start()
        {
            timeToScroll = rhythmController.timeToScroll;
            startPos = transform.position;
            hitButtonPos = rhythmController.hitButton.position;

        }


        void Update()
        {
            //transform.position += new Vector3(speed * bpm * (float)AudioSettings.dspTime, 0, 0);

            if (Vector3.Distance(transform.position, hitButtonPos) > 0.01f)
            {
                float step = timer / timeToScroll;
                transform.position = Vector3.Lerp(startPos, hitButtonPos, step);
            }
            else
            {
                Destroy(gameObject, 0.1f);
            }
            timer += Time.deltaTime;
        }

    }
}
