using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotational : MonoBehaviour
{
    float PlanetRotateSpeed = -25f;
    float OrbitSpeed  = 10f;
    void Update() {
        // planet to spin on it's own axis
        transform.Rotate(transform.up * PlanetRotateSpeed * Time.deltaTime);
     
        // planet to travel along a path that rotates around the sun
        transform.RotateAround (Vector3.zero, Vector3.up, OrbitSpeed * Time.deltaTime);
    }
}
