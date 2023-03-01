using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabGlaasses : MonoBehaviour
{
    // make glasses disapear after they are held of 2 seconds
    [SerializeField] private bool glassesGrabbed = false;
    private float time = 0;
    private float timeToWait = 2;
    private bool glassesGrabbed2 = false;
    private void Awake()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(SetGlassesTrue);
    }

    public void SetGlassesTrue(ActivateEventArgs arg)
    {
        glassesGrabbed = true;
    }

    public bool GetGlassesTrue()
    {
        return glassesGrabbed;
    }

    void Update()
    {
        if (glassesGrabbed)
        {
            time += Time.deltaTime;
            if (time > timeToWait)
            {
                glassesGrabbed2 = true;
                gameObject.SetActive(false);
            }
        }
    }

    public bool GetGlassesTrue2()
    {
        return glassesGrabbed2;
    }
    
    
    

    

}
