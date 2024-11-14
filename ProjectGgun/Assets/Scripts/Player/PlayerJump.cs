using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private Rigidbody _rb;
    private bool _graunded;

    private void OnCollisionEnter()
    {
        _graunded = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _graunded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, _jumpForce, 0));
        _graunded = false;
    }
}
