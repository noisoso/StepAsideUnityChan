using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    private Rigidbody myrigidbody;
    private Animator myAnimator;
    public float sp = 1f;
    private float velocityZ = 16f;
    private float velocityX = 10f;
    public float velocityY = 10f;
    private float movableRange = 3.4f;
    private float coefficient = 0.99f;
    public  bool isEnd = false;
    private GameObject stateText;
    private GameObject scoreText;
    private int score = 0;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;
    private bool isJButtonDown = false;

    List<int> kago = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        this.myrigidbody = GetComponent<Rigidbody>();
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");

    }

    // Update is called once per frame
    void Update()
    {

        if (this.isEnd)
        {
            this.velocityX *= this.coefficient;
            this.velocityZ *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }





        float inputVelocityY = 0;
        float inputVelocityX = 0;

        if ((Input.GetKey(KeyCode.RightArrow) || (this.isRButtonDown)) && this.movableRange > this.transform.position.x)
        {
            inputVelocityX = this.velocityX;
        }

        else if ((Input.GetKey(KeyCode.LeftArrow) || (this.isLButtonDown)) && -this.movableRange < this.transform.position.x)
        {
            inputVelocityX = -velocityX;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || (this.isJButtonDown)) && this.transform.position.y < 0.5f && !kago.Contains(1))
        {
            StartCoroutine("Seigen");
            this.myAnimator.SetBool("Jump", true);
            inputVelocityY = velocityY;
        }
        else
        {

            inputVelocityY = this.myrigidbody.velocity.y;
        }
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }



        this.myrigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.stateText.GetComponent<Text>().text = "GAME OVER";
            this.isEnd = true;
        }
        if (other.gameObject.tag == "GoalTag")
        {

            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        if (other.gameObject.tag == "CoinTag")
        {
            this.score += 10;
            this.scoreText.GetComponent<Text>().text = "Score " + score + "pt";
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);


        }
    }



    IEnumerator Seigen()
    {

        kago.Add(1);
        yield return new WaitForSeconds(0.8f);
        kago.Remove(1);

    }

    public void GetmyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }
    public void GetmyjumpButtonUp()
    {
        this.isJButtonDown = false;
    }
    public void GetmyRightButtonDown()
    {
        this.isRButtonDown = true;
    }

    public void GetmyRightButtonUp()
    {
        this.isRButtonDown = false;
    }

    public void GetmyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }

    public void GetmyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }


}
