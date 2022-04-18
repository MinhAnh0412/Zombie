using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class AmmoBinding : MonoBehaviour
{
    public TMP_Text ammoValueText;
    public GunAmmo gunAmmo;

    private void OnValidate() => ammoValueText = GetComponent<TMP_Text>();

    private void Start()
    {
        gunAmmo.onAmmoChanged += UpdateAmmoValue;
        UpdateAmmoValue();
    }

    private void UpdateAmmoValue()
        => ammoValueText.text = $"{gunAmmo.LoadedAmmo} / {gunAmmo.magazineSize}";
}
