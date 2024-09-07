using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Sunglasses : MonoBehaviour
{
    public bool isGlassesHolder = false;
    [SerializeField] private GameObject sun;
    private bool isSunOut;
    [SerializeField] private float scaleFactorOut = 1f;
    [SerializeField] private float scaleFactorOff = 1f;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 maxScale;
    private Vector3 scale;
    private bool isLimitReached = false;
    [SerializeField] private float limitFactor = 1;

  
    [SerializeField] private Light2D light2D;
    [SerializeField] private float lightOuterRadius = 4.77f;
    [SerializeField] private Image glassesIcon;
    [SerializeField] private List<Sprite> sprites;

    public void setGlassesHolder(bool isHolder)
    {
        isGlassesHolder = isHolder;
    }
    private void Update()
    {
        if (isSunOut)
        {
            glassesIcon.sprite = sprites[1];

            if (sun.transform.localScale.x <= maxScale.x *limitFactor && !isLimitReached)
            {
                scale.x += scaleFactorOut * Time.deltaTime;
                scale.y += scaleFactorOut * Time.deltaTime;
                scale.z += scaleFactorOut * Time.deltaTime;
                

            }

        }
        else
        {
            glassesIcon.sprite = sprites[0];
            if (sun.transform.localScale.x > 0)
            {
                scale.x -= scaleFactorOff * Time.deltaTime;
                scale.y -= scaleFactorOff * Time.deltaTime;
                scale.z -= scaleFactorOff * Time.deltaTime;
                isLimitReached = false;
            }         
        }

        light2D.pointLightOuterRadius = (scale.x * lightOuterRadius)/maxScale.x;

        if (!isSunOut && sun.transform.localScale.x <= 0)
        {
            SunOff();
           
        }

        sun.transform.localScale = scale;

    }

    public void HeatUp(InputAction.CallbackContext context)
    {
        if (isGlassesHolder)
        {
            isSunOut = context.performed;
        }

        if (isSunOut)
        {
            SunOut();
        }

    }
    private void SunOut()
    {          
            sun.SetActive(true);
            animator.SetBool("_glasses", true);
    }

    private void SunOff()
    {
        sun.SetActive(false);
        animator.SetBool("_glasses", false);
    }
    private void sunAnimation()
    {
        sun.LeanScale(maxScale, scaleFactorOff).setEaseInQuart();
    }

    private void DeactivateSun() 
    {
        //sun.SetActive(false);
        //animator.SetBool("_glasses", false);
    }
}
