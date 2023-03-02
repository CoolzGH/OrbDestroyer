using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour
{
    float _orbSpeed;

    private void Start()
    {
        _orbSpeed = Random.Range(1.5f, 5f);
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, -_orbSpeed * Time.deltaTime, 0));
    }
}
