using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Button GameOver;
    public GameObject GOWipe;
    private bool canShoot = true;
    public float coolTime;
    

    [Header("Movement Attribute")]
    public float speed = 5;
    public float rotAngle = 0;
    public float turnSmoothTime = 0.2f;
    public Vector3 forward;
    float turnnSmoothVelocity;
    [Header("Reference")]
    CharacterController controller;
    public float inputHorizontal;
    public float inputVertical;

    [Header("Body parts reference")]

    
    public GameObject m_inpul_left;
    public GameObject m_inpul_Right;

    [Header("Platform")]
    public bool PC = true;

    
    //public Camera mainCamera;
    public GameObject bullet;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
       
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = new Vector3(this.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
        inputHorizontal = Input.GetAxisRaw("Vertical");

        if (!PC && controller){
            controller.Move(Vector3.forward * m_inpul_left.GetComponent<MobileInputController>().Vertical * Time.deltaTime * speed + Vector3.right * m_inpul_left.GetComponent<MobileInputController>().Horizontal * Time.deltaTime * speed);
        }else{
            controller.Move(Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * speed + Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed);
        }

        Vector3 from = new Vector3(0f, 0f, 1f);
        Vector3 to = new Vector3(m_inpul_Right.GetComponent<MobileInputController>().Horizontal, 0f, m_inpul_Right.GetComponent<MobileInputController>().Vertical);
        //forward = lowerBody.transform.forward;

        if (m_inpul_Right.GetComponent<MobileInputController>().Horizontal != 0 && m_inpul_Right.GetComponent<MobileInputController>().Vertical != 0)
        {
            float angle = Vector3.SignedAngle(from, to, Vector3.up);
            rotAngle = angle;
            
            if (canShoot)
            {
                Instantiate(bullet, transform.position + transform.forward, Quaternion.identity).GetComponent<Bullet>().Init(transform.forward, 10);
                FindObjectOfType<AudioManager>().Play("Player Shot");
                canShoot = false;
                animator.SetBool("isShooting", true);
                StartCoroutine("Cooldown");
            } else animator.SetBool("isShooting", false);
            // if (angle > 60 || angle <-60)
            //{
            //   float targetRotation = Mathf.Atan2(m_inpul_Right.GetComponent<MobileInputController>().Horizontal, m_inpul_Right.GetComponent<MobileInputController>().Vertical) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref turnnSmoothVelocity, turnSmoothTime);
            // }

            //  float targetRotationForUpperBody = Mathf.Atan2(m_inpul_Right.GetComponent<MobileInputController>().Horizontal, m_inpul_Right.GetComponent<MobileInputController>().Vertical) * Mathf.Rad2Deg;
            // transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(upperBody.transform.eulerAngles.y, targetRotationForUpperBody, ref turnnSmoothVelocity, turnSmoothTime);

            // transform.eulerAngles = new Vector3(0f, angle, 0f);
        }

        if (m_inpul_left.GetComponent<MobileInputController>().Horizontal != 0 || m_inpul_left.GetComponent<MobileInputController>().Vertical != 0)
        {
            animator.SetBool("isRunning", true);
        } else animator.SetBool("isRunning", false);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {   if(gameObject != null)
        { 
            if (hit.gameObject.tag == "Bullet")
            {
                
                PlayerOver();
            }
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Bullet")
        {
            
            GameObject.Find("UbhObjectPool").GetComponent<UbhObjectPool>().ReleaseAllBullet();
            GameObject.Find("Enemy").GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
            GameObject.Find("Enemy").GetComponent<UbhShotCtrl>().enabled = false;
            GameOver.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(coolTime);
        canShoot = true;
    }

    public void PlayerOver()
    {
        GOWipe.SetActive(true);

        FindObjectOfType<AudioManager>().Play("Player Death");
        GameObject.Find("Enemy").GetComponent<UbhShotCtrl>().StopShotRoutineAndPlayingShot();
        GameObject.Find("Enemy").GetComponent<UbhShotCtrl>().enabled = false;
        GameOver.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
