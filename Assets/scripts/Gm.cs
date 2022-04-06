using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gm : MonoBehaviour
{
    public static Gm instance;
    int hits;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        
    }

    public void add()
    {
        hits++;
    }

    public void clear()
    {
        hits = 0;
    }

    public int getHits()
    {
        return hits;
    }
    
}
