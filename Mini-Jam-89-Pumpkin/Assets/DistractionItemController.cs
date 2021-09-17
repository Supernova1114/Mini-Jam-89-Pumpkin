using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionItemController : MonoBehaviour
{
    [SerializeField]
    private bool shouldEat = false;
    [SerializeField]
    private bool shouldScare = false;

    //Depending on what type of item it is indicates if it is throwable or just placeable (determined in player script???) (ex: hay bale = placeable,
    //carrot and apple = throwable, fake rat = throwable). horse will go towards distraction object when thrown, then sit
    //there for a bit (eat) and then when the item dissapears the Horseman continues going to your location, or looking for you.

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Horseman"))
        {

        }
    }


}
