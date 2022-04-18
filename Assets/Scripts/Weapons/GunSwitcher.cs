using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct GunData
{
    public GameObject gun;
    public bool isEquipped;
}
public class GunSwitcher : MonoBehaviour
{
    public GunData[] gunDatas;

    private void Update()
    {
        for (int i = 0; i < gunDatas.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)&&gunDatas[i].isEquipped)
            {
                SelectGun(i);
                break;
            }
        }
    }

    public bool IsPickUpGun(int gunIndex) => !gunDatas[gunIndex].isEquipped;

    public void PickUpGun(int gunIndex)
    {
        gunDatas[gunIndex].isEquipped = true;
        SelectGun(gunIndex);
    }

    private void SelectGun(int index)
    {
        for (int i = 0; i < gunDatas.Length; i++)
        {
            gunDatas[i].gun.SetActive(i == index);
        }
        gunDatas[index].gun.SendMessage("OnGunSelected", SendMessageOptions.DontRequireReceiver);
    }
}
