using UnityEngine;

class MethodPractice : MonoBehaviour
{

    void Start()
    {
        Debug.Log("AAA");
        CountUntil("x",8);
        Debug.Log("BBB");
        CountUntil("y",34);
        Debug.Log("CCC");
        CountUntil("z",11);
        Debug.Log("-----------------------------");

        int a = Power(5, 3);
        int b = Power(4, 6);
        int c = Power(2, 10);

        Debug.Log($"{a} --- {b} --- {c}");


    }

    void CountUntil(string st, int count)
    {
        for (int i = 0; i <= count; i++)
        {
            Debug.Log(st + " " + i);
        }
    }

    int Power(int baseNumber, int exponent)                      //power hatványozás
    {
        int a=1;
        for (int i = 0; i < exponent; i++)
        {
            a *= baseNumber;
        }

        return a;
    }




}

