using UnityEngine;
using UnityEngine.SceneManagement;

class GameManagerUNB : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void NextLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
