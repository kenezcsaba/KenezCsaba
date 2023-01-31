using UnityEngine;
using UnityEngine.SceneManagement;

class RestartThisLevel : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void RestartDisLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
