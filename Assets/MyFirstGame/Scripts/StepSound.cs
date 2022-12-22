using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour                                              // az eg�sz dec 22.
{
    [SerializeField] AudioSource[] sources;                              //referencia



    private void OnValidate()
    {
        sources = GetComponentsInChildren<AudioSource>();
    }

    public void PlayFootStep()                                      // public kell h legyen h le tudja j�tszani a j�t�k, vagyis gondolom ahhoz h hozz�f�rjen m�s r�sze a j�t�knak
    {

        int randomIndex = Random.Range(0, sources.Length);


        AudioSource source = sources[randomIndex];
        source.Play();

        //  sources[Random.Range(0, sources.Length)].Play();            r�vid v�ltozat

        // audio listener komponens a game objecten a j�t�kosunk f�l�t reprezent�lja, amit � hall 
    }
}
