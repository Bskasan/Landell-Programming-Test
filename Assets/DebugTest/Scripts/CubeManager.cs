using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject Cube;
    [SerializeField] private int _minRandomValue = 0;
    [SerializeField] private int _maxRandomValue = 500;

    private Random _random = new Random();

    private void Update()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        Instantiate(Cube, new Vector3(_random.Next(_minRandomValue, _maxRandomValue), _random.Next(_minRandomValue, _maxRandomValue), _random.Next(_minRandomValue, _maxRandomValue)), Quaternion.identity);
        Debug.Log("Coroutine working properly");

        yield return new WaitForFixedUpdate();
    }
}
