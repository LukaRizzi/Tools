using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpot : MonoBehaviour
{
    [SerializeField] private Transform rotation;
    public bool followPlayer = false;
    public int priority = 0;

    public void TriggerPerspective()
    {
        Camera.main.transform.position = transform.position;
        Camera.main.transform.rotation = rotation.rotation;
    }
}
