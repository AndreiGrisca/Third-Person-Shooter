using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  public static UIManager uiManager;

  [SerializeField] private GameObject win, lose, main;

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
    win.SetActive(false);
    lose.SetActive(false);
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
    win.SetActive(true);
    lose.SetActive(false);
    main.SetActive(false);
  }

  public void Lose()
  {
    Cursor.lockState = CursorLockMode.None;
    lose.SetActive(true);
    win.SetActive(false);
    main.SetActive(false);
  }
}
