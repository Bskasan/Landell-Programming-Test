using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CubeMovement : MonoBehaviour
{

    [SerializeField] private int _forceValue = 5;
    [SerializeField] private float _forceValueForFasterSpawning = 300f;

    private Rigidbody _rb;
    private RaycastHit _hitInfo;
    private Random _random = new Random();
    private Ray _ray;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _ray = new Ray(transform.position, Vector3.forward);
        Debug.Log($"{this.tag}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Space working");
            _rb.AddForce(new Vector3(0, _forceValueForFasterSpawning, 0));
        }
        else
        {
            _rb.AddForce(new Vector3(_random.Next(-_forceValue, _forceValue), _random.Next(-_forceValue, _forceValue), _random.Next(-_forceValue, _forceValue)));
        }
        

        // ------------------ Problem Here ------------------------- //
        bool isHitting = Physics.SphereCast(_ray, 5, out _hitInfo);
        
        if (isHitting)
        {
            Debug.Log($"{this.tag} and {isHitting}");
            Destroy(this);
        } 
        
    }

    // OnDrawGizmos or OnDrawGizmosSelected
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.forward * 5, 5);
    }

}
