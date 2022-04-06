using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComposer : MonoBehaviour
{
    public string nameNotes;
    notesDescriptor notas;
    public GameObject[] nota;
    bool isPlaying = false;
    public int passo1 = 0, passo2 = 0, passo3 = 0, passo4 = 0, passo5 = 0;
    public AudioSource audi,audi2,audi3;
    void Start()
    {
        audi2.Play();
        TextAsset txt = (TextAsset)Resources.Load(nameNotes, typeof(TextAsset));
        string content = txt.text;
        notas = JsonUtility.FromJson<notesDescriptor>(content);

    }
    void Update()
    {
        if(audi.isPlaying)
            audi3.time = audi.time;
        // 2.241f = 22.41(Distance of point to instantiate notes for notes Input)/ 10(Velocity of notes instantiated)
        if (audi2.time > 2.241f && !isPlaying)
        {
            isPlaying = true;
            audi.Play();
            audi3.Play();
        }
        if (notas.time1.Count > passo1 && notas.time1[passo1] <= audi2.time)
        {
            Instantiate(nota[0]);
            passo1++;
        }
        if (notas.time2.Count > passo2 && notas.time2[passo2] <= audi2.time)
        {
            passo2++;
            Instantiate(nota[1]);
        }
        if (notas.time3.Count > passo3 && notas.time3[passo3] <= audi2.time)
        {
            passo3++;
            Instantiate(nota[2]);
        }
    }
}
