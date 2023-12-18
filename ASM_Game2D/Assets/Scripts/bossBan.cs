using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBan : MonoBehaviour
{
    public GameObject vienDan;
    public Transform firePos;
    public float timeSkill=0.5f;
    public float lucSung;
    private float timeSkill2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSkill -= Time.deltaTime;
        if (timeSkill<0)
        {
            timeSkill=0.5f;
            GameObject bullet = Instantiate(vienDan, firePos.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * lucSung, ForceMode2D.Impulse);
        }
    }
}
