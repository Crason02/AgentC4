using UnityEngine;
using System.Collections.Generic;
public class DynamiteScript : MonoBehaviour
{
    public GameObject explosion;
    public ScreenShakeScript sss;
    public bool ticking = false;
    public float waitTime = 2f;
    public Animator ani;
    public List<string> tags = new List<string>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tags = GameObject.Find("Player").GetComponent<PlayerScript>().tags;
    }

    // Update is called once per frame
    void Update()
    {
        if (ticking)
        {
            waitTime-=Time.deltaTime;
            if (waitTime<=0)
            {
                ani.enabled = true;
                ticking = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        for (int x=0; x<tags.Count; x++)
        {
            if (other.CompareTag(tags[x]))
            {
                sss = GameObject.Find("ScreenShakeHolder").GetComponent<ScreenShakeScript>();
                sss.AddTrauma(0.5f);
                Instantiate(explosion, transform.position, transform.rotation).transform.localScale = new Vector3(0.1f,0.1f,0.1f);
                Destroy(other.gameObject);
                Destroy(gameObject);
                return;
            }
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        ticking = true;
    }

    public void decay() {
        Destroy(gameObject);
    }
}
