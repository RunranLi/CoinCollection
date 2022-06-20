/****
 * Created by: Runran Li
 * Date Created: June 20, 2022
 *
 * Last Edited by:
 * Last Edited:
 *
 * Description: Manages collections and wining conditions.
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    /***VARIABLES***/
    [Tooltip("Number of collectables to beat level")]
    public int winCollectAmount; //number of collectables to beat the level
    [Tooltip("Use the total number of collectables for the win amount")]
    public bool useCollectableCount; //Do we use the collectable countt
    [HideInInspector]
    private bool hasCollectedAll = false; //have all collectables been collected
    private int collectablesInCollection = 0; //number of collectables collected by player 

    // Start is called before the first frame update
    void Start()
    {
        //if we are using the collectable count
        if (useCollectableCount)
        {
            //set the win amount to the amout of collectables in the scene
            winCollectAmount = Collectable.collectableCount;
        }//end if(useCollectableCount)
        Debug.Log("Win collect amount: " + winCollectAmount);

    }

    // Update is called once per frame
    void Update()
    {
        if (collectablesInCollection == winCollectAmount)
        {
            hasCollectedAll = true;
            Debug.Log("You win!");
        }

    }

    //Add to collection
    public void AddToCollection()
    {
        collectablesInCollection++; //add to cmount in collection
        Debug.Log("Collectable Added");
    }//end AddToCollection()

}
