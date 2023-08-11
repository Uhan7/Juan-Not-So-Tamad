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
        StartCoroutine(SpawnHotSpots(1, 5, 160));
        StartCoroutine(SpawnHotSpots(1, 7, 234));
        StartCoroutine(SpawnHotSpots(1, 8, 270));
    }

    IEnumerator SpawnHotSpots(int type, int time, float pos)
    {
        yield return new WaitForSeconds(oneBarCount * time);
        var Hotspot = Instantiate(hotspot[type]) as GameObject;
        GameObject HotspotHitbox = Hotspot.transform.GetChild(0).gameObject;
        Hotspot.transform.SetParent(spawner.transform, false);
        Hotspot.transform.position = new Vector2(pos, transform.position.y-72);
        yield return new WaitForSeconds(oneBarCount * time + 2);
        Destroy(HotspotHitbox);
        yield return new WaitForSeconds(0.05f);
        Destroy(Hotspot);
    }
}
