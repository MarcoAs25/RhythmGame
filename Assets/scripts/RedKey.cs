using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RedKey : MonoBehaviour
{
    Animator anim;
    Queue<GameObject> notesQ;
    public Material matE, mat;
    public MusicComposer mc;
    public void OnPressedL1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (notesQ.Count > 0)
            {
                gameObject.GetComponent<Renderer>().material = matE;
                Gm.instance.add();
                Destroy(notesQ.Dequeue());
                Debug.Log("Accepted");
            }
            anim.SetBool("isPressing", true);
        }
        else if (context.canceled)
        {
            gameObject.GetComponent<Renderer>().material = mat;
            anim.SetBool("isPressing", false);
        }
    }
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = mat;
        anim = GetComponent<Animator>();
        notesQ = new Queue<GameObject>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            notesQ.Enqueue(other.gameObject);
        }
    }
    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(.2f);
        mc.audi.volume = 1;
        mc.audi3.volume = 0;
        mc.audi3.pitch = 1;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            Gm.instance.clear();
            Destroy(notesQ.Dequeue());
            mc.audi.volume = 0;
            mc.audi3.volume = 1;
            mc.audi3.pitch = -2;
            StartCoroutine(DoCheck());
        }
    }
}
