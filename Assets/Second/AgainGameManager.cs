using UnityEngine;
using UnityEngine.SceneManagement;

class AgainGameManager : MonoBehaviour
{
    [SerializeField] string sceneName;

   public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }


}