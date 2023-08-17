using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotSpawner : MonoBehaviour
{

    public int hotspotCount;
    public float oneBarCount;

    public GameObject spawner;

    public GameObject[] hotspot;

    void Start()
    {
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(0, 146));
        StartCoroutine(SpawnHotSpots(8, 146));
        StartCoroutine(SpawnHotSpots(8, 146));
        StartCoroutine(SpawnHotSpots(8, 146));
        StartCoroutine(SpawnHotSpots(8, 146));
        StartCoroutine(SpawnHotSpots(8, 146));
        StartCoroutine(SpawnHotSpots(8, 146));
        StartCoroutine(SpawnHotSpots(16, 146));
        StartCoroutine(SpawnHotSpots(16, 146));
        StartCoroutine(SpawnHotSpots(24, 146));
        StartCoroutine(SpawnHotSpots(24, 146));
        StartCoroutine(SpawnHotSpots(24, 146));
    }

    IEnumerator SpawnHotSpots(int time, float pos)
    {
        yield return new WaitForSeconds(oneBarCount * time);
        GameObject Hotspot;
        if (pos <= -146)
        {
            Hotspot = Instantiate(hotspot[0]);
        }
        else if (pos >= 146)
        {
            Hotspot = Instantiate(hotspot[2]);
        }
        else
        {
            Hotspot = Instantiate(hotspot[1]);
        }
        Hotspot.transform.SetParent(spawner.transform, false);
        Hotspot.transform.localPosition = new Vector2(pos, transform.position.y-162);

        print("boom");

        yield return null;
    }
}
