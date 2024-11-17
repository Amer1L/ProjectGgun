using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class cameraRoom : MonoBehaviour
{
    [SerializeField] private GameObject _camera1Weapon;
    [SerializeField] private GameObject _camera2;
    [SerializeField] private PostProcessVolume _PPVolume;
    [SerializeField] private PostProcessProfile _PPProfile1;
    [SerializeField] private PostProcessProfile _PPProfile2;
    private bool _cameraPlayer = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _cameraPlayer = !_cameraPlayer;
            if (_cameraPlayer)
            {
                _camera1Weapon.SetActive(true);
                _camera2.SetActive(false);
                _PPVolume.profile = _PPProfile1;
            }
            else
            {
                _camera1Weapon.SetActive(false);
                _camera2.SetActive(true);
                _PPVolume.profile = _PPProfile2;
            }
        }
    }
}
