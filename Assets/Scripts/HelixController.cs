using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    public Vector2 lastTapPos;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 curTapPos = Input.mousePosition;
            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = curTapPos;
            }
            float delta = lastTapPos.x - curTapPos.x;
            lastTapPos = curTapPos;
            transform.Rotate(Vector3.up * delta * speed);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }
}
