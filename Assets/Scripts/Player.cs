using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


    Animator anim;
    int animSwitch=0;
    public Slider energyBar;
    public Text score;
    private float scoreF=0;
    private float scoreM = 0.5f;
    public float barSpeed = 1;
    private float horizontal;
    private Rigidbody2D rb;
    public float speed = 5;
    private bool enableMovement = true;
    private bool enableDoorWalk = false;
    private bool enableStairsWalk = false;
    public static bool gameover = false;
    private bool playerOutOfScore=false;
    private BoxCollider2D box;
    private SpriteRenderer sprite; 

    //bool disableControls = false;
    private Vector3 endPoint = Vector3.zero;

    void Start() {
        //HPsys.addHP(3);
        anim = GetComponent<Animator>();
        enableMovement = true;
        //horizontal = Input.GetAxis("Horizontal");
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void FixedUpdate() {



        Anim();
        if (!playerOutOfScore)
            scoreF += scoreM*Time.deltaTime;
        horizontal = Input.GetAxisRaw("Horizontal");
        PlayerMovement();

        if(energyBar.value == 0f)
        {
            Debug.Log("GameOver");
            gameover = true;
        }

        if (energyBar.value == energyBar.maxValue)
        {
            scoreM *= 2f;
            if (spawner.test_czas>0.8f)
                spawner.test_czas -= 0.2f;
            
            spawner.nextLvl = true;
            ///Debug.Log(spawner.test_czas);
            energyBar.value = 2f;
            HPsys.addHP(3);
        }
        if (gameover)
        {
            playerOutOfScore = true;
            gameover = false;
            GameOver();
        }


    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        score.text = ""+(int)scoreF;
        energyBar.value -= barSpeed*Time.deltaTime;

        if (gameObject.layer == LayerMask.NameToLayer("PlayerHide"))
        {

            if (horizontal != 0)
            {
                sprite.sortingOrder = 10;
                box.size = new Vector2(0.64f, 0.94f);
                playerOutOfScore = false;
                enableMovement = true;
                gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        DoorColl(coll);
        StairsColl(coll);
        Hideout(coll);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Boost")
        {
            Debug.Log("hi");
            energyBar.value += 2f;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //energyBar.value -= 0.5f;
            HPsys.addHP(-1);
        }
    }
    //Player Related
    void PlayerMovement()
    {
        

        if (enableMovement)
        {
            rb.AddForce(new Vector2(horizontal, 0f) * speed);
            if (rb.velocity.x != 0)
                animSwitch = 1;
            else if (animSwitch != 2)
                animSwitch = 0;
        }

        InDoorMovement();
        InStairsMovement();

    }
    void PlayerInAction(float endPointX, float endPointY)
    {
        rb.velocity = Vector2.zero;
        rb.gameObject.layer = LayerMask.NameToLayer("PlayerInAction");
        rb.gravityScale = 0;
        endPoint = new Vector3(endPointX, endPointY, 0f);
        //enableDoorWalk = true;
    }
    void PlayerOutOfAction()
    {
        rb.gameObject.layer = LayerMask.NameToLayer("Player");
        
        enableMovement = true;
        rb.gravityScale = 1;
    }

    //Doors Related
    void InDoorMovement()
    {
        // enableMovement = false;
        if (enableDoorWalk)
        {
            enableMovement = false;
            animSwitch = 1;
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, endPoint, 2f * Time.deltaTime);
        }
        if (rb.transform.position == endPoint)
        {
            PlayerOutOfAction();
            enableDoorWalk = false;
        }
        //enableMovement = true;

    }
    void DoorColl(Collider2D coll)
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (coll.tag == "DoorL")
            {
                PlayerInAction(coll.transform.position.x + 0.6f, rb.transform.position.y);
                enableDoorWalk = true;
                
            }
            if (coll.tag == "DoorR")
            {
                PlayerInAction(coll.transform.position.x - 0.6f, rb.transform.position.y);
                enableDoorWalk = true;

            }
        }
    }
    //Stairs Related
    void InStairsMovement()
    {
        if (enableStairsWalk)
        {
            enableMovement = false;
            animSwitch = 1;
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, endPoint, 3f * Time.deltaTime);
            //AnimPlayer.animSwitch = 3;
        }
        if (rb.transform.position == endPoint)
        {
            PlayerOutOfAction();
            enableStairsWalk = false;
        }
    }
    void StairsColl(Collider2D coll)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
            if (coll.tag == "StairsUP")
            {
                PlayerInAction(coll.transform.position.x + 1.5f, coll.transform.position.y - 1.8f);
                enableStairsWalk=true;
                rb.transform.position = coll.transform.position;
            }
            if (coll.tag == "StairsDWN")
            {
                PlayerInAction(coll.transform.position.x - 1.2f, coll.transform.position.y + 1.8f);
                enableStairsWalk = true;
                rb.transform.position = coll.transform.position;
            }
        }
        
    }

    void Hideout(Collider2D coll)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(coll.tag == "Hideout")
            {
                if (gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    box.size = new Vector2(0.46f, 0.46f);
                    sprite.sortingOrder = 4;
                    playerOutOfScore = true;
                    animSwitch = 2;
                    rb.velocity = Vector2.zero;
                    horizontal = 0f;
                    transform.position = coll.transform.position;
                    //enableMovement = false;
                    gameObject.layer = LayerMask.NameToLayer("PlayerHide");
                }
            }
           
        }

    }

    void GameOver()
    {
        PlayerPrefs.SetInt("YourScore", (int)scoreF);
        if(PlayerPrefs.GetInt("HighScore")<(int)scoreF)
            PlayerPrefs.SetInt("HighScore", (int)scoreF);
        rb.isKinematic = true;
        enableMovement = false;
        gameObject.layer = LayerMask.NameToLayer("GG");
        Invoke("EndScreen", 2f);
    }
    void EndScreen()
    {
         SceneManager.LoadScene("END");
        Debug.Log("gg");
    }


    void Anim()
    {

        switch (animSwitch)
        {
            case 0:
                anim.SetInteger("animSwich", 0);
                break;
            case 1:
                anim.SetInteger("animSwich", 1);
                break;
            case 2:
                anim.SetInteger("animSwich", 2);
                break;
            // case 3:
            //   anim.SetInteger("animSwich", 3);
            //  break;
            default:
                anim.SetInteger("animSwich", 0);
                break;
        }




    }
}
