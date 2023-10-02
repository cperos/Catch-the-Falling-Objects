using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float timeToLive;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Destroy(gameObject, timeToLive);
    }
}
