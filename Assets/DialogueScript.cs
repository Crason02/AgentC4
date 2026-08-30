using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class DialogueScript : MonoBehaviour
{
    public Animator ani;
    public string[] d1;
    public int[] f1;
    public string[] d2;
    public int[] f2;
    public string[] d3;
    public int[] f3;
    public string[] d4;
    public int[] f4;
    public string[] d5;
    public int[] f5;
    public string[] d6;
    public int[] f6;
    public string[] d7;
    public int[] f7;
    public GameObject firstHolder;
    public GameObject secondHolder;
    public GameObject thirdHolder;
    public GameObject fourthHolder;
    public GameObject fifthHolder;
    public GameObject sixthHolder;
    public GameObject seventhHolder;
    public Sprite[] faceSprites;
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI bossDisplay;
    public Image sr;
    public PlayerScript ps;
    public CameraScript cs;
    public bool talking = false;
    public int diaIndex;
    public int messageIndex;
    private string[][] dialogues;
    private int[][] faces;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
{
    dialogues = new string[7][];
    faces = new int[7][];

    dialogues[0] = d1;
    dialogues[1] = d2;
    dialogues[2] = d3;
    dialogues[3] = d4;
    dialogues[4] = d5;
    dialogues[5] = d6;
    dialogues[6] = d7;

    faces[0] = f1;
    faces[1] = f2;
    faces[2] = f3;
    faces[3] = f4;
    faces[4] = f5;
    faces[5] = f6;
    faces[6] = f7;
    dialogue(5);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&talking)
        {
            nextMessage();
        }
    }

    public void nextMessage()
    {
        ani.SetTrigger("pop");
        messageIndex+=1;
        if (messageIndex == dialogues[diaIndex].Length)
        {
            endDialogue();
            return;
        }
        textDisplay.text = dialogues[diaIndex][messageIndex];
        sr.sprite = faceSprites[faces[diaIndex][messageIndex]];
    }
    
    public void dialogue(int diaNum)
    {
        bossDisplay.text = "boss";
        if (diaNum==2)
        {
            bossDisplay.text="4sa78vp";
        }
        diaIndex = diaNum;
        messageIndex = 0;
        if (diaNum!=0)
        {
            ani.SetTrigger("start");
        }
        talking = true;
        cs.pause = true;
        ps.pause = true;
        sr.sprite = faceSprites[faces[diaIndex][messageIndex]];
        textDisplay.text = dialogues[diaIndex][messageIndex];
    }

    public void endDialogue()
    {
        ani.SetTrigger("end");
        talking = false;
        cs.pause = false;
        ps.pause = false;
        if (diaIndex==0)
        {
            ps.tags.Add("barrel");
            firstHolder.SetActive(true);
        }
        if (diaIndex==1)
        {
            ps.tags.Add("cone");
            secondHolder.SetActive(true);
            ps.moveSpeed+=2.5f;
        }
        if (diaIndex==2)
        {
            ps.tags.Add("garbage");
            thirdHolder.SetActive(true);
            StartCoroutine(waitGarbageMessage());
        }
        if (diaIndex==3)
        {
            ps.tags.Add("sign");
            fourthHolder.SetActive(true);
        }
        if (diaIndex==4)
        {
            ps.tags.Add("ball");
            fifthHolder.SetActive(true);
            StartCoroutine(waitBallMessage());
        }
        if (diaIndex==5)
        {
            ps.tags.Add("balloon");
            sixthHolder.SetActive(true);
            StartCoroutine(waitBenchMessage());
        }
        if (diaIndex==6)
        {
            ps.tags.Add("bench");
            seventhHolder.SetActive(true);
            StartCoroutine(waitBenchMessage());
        }
    }

    IEnumerator waitGarbageMessage()
    {
        yield return new WaitForSeconds(35f);
        dialogue(3);
    }

    IEnumerator waitBallMessage()
    {
        yield return new WaitForSeconds(35f);
        dialogue(5);
    }
    IEnumerator waitBenchMessage()
    {
        yield return new WaitForSeconds(25f);
        dialogue(6);
    }
}
