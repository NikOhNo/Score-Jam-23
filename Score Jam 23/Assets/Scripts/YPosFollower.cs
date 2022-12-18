using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPosFollower : MonoBehaviour
{
    [SerializeField]
    float minYPos = 0f;

    [SerializeField]
    float maxYPos = Mathf.Infinity;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;

        transform.position = new Vector3(playerPos.x, Mathf.Clamp(playerPos.y, minYPos, maxYPos), playerPos.z);
    }
}
