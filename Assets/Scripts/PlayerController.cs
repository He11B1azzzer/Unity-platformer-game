using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float gravity = 9.81f;
    public int jumpsLeft = 2;
    public static float points = 0.0f;
    public static int pointsCounter = 0;
    public static int pointsObjects;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator anim;
    void Start()
    {
        pointsObjects = GameObject.FindGameObjectsWithTag("Points").Length;
        points = 0.0f;
        pointsCounter = 0;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 prevPos = anim.transform.position;
        Movement();
        Jumping();
        if (anim.gameObject.transform.position.x != 0)
        {
            anim.transform.position = new Vector3(0, prevPos.y, prevPos.z);
        }
        if (anim.gameObject.transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit someObject)
    {
        if (someObject.collider.tag == "Final")
        {
            SceneManager.LoadScene("LevelComplete");
        }

        if (someObject.collider.tag == "Points")
        {
            pointsCounter += 1;
            points += 0.1f;
            Destroy(someObject.gameObject);
        }
    }

    void Movement()
    {
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (anim.gameObject.transform.eulerAngles.y >= 180 && anim.gameObject.transform.eulerAngles.y <= 181)
                {
                    anim.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                anim.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (anim.gameObject.transform.eulerAngles.y >= 0 && anim.gameObject.transform.eulerAngles.y <= 1)
                {
                    anim.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                anim.SetInteger("Condition", 1);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
            }
            else
            {
                anim.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }
    }

    void Jumping()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            anim.SetInteger("Jumps", 1);
            jumpsLeft -= 1;
            moveDir.y = speed * 2.5f;
        }
        else if (!controller.isGrounded && anim.GetInteger("Falls") == 1 && Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            anim.SetInteger("Falls", 0);
            anim.SetInteger("Jumps", 1);
            jumpsLeft -= 1;
            moveDir.y = speed * 3.0f;
        }
        else if (!controller.isGrounded && anim.GetInteger("Jumps") == 1)
        {
            anim.SetInteger("Jumps", 0);
            anim.SetInteger("Falls", 1);
        }
        else if (controller.isGrounded && anim.GetInteger("Jumps") == 0)
        {
            anim.SetInteger("Falls", 0);
            jumpsLeft = 2;
        }
        else if (!controller.isGrounded && anim.GetInteger("Condition") == 1)
        {
            anim.SetInteger("Falls", 1);
        }
        else if (controller.isGrounded && anim.GetInteger("Condition") == 0)
        {
            anim.SetInteger("Jumps", 0);
            anim.SetInteger("Falls", 0);
        }
    }
}