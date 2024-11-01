using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        private void Down()
        {

        }
        private void Up()
        {

        }
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other, this);
        }

    }
}
