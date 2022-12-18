using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public static MapScroll instance;

    [SerializeField]
    float scrollSpeed = -1f;

    Rigidbody2D myRb;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        instance = this;
    }

    private void Update()
    {
        myRb.velocity = new Vector2(scrollSpeed, 0f);
    }

    public float GetScrollSpeed()
    {
        return scrollSpeed;
    }
}
