using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class notesDescriptor
{
    public float offset;
    public List<float> time1;
    public List<float> time2;
    public List<float> time3;
    public notesDescriptor()
    {
        time1 = new List<float>();
        time2 = new List<float>();
        time3 = new List<float>();
    }
}
public class NotesDevelopScript : MonoBehaviour
{
    notesDescriptor notes;
    public AudioSource audioNote;

    void Start()
    {
        Time.timeScale = 0;
        notes = new notesDescriptor();
    }
    public void OnPressedGreen(InputAction.CallbackContext context)
    {
        if (context.performed)
            notes.time1.Add(audioNote.time);
    }
    public void OnPressedRed(InputAction.CallbackContext context)
    {
        if (context.performed)
            notes.time2.Add(audioNote.time);
    }
    public void OnPressedYellow(InputAction.CallbackContext context)
    {
        if (context.performed)
            notes.time3.Add(audioNote.time);
    }
    public void OnPressedStart(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Time.timeScale = 1;
            if (audioNote)
                audioNote.Play();
        }
    }
    public void OnPressedImport(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            string n = JsonUtility.ToJson(notes);
            Debug.Log(n);
        }
    }
}
