using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    [SerializeField]
    private FreeCamera freeCamera;

    // Update is called once per frame
    void Update()
    {
        if (!UI.activeSelf && )
        {
            freeCamera.Move();
        }
    }
}
