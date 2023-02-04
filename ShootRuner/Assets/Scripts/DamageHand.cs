using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class DamageHand : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _thirdPersonController;
    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            Debug.Log("colizion");
            _thirdPersonController.TakeDamage(20);
        }
    }

}
