using UnityEngine;

class MyFirstScript : MonoBehaviour
{

    void Start()
    {
        Debug.Log("Hello World");
        Debug.Log("Hello " + name);

        // komment
        /* ez is egy komment */


        int myFirstVar;

        myFirstVar = 6;
        myFirstVar = 9;
        Debug.Log(myFirstVar);

        int aaa = 456;
        int x, y, z;


        int integerNumber = 231;
        float myFloatingPointNumber = 0.4f;
        string myFirstString = "b�rmi";
        bool myFirstBool = true;
        myFirstBool = false;



        int a = 3, b = -1, c = 90;
        int summa = a + b;

        Debug.Log(summa);       //2

        int dif = c - 55;       //35
        dif = dif - 5;          //30
        dif -= 5;               //25
        dif++;

        //int eg�sz sz�mok, a tizedes ut�nit nem n�z�k
        int product = a * 5;    //15
        int ratio = a / 5;      //0


        // % modulo m�velet marad�kot adja meg
        int modulo = 35 % a;    //2    35:3 marad�k: modulo azaz 2
        Debug.Log(modulo);

        var iii = 3456;
        var sss = "qwerty";

        //iii = 45.6f;  az els� defini�l�sn�l, azaz deklar�l�sn�l felismerte a program h ez egy int t�pus� v�ltoz� amit megadtunk neki �rt�knek, �gy itt hib�s int t�pusnak float �rt�ket megadni

        int xxx = 3 + 2 * 4;    //11
        xxx = (3 + 2) * 4;
        string s1 = "String";
        string s2 = "�sszead�s";

        string s3 = s1 + " " + s2;     
        Debug.Log(s3);

        int i1 = 3, i2 = 7; 
        string s4 = s1 + i1;            // Hello3
        string s5 = s1 + i1 + i2;       // Hello37
        string s6 = i2.ToString();

        string s7 = i1 + i2 + s1;   // 10Hello
        
        
        float ff1 = 3.5f;
        int ii1 = 4;

        int ii2 = (int)ff1;
        float ff2 = ii1;

        string numberText = "234";

        int ii3 = int.Parse(numberText);


    }

}