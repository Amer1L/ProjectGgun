using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGGun : MonoBehaviour
{
    [SerializeField] private Transform _collider;
    [SerializeField] private float _force;
    [SerializeField] private AttractionGGun _AGG;
    [SerializeField] public Animator _leftButtonAnim;
    [SerializeField] public Animator _atracctionActive;
    [SerializeField] private float _delayConst;
    private float _delay;
    private bool _GGunShot = false;
    private bool _coolDown = false;

    private void Start()
    {
        _delay = _delayConst;
    }

    void Update()
    {
        _atracctionActive.SetBool("S_active", _GGunShot);

        if (Input.GetMouseButtonDown(0))
        {
            _GGunShot = true;
            _coolDown = true;
            _leftButtonAnim.SetBool("LB_active", true);
        }

        if(_coolDown && _delay > 0)
        {
            _delay -= Time.deltaTime;
        }
        if(_delay <= 0)
        {
            _coolDown = false;
            _GGunShot = false;
            _delay = _delayConst;
            _leftButtonAnim.SetBool("LB_active", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {


            Rigidbody rb = other.GetComponent<Rigidbody>();
            Vector3 vecGravity = (_collider.position - rb.position).normalized;
            if (rb != null)
            {
                if (_GGunShot)
                {
                    _AGG._GGunActive = false;
                    _AGG._rightButtonAnim.SetBool("RB_active", false);
                    _atracctionActive.SetBool("A_active", false);
                    rb.AddForce(_collider.forward.normalized * _force * rb.mass * -1);
                }
            }
 

    }
}
