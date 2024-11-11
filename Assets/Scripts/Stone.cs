using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public bool isDirty = false;
        private void OnCollisionEnter(Collision other)
        {
            if (isDirty)
            {
                Destroy(gameObject, 6f);
                return;
            }

            // if (other.gameObject.GetComponent<Stone>())
            // {
            //     onCollisionStone?.Invoke();
            // }
        }
    }
}
