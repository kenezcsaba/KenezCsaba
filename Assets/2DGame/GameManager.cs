using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }


}
