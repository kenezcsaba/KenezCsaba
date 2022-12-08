using System.Collections.Generic;
using UnityEngine;

class ArrayPractice : MonoBehaviour
{
        // array = tömb

    [SerializeField] int[] intArray;
    [SerializeField] List<int> intList;             // using System.Collections.Generic; ez kell using-olni :DD  generikus listák ebben vannak benne
    [SerializeField] List<int> intList2;


    void Start()
    {
        for (int i = 0; i < intArray.Length; i++)
        {

            int element = intArray[i];
            Debug.Log(element);

        }

        foreach ( int element in intArray)              // ez ugyanaz mint feljebb ,amin végig lehet iterálni (lépkedni) ott alkalmazható a foreacg, ilyenek a tömbök
        {
            Debug.Log(element);
        }


        for (int i = intArray.Length - 1; i >= 0; i--)          // visszafele kiírva az értékek
        {

            int element = intArray[i];                              //kódból nem tudok tömb elemet törölni csak unityben
            Debug.Log(element);

        }



        int[] intArray2 = new int[10];          // létrehoztunk egy 10 elemû tömböt
        for (int i = 0; i < intArray2.Length; i++)
        {
            int a = i + 1;
            intArray2[i] = a * a;
            Debug.Log(intArray2[i]);
            //intArray[0] = 1;              beállítunk egy értéket a [0]-dik elemnek
            // .ToString() mindenbõl lehet stringet csinálni így
        }

        int[] intArray3 = new int[10];
        
        intArray3[0] = 1;
        intArray3[1] = 1;
        Debug.Log("1");
        Debug.Log("1");


        for (int i = 2; i < intArray3.Length; i++)
        {


            intArray3[i] = intArray3[i-1] + intArray3[i-2];
            Debug.Log(intArray3[i]);

        }


        List<string> stringList = new List<string>();               // kezdetben nulla elemû, nem kell megadni h mekkora a lista   
        for (int i = 0; i < 10; i++)
        {
            int num = (i + 1) * (i + 1);
            stringList.Add(num.ToString());                                     // .ToString() mindenbõl lehet stringet csinálni így
        }


        foreach (string e in stringList)
        {
            Debug.Log(e);
        }

        for (int i = 0; i < stringList.Count; i++)
        {
            string e = stringList[i];
            Debug.Log(e);
        }
            
        bool succesfulRemove = stringList.Remove("50");                 // remove mindig olyan típust vár mint amilyen a lista vagy amirõl szó van 
        stringList.RemoveAt(3);                                         // a 3. indexût, tehát a negyedik elemet kiveszi

        //stringList.Clear();               ürítjük a listát

        for (int i = 0; i < stringList.Count; i++)
        {
            stringList.RemoveAt(0);
        }


        //List<int> intList2 = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            int random = Random.Range(1, 101);
            intList2.Add(random);
        }


        // töröljük a páros értékû elemeket
      

        for (int i = intList2.Count - 1; i >= 0; i--)
        {
            int element = intList2[i];

            if (element % 2 == 0)
            {
                intList2.RemoveAt(i);
                //i--;           ez helyes ,megoldás lenne ha elölrõl megyünk a listán azaz i++ a for ciklus
            }
        }


        intList2.Sort();            // sorba teszi a Unityben
        stringList.Insert(5, "Alma");
        bool c = stringList.Contains("Körte");
        int KorteIndex = stringList.IndexOf("Körte");               //-1  -et ad vissza             ha több is van, az elsõt adja vissza

        List<int> intList5 = new List<int>(intArray);               // paraméterben tömböt adok meg a listámnak amit létrehoztam
        int[] intArray5 = intList5.ToArray();                       // findobject meg ezek a mûveletek tömböt adnak, azokkal ha kezdeni akarunk valamit akkor listává alakítjuk
                                                                    // láncolt lista is létezik a programozásban, a C#-ban nem láncolt a lista   az valami linked list lenne






    }

}
