using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    Vector3 position = new Vector3 (0, 0, 0);
    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal"); // the horizontal axis (arrow, a,d, joystick ets...)
        Debug.Log($"The Horizontal axis is {horizontalSpeed}");
        position.x += horizontalSpeed * speed * Time.deltaTime;
        position.y = 0;
        position.z = 0;


        transform.position = position;

    }
}
