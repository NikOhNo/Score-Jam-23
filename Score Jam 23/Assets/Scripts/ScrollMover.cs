using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMover : MonoBehaviour
{
    Rigidbody2D myRb;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRb.velocity = new Vector2(MapScroll.instance.GetScrollSpeed(), myRb.velocity.y);
    }
}
