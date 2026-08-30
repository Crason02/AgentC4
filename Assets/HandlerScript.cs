using UnityEngine;

public class HandlerScript : MonoBehaviour
{
    public PlayerScript ps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        ps.spawnDyna();
    }
}
