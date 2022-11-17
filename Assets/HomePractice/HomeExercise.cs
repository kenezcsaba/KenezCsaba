using UnityEngine;

class HomeExercise : MonoBehaviour
{


    [SerializeField] float n1;
    [SerializeField] int down;
    [SerializeField] int up;
    [SerializeField] int rules;

    void OnValidate()
    {
       // if (n1 = 0)            
        //    { up = 0; }

        down = (int)Floor(n1);
        up = (int)Ceil(n1);
        rules = (int)Round(n1);


    }



     /*
     [SerializeField] Vector3 a, b;
     [SerializeField] Vector3 result;

     void OnValidate()
     { 
      result = FromAToB(a, b);
     }


     Vector3 FromAToB(Vector3 a, Vector3 b)
     {
         Vector3 v = b - a;
         return v.normalized;
     }



     /*

     [SerializeField] Vector2 vec1, vec2;
     [SerializeField] float distance;

     void OnValidate()
     {

         distance = Vector2.Distance(vec1, vec2);


     }






    [SerializeField] int baseNumber;
    [SerializeField, Min(1)] int exponent;
    [SerializeField] int result;

    void OnValidate()
    {
        result = 1;

        for (int i = 0; i < exponent; i++)
        {
            result *= baseNumber;  
        }


    }






    [SerializeField] int a, b, c, d, e;
    [SerializeField] int min;

    void OnValidate()
    {
        min = Minimum(a, b, c, d, e);


    }




    int Minimum(int n1, int n2, int n3, int n4, int n5)
    {
        int min = n1;
        if (n2 < min)
            min = n2;
        if (n3 < min)
            min = n3;
        if (n4 < min)
            min = n4;
        if (n5 < min)
            min = n5;
        return min;

    }




    [SerializeField] float n1;
    [SerializeField] int down;
    [SerializeField] int up;
    [SerializeField] int rules;

    void OnValidate()
    {
        /*if (n1 = 0)               ????????????????????????????
            { up = 0; }

        down = (int)Floor(n1);
        up = (int)Ceil(n1);
        rules = (int)Round(n1);


    }

    // 0.4999999999999999999999999999999 felfele kerekíti szabály szerint ?????????? ha már beírtam valamit akkor a nullát felfele kerekíti 1-re



    */
    float Floor(float num)
    {
        float remainder = num % 1;
        num -= remainder; 
        return num;
    }

    float Ceil(float num)
    {
        float remainder = num % 1;
        num = num + 1 - remainder; 
        return num;
    }

    float Round(float num)
    {
        float remainder = num % 1;
        if (remainder < 0.5f)
         { 
            return Floor(num);
         }
        else 
        {
            return Ceil(num);
        }
    } 




    /*


    [SerializeField] int n1, n2;
    [SerializeField] int result;

    void OnValidate()
    {
        result = n1;

        while ( result % n2 !=0)
        {

            result += n1;

        }

    }

    void Start()
    {
        for (int i = 1; i<= 10; i++)
        {
            for (int j = 1; j<= 10; j++)
            {
                Debug.Log($"{i} * {j} = {i * j}");
            }
        }


    }









    [SerializeField] int mana;
    [SerializeField] int energy;
    [SerializeField] bool isEnemyHuman;
    [SerializeField] bool isMacePlayable;
    [SerializeField] bool isDaggerPlayable;
    [SerializeField] bool isTeethPlayable;
    [SerializeField] int myHP;
    [SerializeField] int myMaxHP;
    [SerializeField] int enemyHP;



    void OnValidate()
    {

        isMacePlayable = mana >= 3 && energy > 5 && !isEnemyHuman;
        isDaggerPlayable = (myHP < enemyHP || myHP <= myMaxHP / 2)  && myHP > 10;
        isTeethPlayable = (mana >= 2 || myHP > 5 ) && (isEnemyHuman || energy >= 3) && myHP != myMaxHP; 

    }







    [SerializeField] int hp, gold;
    [SerializeField] bool canWeBuyMace;
    [SerializeField] bool canWeBuyDagger;
    [SerializeField] bool canWeBuyTeeth;

    [SerializeField] bool canWeBuyAll;



    void OnValidate()
    {
        int hpToGold = 5;
        int prize = 10;
        canWeBuyMace = hp > (hpToGold * (prize-gold));
        prize = 4;
        canWeBuyDagger = hp > (hpToGold * (prize - gold));
        prize= 13;
        canWeBuyTeeth = hp > (hpToGold * (prize - gold));
        prize = 27;
        canWeBuyAll = hp > (hpToGold * (prize - gold));



    }










    [SerializeField] int a,b,c;
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField,Min(1)] int szorzo = 1;
    [SerializeField] int enemyDistance;
    [SerializeField] bool isEnemyInRange;
    [SerializeField] bool isPitagorasz;



    [SerializeField] int n1;
    [SerializeField, Min(1)] int n2 = 1;
    [SerializeField] bool isDivideableWithoutRemainder;


    void OnValidate()
    {
       isDivideableWithoutRemainder = n1 % n2 == 0;

        isEnemyInRange = enemyDistance >= min && enemyDistance <= max * szorzo;
        isPitagorasz = a * a + b * b == c * c;

    }






    [SerializeField] int n1;
    [SerializeField] bool isOszthSeven;
    [SerializeField] bool isOszthFifteen;
    [SerializeField] bool isOszthNinetyNine;
    [SerializeField] bool paros;



    void OnValidate()
    {

        isOszthSeven = n1 % 7 == 0;
        isOszthFifteen = n1 % 15 == 0;
        isOszthNinetyNine = n1 % 99 == 0;
        paros = n1 % 2 == 0;


    }






    [SerializeField] float a, b;
    [SerializeField] int c;
    [SerializeField, Min(1)] int d = 1;
    [SerializeField] int e,f,g,h,i;
    [SerializeField] float summa;
    [SerializeField] float difference;
    [SerializeField] float product;
    [SerializeField] float hanyados;
    [SerializeField] int quotient;
    [SerializeField] float remainder;
    [SerializeField] float average;

    void OnValidate()
    {
    summa = a + b;
    difference = a - b;
    product = a * b;
    hanyados = a / b;

    quotient = c / d;
    remainder = c % d;

        average = (e + f + g + h + i) / 5f; 
    }




    [SerializeField] string text1, text2, text3, text4, text5;
    [SerializeField] string alltogether;
    [SerializeField] int n1, n2;
    [SerializeField] string summa;
    [SerializeField] string exerciseSix;

    void OnValidate()
    {
        int quotient = n1 / n2;
        int remainder = n1 % n2;

    alltogether = $"{text1}, {text2}, {text3}, {text4}, {text5}";
        summa = $"{n1} + {n2} = {n1+n2}";
        exerciseSix = $"{n1}-ben/ban {n2} megvan {quotient}-szer/szor/ször, maradék a(z) {remainder}";



    }





    [SerializeField] int n1, n2;
    [SerializeField] float r1;
    [SerializeField] float kerulet;
    [SerializeField] float terulet;


    void OnValidate()
    {
         kerulet = 2 * r1 * Mathf.PI;
         terulet = r1 * r1 * Mathf.PI;

    }

    void Start()
    {
        float save = terulet;
        terulet = kerulet;
        kerulet = save;
        Debug.Log(terulet + " " + kerulet);
        (n1, n2) = (n2, n1);

    }
    */



    }
