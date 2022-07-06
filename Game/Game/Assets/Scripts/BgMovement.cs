using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D bgCollider;
    float bgWidth;
    Vector3 bgOrigPos;
    void Start()
    {
        bgOrigPos = transform.position;
        bgCollider = gameObject.GetComponent<BoxCollider2D>();
        bgWidth = bgCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < bgCollider.size.x)
        {
            transform.position = bgOrigPos;
        }
    }
}
