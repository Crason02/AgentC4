using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ResumeScript : MonoBehaviour
{
    public Slider slider;
    public CameraScript cs;
    public PlayerScript ps;
    public GameObject resumeHole;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cs.sensitivity = slider.value;
    }

    public void resume()
    {
        resumeHole.SetActive(false);
        cs.pause = false;
        ps.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
