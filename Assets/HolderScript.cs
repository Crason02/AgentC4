using UnityEngine;
using System.Collections.Generic;
public class HolderScript : MonoBehaviour
{
    public DialogueScript ds;
    public ChildScript cs;
    public string type;
    public List<GameObject> children = new List<GameObject>();
    public int childAmt;
    public bool fired;
    public int minChildsKilled;
    public int ogCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ds = GameObject.Find("DialoguePanel").GetComponent<DialogueScript>();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
            child.gameObject.AddComponent<ChildScript>();
        }
        childAmt = children.Count;
        ogCount = children.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseChild(GameObject lost)
    {
        children.Remove(lost);
        childAmt = children.Count;
        if (fired)
        {
            return;
        }
        if (type=="barrel")
        {
            if (childAmt<=(ogCount-minChildsKilled))
            {
                fired = true;
                ds.dialogue(1);
            }
        }
        if (type=="cone")
        {
            if (childAmt<=(ogCount-minChildsKilled))
            {
                fired = true;
                ds.dialogue(2);
            }
        }
        if (type=="sign")
        {
            if (childAmt<=(ogCount-minChildsKilled))
            {
                fired = true;
                ds.dialogue(4);
            }
        }
    }
}
