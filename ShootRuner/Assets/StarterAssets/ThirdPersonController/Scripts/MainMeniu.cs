using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMeniu : MonoBehaviour
{
  [SerializeField] private GameObject win, lose, main;
  
  public void Awake()
  {
    main.SetActive(true);
  }
  public void StartGame()
  {
    SceneManager.LoadScene("Playground");
  }
  public void ExitGame()
  {
    SceneManager.LoadScene("Meniu");
    main.SetActive(true);
  }
  public void Win()
  {
    win.SetActive(true);
    lose.SetActive(false);
    main.SetActive(false);
  }
  public void Lose()
  { 
    lose.SetActive(true);
   win.SetActive(false);
   main.SetActive(false);
  }

  public void Main()
  {
    win.SetActive(false);
    lose.SetActive(false);
    main.SetActive(true);
  }
}
