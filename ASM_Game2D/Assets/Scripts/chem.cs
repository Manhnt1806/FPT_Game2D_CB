using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chem : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    void Start()
    {
        Destroy(this.gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            var nameB = other.gameObject.name;
            Destroy(GameObject.Find(nameB));
            Destroy(this.gameObject);
        }
        
    }
}
