using UnityEngine;

class SetInactive : MonoBehaviour
{
    [SerializeField] GameObject turnOff;

    public void InactiveCanvas()
    { 
        turnOff.SetActive(false);
    }
}
