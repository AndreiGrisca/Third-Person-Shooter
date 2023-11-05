using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;


public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs starterAssetsInputs;
    [SerializeField] private WeponControl weponControl;
    [SerializeField] private List<Wepon> wepon;
    [SerializeField] private TextMeshProUGUI _ammo;
    public GameObject immagReload;
    private bool isReloading = true;
    private Transform hitTransform;
    public GameObject buletPr;
    public Transform spwnBulletPos;
    public int damage;

    private void Start()
    {
         
    }

    private void Update()
    {
        damage = wepon[weponControl.curentWeponIndex].damge;
        _ammo.text ="Ammo:"+ wepon[ weponControl.curentWeponIndex].currentAmmo;
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if (isReloading)
        {
             if (wepon[weponControl.curentWeponIndex].currentAmmo <= 0)
             {
                 StartCoroutine(Reload());
             }
            if (starterAssetsInputs.shoot && starterAssetsInputs.aim&&isReloading)
            {
                if (hitTransform != null)
                {
                    wepon[weponControl.curentWeponIndex].currentAmmo--;
                    Vector3 aimDir = (mouseWorldPosition - spwnBulletPos.position).normalized;
                    Instantiate(buletPr, spwnBulletPos.position, Quaternion.LookRotation(aimDir, Vector3.up));
                    if (hitTransform.CompareTag("Enemy"))
                    {
                         hitTransform.GetComponent<Enemy>().TakeDamage(damage);
                    }
                   
                }
                starterAssetsInputs.shoot = false;
            }
        }
    }
    
    IEnumerator Reload()
    {
        isReloading = false;
        immagReload.SetActive(true);
        Debug.Log("Reload");
        yield return new WaitForSeconds( wepon[weponControl.curentWeponIndex].reload);
         wepon [weponControl.curentWeponIndex].currentAmmo = wepon[weponControl.curentWeponIndex].ammo;
         immagReload.SetActive(false);
        isReloading =true;
    }
}
    







