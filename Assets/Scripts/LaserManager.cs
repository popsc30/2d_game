using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public HeroManager heroCopy;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
       counter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        counter++;
        if(counter%20==0)
        {
            counter = 0;
            heroCopy.UpdateHealth(1, false);
        }
    }
}
