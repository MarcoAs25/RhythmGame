using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float velocity = 15, limit = -10;
    [SerializeField]
    float idx;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setIndex(int idx)
    {
        this.idx = idx;
    }
    // Update is called once per frame
    void Update()
    {
        if (limit > transform.position.z)
        {
            Destroy(gameObject);
        }
        transform.Translate(-Vector3.forward * velocity * Time.deltaTime);
    }
}
