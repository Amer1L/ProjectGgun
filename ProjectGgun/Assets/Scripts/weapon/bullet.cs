using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float _speed = 0.3f;
    private float _lifeTime = 2;

    private void OnTriggerEnter(Collider other)  
    {   
        Rigidbody rbBullet = gameObject.GetComponent<Rigidbody>();
        rbBullet.velocity = new Vector3(0, 0, 700);
        Rigidbody rb = other.GetComponent<Rigidbody>(); 
        if(rb != null)
        {
            rbBullet.velocity = new Vector3(0, 0, 0);
            rb.AddForce(transform.forward.normalized * 1000);
        }

        Destroy(gameObject);
    }   

    void Update()
    {
        transform.Translate(0, 0, _speed);
        if(_lifeTime > 0)
        {
            _lifeTime -= Time.deltaTime;
        }
        if(_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
