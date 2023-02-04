using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentEnemy;
    [SerializeField] private ThirdPersonController _personController;
    public MainMeniu mainMeniu;
    public GameObject[] countEnemy;

    private void Awake()
    {
        mainMeniu = GetComponent<MainMeniu>();
    }

    void Update()
    {
        countEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        currentEnemy.text = "CurentEnemy" + countEnemy.Length;
        if (countEnemy.Length==0)
        {
            SceneManager.LoadScene("Meniu");
            mainMeniu = GetComponent<MainMeniu>();
            mainMeniu.Win();
        }
        if (_personController.currentHealth == 0)
        {
            SceneManager.LoadScene("Meniu");
            mainMeniu = GetComponent<MainMeniu>();
            mainMeniu.Lose();
        }
    }
}
