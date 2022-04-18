using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GunAmmo : MonoBehaviour
{
    public Animator anim;
    public int magazineSize;
    public Shooting shooting;
    public System.Action onAmmoChanged;
    public AudioSource[] reloadSounds;

    private bool isReloading;

    private int loadedAmmoValue;
    public int LoadedAmmo 
    {
        get => loadedAmmoValue;
        private set
        {
            loadedAmmoValue = value;
            onAmmoChanged?.Invoke();
        }
    }

    private void OnValidate()
    {
        anim = GetComponent<Animator>();
        shooting = GetComponent<Shooting>();
    }

    private void Start() => AddAmmo();

    void Update()
    {
        if (isReloading) return;

        if (LoadedAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Reload()
    {
        anim.SetTrigger("Reload");
        shooting.enabled = false;
        isReloading = true;
    }

    public void SingleFireAmmoCounter() => LoadedAmmo--;

    public void AddAmmo() => LoadedAmmo = magazineSize;

    public void ReloadToIdle()
    {
        shooting.enabled = true;
        isReloading = false;
    }

    public void PlayReloadPart1Sound() => reloadSounds[0].Play();

    public void PlayReloadPart2Sound() => reloadSounds[1].Play();

    public void PlayReloadPart3Sound() => reloadSounds[2].Play();

    public void PlayReloadPart4Sound() => reloadSounds[3].Play();

    public void PlayReloadPart5Sound() => reloadSounds[4].Play();

    public void OnGunSelected() => ReloadToIdle();
}
