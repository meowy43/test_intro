using UnityEngine;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        public Stick stick;
        public RhythmCheck rhythmCheck;

        private void FixedUpdate()
        {
            // if (Input.GetMouseButton(0))
            // {   
            //     PointerDown();
            // }
            // else
            // {
            //     PointerUp();
            // }
        }

        public void PointerDown()
        {
            stick.Down();
            rhythmCheck.InputDown();
        }

        public void PointerUp()
        {
            stick.Up();
            rhythmCheck.InputUp();
        }
    }
}