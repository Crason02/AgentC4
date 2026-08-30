using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator handAni;
    [SerializeField] Animator throwAni;
    public float moveSpeed;
    public Slider waitSlider;
    public float sprintSpeed;
    public bool spawnable = true;
    public GameObject dynamite;
    public float waitMax = 1f;
    public float waitTime;
    public Transform camTrans;
    public Image di;
    public bool pause = false;
    public List<string> tags = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnable == false)
        {
            waitTime+=Time.deltaTime;
            waitSlider.value = (1/waitMax)*(waitMax-waitTime);
            if (waitTime>=waitMax)
            {
                waitSlider.value = 0f;
                spawnable = true;
                waitTime = 0f;
                Color tempCol = di.color;
                tempCol.a = 1f;
                di.color = tempCol;
            }
        }
        if (pause)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.forward*z+transform.right*x;
        move*=moveSpeed;
        move = new Vector3(move.x, rb.linearVelocity.y, move.z);
        rb.linearVelocity = move;
        if (Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
        {
            handAni.SetBool("walking", true);
        }
        else
        {
            handAni.SetBool("walking", false);
        }
        if (Input.GetMouseButton(0)&&spawnable)
        {
            spawnable = false;
            throwAni.SetTrigger("Throw");
        }
    }

    public void spawnDyna()
    {
        Vector3 spawnPos = new Vector3(transform.position.x+0.4f, transform.position.y+1f, transform.position.z);
        GameObject temp = Instantiate(dynamite, spawnPos, Random.rotation);
        Rigidbody rb = temp.GetComponent<Rigidbody>();
        rb.AddForce(camTrans.forward*2000f);
        Vector3 tempR = new Vector3(Random.Range(-5f,0f),Random.Range(-5f,5f),Random.Range(-1f,1f));
        rb.AddRelativeTorque(tempR);
        waitTime = 0f;
        spawnable = false;
        Color tempCol = di.color;
        tempCol.a = 0f;
        di.color = tempCol;
        waitSlider.value = (waitMax-waitTime);
    }
}
