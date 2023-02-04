using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.Animations.Rigging;


public class ThirdShootControler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private LayerMask aimColLayerMask = new LayerMask();
    
    private StarterAssetsInputs starterAssetsInputs;
    private SwichWepons swichWepons;
    private ThirdPersonController thirdPersonController;
    private float aimDuration = 0.3f;
    public Rig PosGan;
    public Rig PosPistol;
    public Rig PosRifle;
    public Rig aimPosPistol;
    public Rig aimPosRifle;
    public Rig aimPosGan;
    
    void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        swichWepons = GetComponent<SwichWepons>();
    }
    
    void Update()
    {
       Vector3 mouseWorldPosition = Vector3.zero;
        
         Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
         Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
         if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColLayerMask))
         {
             mouseWorldPosition = raycastHit.point;
         }
        if (starterAssetsInputs.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
            if (swichWepons.weponEq)
            {
                aimPosRifle.weight = 1;
                PosRifle.weight = 0;
                
            }

            if (swichWepons.pistoEq)
            {
                aimPosPistol.weight = 1;
                PosPistol.weight = 0;
               
            }
            if (swichWepons.ganEq)
            {
                aimPosGan.weight = 1;
                PosGan.weight = 0;
               
            }
           
                  
            thirdPersonController.SetRotateOnMove(false);
            Vector3 worldAimTarget = mouseWorldPosition;
           worldAimTarget.y = transform.position.y;
           Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            
           transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else
        {
            if (swichWepons.weponEq)
            {
                aimPosRifle.weight = 0;
                PosRifle.weight = 1;
               
            }

            if (swichWepons.pistoEq)
            {
                aimPosPistol.weight = 0;
                PosPistol.weight = 0;
               
            }
            if (swichWepons.ganEq)
            {
                aimPosGan.weight = 0;
                PosGan.weight = 1;
               
            }

            aimVirtualCamera.gameObject.SetActive(false);  
            thirdPersonController.SetRotateOnMove(true);
        }
    }
}
