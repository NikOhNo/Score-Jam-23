using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    Animator myAnim;
    Collider2D myCollider;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>(); 
    }

    public void BreakPlatform()
    {
        myCollider.enabled = false;
        myAnim.SetBool("Break", true);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
