using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _orbs = new GameObject[5];
    [SerializeField] Camera _mainCam;
    Vector3 _screenBounds;
    float _screenBoundsX;
    float _screenBoundsY;
    float _screenBoundsZ = 0;
    //float _minSpawnRepeatRate;
    //float _maxSpawnRepeatRate;
    float _SpawnRepeatRate = 1;
    float _SpawnStartDelayTime = 1;

    void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _screenBounds = _mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _screenBoundsZ));
        _screenBoundsX = Mathf.Abs(_screenBounds.x) - 1;
        _screenBoundsY = Mathf.Abs(_screenBounds.y) - 1;
        InvokeRepeating("SpawnOrb", _SpawnStartDelayTime, _SpawnRepeatRate);
    }

    void SpawnOrb()
    {
        Instantiate(_orbs[Random.Range(0, 4)], 
                    transform.position = new Vector3(Random.Range(-_screenBoundsX, _screenBoundsX), Random.Range(-_screenBoundsY + 5, _screenBoundsY), 2), transform.rotation);
    }
}
