using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpChecker : MonoBehaviour
{
    bool canJump = false;

    public bool GetCanJump()
    {
        return canJump;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Jumpable" || other.tag == "Goomba")
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Jumpable" || other.tag == "Goomba")
        {
            canJump = false;
        }
    }
}
