using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public Animator animator;
    public bool isRight = true;
    public bool isUp = true;
    // private bool nen;
    public TextMeshProUGUI txtDiem;
    private int tong = 0;
    public AudioSource sChem, sCoin, sNen;
    public GameObject skill, skilln, chem, x2;
    public Transform fire, x2Pos;
    public float timeSkill=0.2f;
    public float timeX2=0.2f;

    public float skillForce, X2Force;
    private float timeSkill2, X2time;
    public GameObject menu;
    public GameObject Question, Question_1, Question_2, Question_3, Question_4, Question_5, Question_6, Question_7, Question_8, Question_9;

    private bool isPlaying = true;
    private bool isAnwser = true;
    private int bodem = 0;


    void tinhTong(int score)
    {
        tong += score;
        txtDiem.text = "Score: " + tong;
    }
    void Start()
    {
        sNen.Play();
        animator = GetComponent<Animator>();
        tinhTong(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
            animator.SetBool("Run", true);
            transform.Translate(Time.deltaTime*10, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        
        if (Input.GetKey(KeyCode.A))
        {   
            isRight = false;
            animator.SetBool("Run", true);
            transform.Translate(-Time.deltaTime*10, 0, 0);
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
        // if (nen)
        // {
        if (Input.GetKey(KeyCode.W))
            {
                if (isRight)
                    {
                        animator.SetBool("Run", true);
                        transform.Translate(Time.deltaTime*5, Time.deltaTime*20, 0);
                        Vector2 scale = transform.localScale;
                        scale.x *= scale.x > 0 ? 1 : -1;
                        transform.localScale = scale;
                    }
                    else
                    {
                        animator.SetBool("Run", true);
                        transform.Translate(-Time.deltaTime*5, Time.deltaTime*20, 0);
                        Vector2 scale = transform.localScale;
                        scale.x *= scale.x > 0 ? -1 : 1;
                        transform.localScale = scale;
                    }
                

                // nen = false;
            }
        // }
        timeSkill2 -= Time.deltaTime;
        if (Input.GetKey(KeyCode.R) && timeSkill2<0)
        {
            if (isUp)
            {
                sChem.Play();
                if (isRight)
                {
                    animator.SetBool("Attack", true);
                    timeSkill2 = timeSkill;
                    GameObject skillTmp = Instantiate(skill, fire.position, Quaternion.identity);
                    Rigidbody2D rb = skillTmp.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.right * skillForce, ForceMode2D.Impulse);
                }
                else
                {
                    animator.SetBool("Attack", true);
                    timeSkill2 = timeSkill;
                    GameObject skillTmp = Instantiate(skilln, fire.position, Quaternion.identity);
                    Rigidbody2D rb = skillTmp.GetComponent<Rigidbody2D>();
                    rb.AddForce(-transform.right * skillForce, ForceMode2D.Impulse);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            showMenu();
        }
        X2time -= Time.deltaTime;
        restart();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            sCoin.Play();
            var nameB = other.gameObject.name;
            Destroy(GameObject.Find(nameB));
            tinhTong(20);
        }
    }
    public void showMenu()
    {
        if (isPlaying)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            isPlaying = false;
        }
        else
        {
            menu.SetActive(false);
            Time.timeScale = 1;
            isPlaying = true;

        }
    }

    public void restart()
    {
        Vector3 pos = transform.position;
        if (pos.y < -7)
        {
            pos.x = -8;
            pos.y = 4;
            pos.z = 0;
            transform.position = pos;
        }
    }
    
    
}
