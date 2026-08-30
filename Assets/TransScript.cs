using UnityEngine;
using UnityEngine.SceneManagement;
public class TransScript : MonoBehaviour
{
    public GameObject tospawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
    {
        if (SceneManager.GetActiveScene().name=="SampleScene")
        {
            SceneManager.LoadScene("EndScene");
            return;
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void spawn()
    {
        tospawn.SetActive(true);
    }
}
