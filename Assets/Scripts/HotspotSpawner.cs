using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotSpawner : MonoBehaviour
{

    public int hotspotCount;
    public float oneBarCount;

    public GameObject spawner;

    public GameObject[] hotspot;
    public GameObject[] preHotspot;

    public int[] wave;
    public int[] loc;

    void Start()
    {

        var location = new int[9];

        location[0] = -146;
        location[1] = -110;
        location[2] = - 74;
        location[3] = -37;
        location[4] = 0;
        location[5] = 37;
        location[6] = 74;
        location[7] = 110;
        location[8] = 146;

        var count = 0;
        while (count < wave.Length)
        {
            StartCoroutine(SpawnPreHotSpots(wave[count]-1, location[loc[count]]));
            StartCoroutine(SpawnHotSpots(wave[count], location[loc[count]]));
            count++;
        }

    }

    IEnumerator SpawnPreHotSpots(int time, float pos)
    {
        yield return new WaitForSeconds(oneBarCount * time);
        GameObject Prehotspot;
        if (pos <= -146)
        {
            Prehotspot = Instantiate(preHotspot[0]);
        }
        else if (pos >= 146)
        {
            Prehotspot = Instantiate(preHotspot[2]);
        }
        else
        {
            Prehotspot = Instantiate(preHotspot[1]);
        }
        Prehotspot.transform.SetParent(spawner.transform, false);
        Prehotspot.transform.localPosition = new Vector2(pos, transform.position.y-162);

        yield return null;
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
        Hotspot.transform.localPosition = new Vector2(pos, transform.position.y - 162);

        yield return null;
    }
}
