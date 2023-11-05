using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;
    
    private Rigidbody bulletRigidbody;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
     
    }

    private void Start() {
        float speed = 50f;
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        
        if (other.CompareTag("Enemy")) 
        {
            // Hit target
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            
            Debug.Log("hitRed");
        } else {
            // Hit something else
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            Debug.Log("hitGred");
            
        }
        Destroy(gameObject);
    }

}