using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sunglasses : MonoBehaviour
{
    private bool isGlassesHolder = false;
    [SerializeField] private GameObject sun;
    private bool isSunOut;
   private void Start()
    {
        
    }

   private void Update()
    {
        
    }

    public void setGlassesHolder(bool isHolder)
    {
        isGlassesHolder = isHolder;
    }

    public void HeatUp(InputAction.CallbackContext context)
    {
       if(isGlassesHolder)
        {
            isSunOut = context.performed;
        }

       if(isSunOut)
        {
            sun.SetActive(true);
        }
       else
        {
            sun.SetActive(false);
        }
    }
}
