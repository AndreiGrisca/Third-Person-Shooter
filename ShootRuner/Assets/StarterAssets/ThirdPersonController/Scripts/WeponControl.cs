using System.Collections;
using StarterAssets;
using TMPro;
using UnityEngine;

public class WeponControl : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private ParticleSystem hitEfect; 
    [SerializeField] private ParticleSystem hitEfectBlood;
    [SerializeField] private ParticleSystem muzzlef;
    [SerializeField] private LayerMask aimColLayerMask;
    [SerializeField] private TextMeshProUGUI _ammo;
    [SerializeField] private int damage = 15;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float curentAmmo; 
    [SerializeField] private float maxAmmo;
    [SerializeField] private float reloadTime;
    private float nextFire;
    private bool isReloading=true;
    private Transform hitTransform ;
    private void Start()
    {
        if (curentAmmo == -1)
        { 
            curentAmmo = maxAmmo;
        }
    }

    private void Update()
    {
        _ammo.text ="Ammo:"+ curentAmmo;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColLayerMask))
        {
            hitTransform = raycastHit.transform;
        }
        if (isReloading)
        {
            if (curentAmmo <= 0)
            {
                StartCoroutine(Reload());
            }
            if(starterAssetsInputs.shoot&&starterAssetsInputs.aim)
            {
                if (hitTransform != null)
                {
                    curentAmmo--;
                    muzzlef.Play();
                    _audioSource.PlayOneShot(shootSFX);
                    if (hitTransform.CompareTag("Shootable"))
                    {
                        hitTransform.parent.parent.GetComponent<Enemy>().TakeDamage(damage);
                       Instantiate(hitEfectBlood, raycastHit.point, Quaternion.identity);
                       
                    }
                    else
                    {
                      Instantiate(hitEfect, raycastHit.point, Quaternion.identity);
                    }
                        
                }
                starterAssetsInputs.shoot = false;
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = false;
        Debug.Log("Reload");
        yield return new WaitForSeconds(reloadTime);
        curentAmmo = maxAmmo;
        
        isReloading =true;
    }
    
    
}
