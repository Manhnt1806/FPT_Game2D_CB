using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sCoin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Chem" )
        {
            sCoin.Play();
            var nameB = other.gameObject.name;
            Destroy(GameObject.Find(nameB));
            Destroy(this.GameObject());
        }
    }
}
