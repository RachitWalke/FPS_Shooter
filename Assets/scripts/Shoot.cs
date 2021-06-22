using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public float damage = 10.0f;
    public float range = 100.0f;

    public Camera MainCam;

    public ParticleSystem muzzleFlash;

    public GameObject impact1;
    public GameObject impact2;

    public float fireRate = 10.0f;
    private float nextTimetoFire = 0.0f;

    public int maxAmmo = 31;
    private int CurrentAmmo;
    public float ReloadTime = 2.0f;
    private bool isReloading = false;

    public Animator anim;

    public AudioSource audiosrc;
    public AudioClip clip;

    public TMP_Text bulletCount;

    private void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        CurrentAmmo = maxAmmo;
        anim = GetComponent<Animator>();
        bulletCount.text = maxAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if(CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1.0f / fireRate;
            audiosrc.Play();
            shootBullet();
        }
    }

    public void shootBullet()
    {
        CurrentAmmo--;
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(MainCam.transform.position, MainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyBehaviour enemy = hit.transform.GetComponent<EnemyBehaviour>();

            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Instantiate(impact1, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(impact2, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
        bulletCount.text = CurrentAmmo.ToString();
    }

    IEnumerator Reload()
    {
        isReloading = true;
        anim.SetBool("isReloading", true);

        yield return new WaitForSeconds(ReloadTime - 0.25f);

        anim.SetBool("isReloading", false);
        yield return new WaitForSeconds(0.25f);

        CurrentAmmo = maxAmmo;
        bulletCount.text = CurrentAmmo.ToString();
        isReloading = false;
    }
}
