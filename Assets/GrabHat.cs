using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHat : MonoBehaviour
{
    //make hat disapear after it is held for 2 seconds

    [SerializeField] private bool hatGrabbed = false;
    private float time = 0;
    private float timeToWait = 2;
    private bool hatGrabbed2 = false;
    private void Awake()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(SetHatTrue);
    }

    public void SetHatTrue(ActivateEventArgs arg)
    {
        hatGrabbed = true;
    }

    public bool GetHatTrue()
    {
        return hatGrabbed;
    }

    void Update()
    {
        if (hatGrabbed)
        {
            time += Time.deltaTime;
            if (time > timeToWait)
            {
                hatGrabbed2 = true;
                gameObject.SetActive(false);
            }
        }
    }

    public bool GetHatTrue2()
    {
        return hatGrabbed2;
    }
    
    
    
}
