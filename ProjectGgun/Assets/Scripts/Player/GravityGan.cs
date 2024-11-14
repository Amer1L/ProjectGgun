using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityGan : MonoBehaviour
{
    [SerializeField] private Transform _gravityZone;
    [SerializeField] private float _GForce;
    private bool _GGunActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _GGunActive = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _GGunActive = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_GGunActive)
        {

            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 vecGravity = (_gravityZone.position - rb.position).normalized;
            if (rb != null)
            {
                rb.AddForce((vecGravity * _GForce * rb.mass) / 4);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (_GGunActive)
        {
            Vector3 vecGravity = (_gravityZone.position - rb.position).normalized;
            if (rb != null)
            {
                rb.useGravity = false;
                rb.AddForce(vecGravity * _GForce * rb.mass * -1);
                rb.transform.rotation = Quaternion.identity;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 vecGravity = (_gravityZone.position - rb.position).normalized;
        if (rb != null)
        {
            if (_GGunActive)
            {
                rb.AddForce(vecGravity * _GForce * rb.mass * 3);
            }

            rb.useGravity = true;
        }
    }
}
