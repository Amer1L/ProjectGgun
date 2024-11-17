using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private AttractionGGun _AGG;
    [SerializeField] private GameObject[] _Weapon;
    [SerializeField] private int changeSlot = 2;

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            switch (changeSlot)
            {
                case 1:
                    for (int i = 0; i < _AGG._rbInZone.Count; i++)
                    {
                        _AGG._rbInZone[i].useGravity = true;
                        _AGG._rbInZone.RemoveAt(i);
                    }
                    _AGG._GGunActive = false;
                    changeSlot = 2;
                    break;
                case 2:
                    changeSlot = 3;
                    break;
                case 3:
                    changeSlot = 1;
                    break;
            }
            RenderChangeSlots();
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            switch (changeSlot)
            {
                case 1:
                    for (int i = 0; i < _AGG._rbInZone.Count; i++)
                    {
                        _AGG._rbInZone[i].useGravity = true;
                        _AGG._rbInZone.RemoveAt(i);
                    }
                    _AGG._GGunActive = false;
                    changeSlot = 3;
                    break;
                case 2:
                    changeSlot = 1;
                    break;
                case 3:
                    changeSlot = 2;
                    break;
            }
            RenderChangeSlots();
        }
    }

    private void RenderChangeSlots()
    {
        for (int i = 0; i < _Weapon.Length; i++)
        {
            if (i == changeSlot - 1)
            {
                _Weapon[i].SetActive(true);
            }
            if (i != changeSlot - 1)
            {
                _Weapon[i].SetActive(false);
            }
        }
    }
}
