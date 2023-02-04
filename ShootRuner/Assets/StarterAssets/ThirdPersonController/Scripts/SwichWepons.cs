using StarterAssets;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SwichWepons : MonoBehaviour
{
    private float animDuration;
    private StarterAssetsInputs _starterAssets;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject pistol;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject image1,image2,image3;
    public bool weponEq,pistoEq,ganEq;
    public Rig armPosPistol;
    public Rig armPosGan;
    public Rig armPosRifle;
    public Rig PosRifle;
    public Rig PosGan;
    public Rig PosPistol;
    private  void Awake()
    {
        _starterAssets = GetComponent<StarterAssetsInputs>();
    }

    
    void Update()
    {
        if (_starterAssets.hotKey1)
        {
            pistol.SetActive(false);
            gun.SetActive(false);
            rifle.SetActive(true);
            armPosRifle.weight = 1;
            PosRifle.weight = 1;
            armPosGan.weight = 0;
            PosGan.weight = 0;
            PosPistol.weight = 0;
            armPosPistol.weight = 0;
            weponEq = true;
            _starterAssets.hotKey1 = false;
            image1.SetActive(true);
            image2.SetActive(false);
            image3.SetActive(false);
        }

        if (_starterAssets.hotKey2)
        {
            rifle.SetActive(false);
            gun.SetActive(false);
            pistol.SetActive(true);
            armPosPistol.weight = 1;
            PosPistol.weight = 1;
            armPosRifle.weight = 0;
            PosRifle.weight = 0;
            armPosGan.weight = 0;
            PosGan.weight = 0;
            pistoEq = true;
            _starterAssets.hotKey2 = false;
            image1.SetActive(false);
            image2.SetActive(true);
            image3.SetActive(false);
        }
        if (_starterAssets.hotKey3)
        {
            rifle.SetActive(false);
            pistol.SetActive(false);
            gun.SetActive(true);
            armPosGan.weight = 1;
            PosGan.weight = 1;
            armPosPistol.weight = 0;
            PosPistol.weight = 0;
            armPosRifle.weight = 0;
            PosRifle.weight = 0;
            ganEq = true;
            _starterAssets.hotKey3 = false;
            image1.SetActive(false);
            image2.SetActive(false);
            image3.SetActive(true);
        }
       
    }
}
