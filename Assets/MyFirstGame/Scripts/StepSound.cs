using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour                                              // az egész dec 22.
{
    [SerializeField] AudioSource[] sources;                              //referencia



    private void OnValidate()
    {
        sources = GetComponentsInChildren<AudioSource>();
    }

    public void PlayFootStep()                                      // public kell h legyen h le tudja játszani a játék, vagyis gondolom ahhoz h hozzáférjen más része a játéknak
    {

        int randomIndex = Random.Range(0, sources.Length);


        AudioSource source = sources[randomIndex];
        source.Play();

        //  sources[Random.Range(0, sources.Length)].Play();            rövid változat

        // audio listener komponens a game objecten a játékosunk fülét reprezentálja, amit õ hall 
    }
}
