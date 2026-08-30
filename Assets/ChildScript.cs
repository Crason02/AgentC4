using UnityEngine;

public class ChildScript : MonoBehaviour
{
    private HolderScript hs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hs = transform.parent.GetComponent<HolderScript>();
    }

    private void OnDestroy() {
        hs.loseChild(gameObject);
    }
}
