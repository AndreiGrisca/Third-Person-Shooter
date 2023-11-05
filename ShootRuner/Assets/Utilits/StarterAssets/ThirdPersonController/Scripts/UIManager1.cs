using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager1 : MonoBehaviour
{
  public  UIManager1 uiManager;

  [SerializeField] private GameObject main;

  public void Awake()
  {
    uiManager = this;
    main.SetActive(true);
  }

  private void OnDestroy()
  {
    uiManager = null;
  }

  public void StartGame()
  {
    Cursor.lockState = CursorLockMode.Locked;
   
    main.SetActive(false); 
  
    SceneManager.LoadScene("Playground");
  }

  public void ExitGame()
  {
    Application.Quit();
  }

  public void Win()
  {
   Cursor.lockState = CursorLockMode.None;
   main.SetActive(true);
  }
  public void Meniu()
  {
    Cursor.lockState = CursorLockMode.None;
    SceneManager.LoadScene("MainMenuScene");
  }

  public void Lose()
  {
   Cursor.lockState = CursorLockMode.None;
   main.SetActive(true);

  }
}
