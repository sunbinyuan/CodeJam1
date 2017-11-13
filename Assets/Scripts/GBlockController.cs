using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBlockController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        EventManager.onPositionChange += ShiftPosition;

    }

    // Update is called once per frame
    void Update () {
		
	}

    void ShiftPosition(Vector3 position) {
        Vector2 thisPos = transform.position;
        if (position.x > thisPos.x + 6)
        {
            transform.position = new Vector3(thisPos.x + 14, thisPos.y);
        } else if (position.x < thisPos.x - 6)
        {
            transform.position = new Vector3(thisPos.x - 14, thisPos.y);
        }
    }

    void OnDisable()
    {
        EventManager.onPositionChange -= ShiftPosition;
    }

}
