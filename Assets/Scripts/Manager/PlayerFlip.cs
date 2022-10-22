using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public bool IsRight { get; set; } = true;
    Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = gameObject.transform.position;
        if ((position.x > previousPosition.x && !IsRight) || (position.x < previousPosition.x && IsRight))
        {
            ChangeDirection();
        }

        previousPosition = position;
    }


    public void ChangeDirection()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        IsRight = !IsRight;
    }
}
