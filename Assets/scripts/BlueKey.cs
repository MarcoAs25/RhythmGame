using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlueKey : MonoBehaviour
{
    Animator anim;
    GameObject note;
    public float coyoteTime = 10.5f, timeCo = 0;
    public bool HaveNote = false, performedNote = false;
    public void OnPressedR2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (HaveNote)
            {
                Gm.instance.add();
                Destroy(note);
                performedNote = true;
                Debug.Log("Accepted");
            }
            anim.SetBool("isPressing", true);
        }
        else if (context.canceled)
        {
            anim.SetBool("isPressing", false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timeCo -= Time.deltaTime;
        if (timeCo < 0 && HaveNote)
        {
            if (!performedNote)
            {
                Gm.instance.clear();
                Debug.Log("Perdeu a nota");
            }
            performedNote = false;
            HaveNote = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            HaveNote = true;
            timeCo = coyoteTime;
            //Destroy(other.gameObject);
            note = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            note = null;
        }
    }
}
