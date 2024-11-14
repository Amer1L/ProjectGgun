using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class observer : MonoBehaviour
{
    [SerializeField] private Transform _folower;
    private void Update()
    {
        transform.LookAt(_folower);
    }
}
