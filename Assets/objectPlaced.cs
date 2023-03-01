using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPlaced : MonoBehaviour
{
    public GameObject youWin;
    public GameObject instruction;
    
    // Start is called before the first frame update
    void Start()
    {
        youWin.SetActive(false);
        instruction.SetActive(true);
    }

    // Update is called once per frame  
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // if CorrosionBottle is placed on the table then the game is won

        if (other.gameObject.name == "CorrosionBottle")
        {
            Debug.Log("You Win!");
            youWin.SetActive(true);
            instruction.SetActive(false);
        }
        else
        {
            Debug.Log("Placed");
        }
        
        
    }
    
    
}
