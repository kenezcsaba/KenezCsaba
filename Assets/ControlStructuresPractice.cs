using UnityEngine;

class ControlStructuresPractice : MonoBehaviour
{
    [SerializeField] int number;

    [SerializeField] string parity;
    [SerializeField] string domain;
    [SerializeField] string danger;
    [SerializeField] string divideableBy3;


    void OnValidate()
    {

        // ELAGAZASOK

        bool isEven = number % 2 == 0;
        if (isEven)
        {
            parity = "paros";

        }
        else
        {
            parity = "paratlan";
        }


        // ----------------------------------------
        if (number > 0)
        {
            domain = "pozitív";
        }
        else if (number < 0)
        {
            domain = "negatív";
        }
        else
        {
            domain = "NULLA";
        }



        if (number < 10)
        {
            danger = "low";
        }
        else if (number < 35)
        {
            danger = "medium";
        }
        else if (number < 50)
        {
            danger = "high";
        }
        else
        {
            danger = "extrem";
        }

        // ------------------------

        divideableBy3 = number % 3 == 0 ? "osztható 3-mal" : "nem osztható 3-mal";



    }




    void Start()
    {
        //CIKLUSOK---------------------

        int i = 1;
        /*
         while (i <= 5)
         {
             Debug.Log(i);
             i++;
         }

         for (int j = 1; j <= 5; j++)
         {
             Debug.Log(j);
         }

         for (int j = 10; j >=1 ; j--)
         {
             Debug.Log(j);
         }
        */

        for (int l = 1; l <= 100; l+=3)
        {
 
                Debug.Log(l);
    
        }

        for ( i = 1; i < 100; i++)
        {
            if (i % 3 == 0 && i % 7 == 0)
            {
                Debug.Log(i);
            }
        }





    }

}
