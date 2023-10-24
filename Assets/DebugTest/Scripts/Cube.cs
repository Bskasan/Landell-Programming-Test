using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _destroyInSeconds = 1f;

    void Start()
    {
        Destroy(gameObject, _destroyInSeconds);
    }
}
