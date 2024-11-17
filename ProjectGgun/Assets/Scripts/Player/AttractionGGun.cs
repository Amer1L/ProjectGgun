using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttractionGGun : MonoBehaviour
{
    [SerializeField] private Transform _gravityZone;
    [SerializeField] private float _GForce;
    [SerializeField] public Animator _rightButtonAnim;
    [SerializeField] public Animator _atracctionActive;
    public List<Rigidbody> _rbInZone;
    public bool _GGunActive = false;

    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            _GGunActive = !_GGunActive;
            _rightButtonAnim.SetBool("RB_active", _GGunActive);
            _atracctionActive.SetBool("A_active", _GGunActive);
        }

        if (_GGunActive)
        {
            Debug.Log("[");
            for (int i = 0; i < _rbInZone.Count; i++)
            {
                Debug.Log(_rbInZone[i].gameObject.name);
            }
            Debug.Log("]");
            _gravityZone.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            for (int i = 0; i < _rbInZone.Count; i++)
            {
                _rbInZone.RemoveAt(i);
            }
            _gravityZone.localScale = new Vector3(0, 0, 0);
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (_GGunActive)
        {

            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 vecGravity = (_gravityZone.position - rb.position).normalized;
            float distance = Vector3.Distance(_gravityZone.position, rb.transform.position);
            if (rb != null)
            {
                rb.AddForce((vecGravity * _GForce * rb.mass * distance) / 4);
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
                int a = 0;
                for (int i = 0; i < _rbInZone.Count; i++)
                {
                    if (_rbInZone[i].gameObject == rb.gameObject)
                    {
                        ++a;
                    }
                }
                if (a == 0)
                {
                    _rbInZone.Add(rb);
                }
                rb.useGravity = false;
                rb.AddForce(vecGravity * _GForce * rb.mass * -1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 vecGravity = (_gravityZone.position - rb.position).normalized;
        if (rb != null)
        {
            for (int i = 0; i < _rbInZone.Count; i++)
            {
                if (_rbInZone[i].gameObject == rb.gameObject)
                {
                    _rbInZone.RemoveAt(i);
                }
            }
            rb.velocity = rb.velocity / 2;
            if (_GGunActive)
            {
                rb.AddForce(vecGravity * _GForce * rb.mass);
            }

            rb.useGravity = true;
        }
    }
}
