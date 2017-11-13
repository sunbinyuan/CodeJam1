using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectController : MonoBehaviour
{

    void Start()
    {
        EventManager.onPositionChange += ShiftPosition;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShiftPosition(Vector3 position)
    {
        Vector2 thisPos = transform.position;
        if (position.x > thisPos.x + 5)
        {
            transform.position = new Vector3(thisPos.x + 13, thisPos.y);
        }
        else if (position.x < thisPos.x - 5)
        {
            transform.position = new Vector3(thisPos.x - 13, thisPos.y);
        }
    }

    void OnDisable()
    {
        EventManager.onPositionChange -= ShiftPosition;
    }
}
