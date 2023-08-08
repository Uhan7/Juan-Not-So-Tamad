using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFX : MonoBehaviour
{

    public float lifeTime;

    private void Start()
    {
        print("ded");
        Destroy(gameObject, lifeTime);
    }

}
