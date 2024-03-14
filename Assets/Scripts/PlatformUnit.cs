using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUnit : MonoBehaviour
{
    public GameObject coin;
    public Transform hinge;
    public Renderer plane;

    void Awake()
    {
        Initialize();
    }

    void Initialize()
    {
        plane.transform.localScale = Vector3.one;

        float unit = 10;

        hinge.localPosition = Vector3.back * unit;

        plane.transform.parent = hinge;

        hinge.localPosition = Vector3.zero;

    }

    void Enabled(bool on)
    {
        coin.SetActive(on);
    }

    private void OnTriggerExit(Collider other)
    {
        PlatformMng.ins.updateList(this, true);

        Enabled(false);
    }

    public void Set(Vector3 posOfLastPlatform, Vector3 directionOfLastPlatform)
    {
        transform.position = posOfLastPlatform;
        Enabled(true);
        RandomRotation(directionOfLastPlatform);
    }

    void RandomRotation(Vector3 direcitonOfLastPlatform)
    {
        List<Vector3> directionsAvailable = new List<Vector3>();

        directionsAvailable.Add(Vector3.zero);
        directionsAvailable.Add(Vector3.up * 90);
        directionsAvailable.Add(Vector3.up * 270);

        if (direcitonOfLastPlatform == new Vector3(0, 90, 0))
        {
            directionsAvailable.RemoveAt(1);
        }
        else if (direcitonOfLastPlatform == new Vector3(0, 270, 0))
        {
            directionsAvailable.RemoveAt(2);
        }

        int index = Random.Range(0, directionsAvailable.Count);
        Vector3 directionOfThisPlatform = directionsAvailable[index];

        transform.localEulerAngles = directionOfThisPlatform;
    }
}
