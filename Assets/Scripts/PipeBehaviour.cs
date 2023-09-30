using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    private float countdown = 1.0f;  // TODO: randomize range
    [SerializeField] private bool isActive = false;

    public void Activate()
    {
        // Calls SpawnObject after 5 seconds
        Invoke("SpawnObject", countdown);
        isActive = true;
    }

    public void Deactivate()
    {
        isActive = false;
    }


    private void SpawnObject()
    {
        Debug.Log("beep");
        if (isActive)
        {
            Invoke("SpawnObject", countdown);
        }
    }

}
