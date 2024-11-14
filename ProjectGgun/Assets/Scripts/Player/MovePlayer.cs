using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private float _moveSpeed;
    private float _frozenMeaningMoveSpeed;




    private void Update()
    {



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _moveSpeed = _moveSpeed * 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _moveSpeed = _moveSpeed / 2;
        }

        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));

        transform.Translate(_moveSpeed * direction * Time.deltaTime);
    }

}
