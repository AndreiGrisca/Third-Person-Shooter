using StarterAssets;
using UnityEngine;

public class DamageHand : MonoBehaviour
{
    [SerializeField] private ThirdPersonController _thirdPersonController;
    private void OnTriggerEnter(Collider Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            _thirdPersonController.TakeDamage(20);
        }
    }

}
