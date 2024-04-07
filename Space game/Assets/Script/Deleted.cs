using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleted : MonoBehaviour
{
    [SerializeField]private PlayerControl _playerControl;

  

    void Update()
    {
        if(transform.position.y < -12)
        {
            _playerControl.ChangeScore(1);
            Destroy(gameObject); 
        }       
    }
}
