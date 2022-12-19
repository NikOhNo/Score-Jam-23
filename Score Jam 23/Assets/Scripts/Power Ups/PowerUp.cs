using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    Sprite powerUpIcon;

    [SerializeField]
    public float powerUpDuration;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = powerUpIcon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BeginEffect();
        }
    }

    public virtual void BeginEffect()
    {
        Destroy(gameObject);
    }
}
