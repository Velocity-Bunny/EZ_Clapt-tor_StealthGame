using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersAndContacts : PlayerControl
{

    protected void OnCollisionEnter(Collision _collision)
    {
        if(_collision.collider.CompareTag("Ground"))
            isGrounded = true;
        else
            isGrounded = false;

        

    }


}
