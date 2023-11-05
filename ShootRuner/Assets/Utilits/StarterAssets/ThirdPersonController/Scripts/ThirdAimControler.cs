using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class ThirdAimControler : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController;

    void Awake()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    
    void Update()
    {
       Vector3 mouseWorldPosition = GetAimCenter();

       if (starterAssetsInputs.aim)
       {
             AimShooting(mouseWorldPosition);
       }
       else
       {
             NormalShooting();
       }
    }

    private Vector3 GetAimCenter()
    {
        Vector3 temp=Vector3.zero;
        
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            temp = raycastHit.point;
        }

        return temp;
    }

    private void NormalShooting()
    {

        aimVirtualCamera.gameObject.SetActive(false);
        thirdPersonController.SetRotateOnMove(true);
    }

    private void AimShooting(Vector3 mouseWorldPosition)
    {
        aimVirtualCamera.gameObject.SetActive(true);
        thirdPersonController.SetRotateOnMove(false);
        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
    }
}
