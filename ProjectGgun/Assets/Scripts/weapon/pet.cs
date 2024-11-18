using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Animator _anim;
    private bool _isPlaying = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            _isPlaying = !_isPlaying;           
            _anim.SetBool("shot", _isPlaying);
            Instantiate(_bullet, transform.position, transform.rotation);
        }
    }
}
