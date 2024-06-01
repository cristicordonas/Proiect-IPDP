using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1.3f; // speed of the rotation, can be changed in the inspector
    private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); // rotate the object around the z-axis (forward axis) with the given speed, time.deltaTime is used to make the rotation frame rate independent
    }
}
