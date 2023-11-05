using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WeponControl : MonoBehaviour
{
    private StarterAssetsInputs _inputs;
    private Animator animator;
    public List<GameObject> weponMesh;
    public int curentWeponIndex;
    

    public void Awake()
    {
        _inputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        SwichiWepons();
    }

    private void SwichiWepons()
    {
        if (_inputs.hotKey1)
        {
            curentWeponIndex = 0;
            weponMesh[0].SetActive(true);
            weponMesh[1].SetActive(false); 
            weponMesh[2].SetActive(false);
            animator.SetLayerWeight(0,1);
            animator.SetLayerWeight(1,0);
            animator.SetLayerWeight(2,0);
            _inputs.hotKey1 = false;
        }

        if (_inputs.hotKey2)
        {
            curentWeponIndex = 1;
            weponMesh[0].SetActive(false);
            weponMesh[1].SetActive(true); 
            weponMesh[2].SetActive(false);
            animator.SetLayerWeight(0,0);
            animator.SetLayerWeight(1,1);
            animator.SetLayerWeight(2,0);
            _inputs.hotKey2 = false;
        }
        if (_inputs.hotKey3)
        {
            curentWeponIndex = 2;
            weponMesh[0].SetActive(false);
            weponMesh[1].SetActive(false); 
            weponMesh[2].SetActive(true);
            animator.SetLayerWeight(0,0);
            animator.SetLayerWeight(1,0);
            animator.SetLayerWeight(2,1);
            _inputs.hotKey3 = false;
        }
       
    }
    

}
