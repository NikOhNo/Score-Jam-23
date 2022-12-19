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

    Material material;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        instance = this;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        material.mainTextureOffset = new Vector2(timeElapsed * backgroundScrollSpeed, 0f);
    }

    public float GetScrollSpeed()
    {
        return characterScrollSpeed;
    }
}
