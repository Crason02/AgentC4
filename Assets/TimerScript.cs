using UnityEngine;
using TMPro;
public class TimerScript : MonoBehaviour
{
    public int minutes;
    public float seconds;
    public TextMeshProUGUI tmp;
    public ScreenShakeScript sss;
    public GameObject outro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sss.maxAngle = 3f;
        sss.traumaDecay = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        seconds-=Time.deltaTime;
        if (seconds<=0)
        {
            if (minutes==0)
            {
                outro.SetActive(true);
            }
            else
            {
                minutes-=1;
                seconds=59.9f;
            }
        }
        if (seconds<10)
        {
            tmp.text = minutes+":"+"0"+(int)seconds;
        }
        else
        {
            tmp.text = minutes+":"+(int)seconds;
        }
    }
}
