using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0,1,0), ForceMode.Acceleration);
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        if (transform.position.y>300f)
        {
            Destroy(gameObject);
        }
    }
}
