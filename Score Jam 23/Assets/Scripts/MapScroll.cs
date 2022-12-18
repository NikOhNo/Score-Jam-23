using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public static MapScroll instance;

    [SerializeField]
    float characterScrollSpeed = -1f;

    [SerializeField]
    float backgroundScrollSpeed = 0.2f;

    private MeshRenderer myRenderer;
    private float timeElapsed = 0f;

    private void Start()
    {
        //myRb = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<MeshRenderer>();
        instance = this;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        myRenderer.material.mainTextureOffset = new Vector2(timeElapsed * backgroundScrollSpeed, 0f);
    }

    public float GetScrollSpeed()
    {
        return characterScrollSpeed;
    }
}
