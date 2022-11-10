using UnityEngine;
class VampireMerchant : MonoBehaviour
{

    [SerializeField] int myGold;
    [SerializeField] int myHp;

    [SerializeField] bool canBuyMace;
    [SerializeField] bool canBuyDagger;
    [SerializeField] bool canBuyTeeth;

    void OnValidate()
    {
        const int goldToHp = 5;

        int macePrice = 10;
        canBuyMace = macePrice <= myGold || macePrice * goldToHp < myHp;

        int daggerPrice = 10;
        canBuyDagger = (daggerPrice - myGold) * goldToHp < myHp;


    }
}
