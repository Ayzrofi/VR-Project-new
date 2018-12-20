using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManajer : MonoBehaviour {

	public void ToGameScene()
    {
        SceneManager.LoadScene("main_Gameplay");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Waaaa");
    }
}
