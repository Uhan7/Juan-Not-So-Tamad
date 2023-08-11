using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{

    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
