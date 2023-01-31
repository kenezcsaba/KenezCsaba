using UnityEngine;

class RestartButton : MonoBehaviour
{
    [SerializeField] GameObject turnOnWhenClick;

    public void RestartLevel()
    {
        turnOnWhenClick.SetActive(true);
    }
}
