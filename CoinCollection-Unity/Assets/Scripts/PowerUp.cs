using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    private Timer timer; //reference to level timer

    // Start is called before the first frame update
    void Start()
    {
        timer = Timer.LevelTimer; //reference the level timer
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collectable Triggered");

        if (other.tag == "Player")
        {
            other.GetComponent<Timer>().AddTime(); //call method on the Timer component of other object

            Destroy(gameObject); //destroy this gameObject (collectable object)
        }
    }//end OnTriggerEnter()
}
