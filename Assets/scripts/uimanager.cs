using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uimanager : MonoBehaviour
{
    Text txtHit;
    void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Menu"))
            txtHit = GetComponentInChildren<Text>();
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    void Update()
    {
        if(txtHit)
            txtHit.text ="Combo: " + Gm.instance.getHits().ToString();
    }
}
