using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SunglassesGraber : MonoBehaviour
{
    [SerializeField] private GameObject sunglassesObj;
    private Vector3 m_PlayerPos;
    [SerializeField] private float grabDistance = 5f;
    private bool isInDistance = false;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private Light2D spotLight;
    [SerializeField] private SpriteRenderer sparkelsA;
    [SerializeField] private SpriteRenderer sparkelsB;
    [SerializeField] private SpriteRenderer sparkelsC;
    [SerializeField] private SpriteRenderer sparkelsD;
    [SerializeField] private Sunglasses _sunglasses;
    private Color tempColor;
    private float sparkelsAlpha = 1f;
    [SerializeField] AudioSource holySound;
    [SerializeField] GameObject glassesIcon;

    private bool isGrabed = false;

    private void Start()
    {
        tempColor = sparkelsA.color;
    }
    private void Update()
    {
        m_PlayerPos = this.transform.position;

        if (sunglassesObj)
            if (CalculateObjDistance(sunglassesObj) < grabDistance)
            {
                isInDistance = true;
            }
            else
            {
                isInDistance = false;
            }
        tempColor.a = sparkelsAlpha;

        if(sparkelsA)
        {
            sparkelsA.color = tempColor;
            sparkelsB.color = tempColor;
            sparkelsC.color = tempColor;
            sparkelsD.color = tempColor;
            spotLight.gameObject.transform.position = new Vector3(m_PlayerPos.x, spotLight.gameObject.transform.position.y, spotLight.gameObject.transform.position.z);
        }
        
        if(isGrabed)
        {
            glassesIcon.SetActive(true);   
           
        }
    }
       

    private float CalculateObjDistance(GameObject objPos)
    {
        float distance = Vector3.Distance(m_PlayerPos, objPos.transform.position);
        return distance;
    }

    public void GrabSunglasses()
    {
        if (isInDistance && sunglassesObj)
        {
            this.gameObject.GetComponent<PlayerInput>().enabled = false;
            sunglassesObj.transform.LeanScale(new Vector3(2f, 2f, 0), 2f).setEaseOutQuad();
            sunglassesObj.LeanMove(new Vector3(m_PlayerPos.x, m_PlayerPos.y+ 5f, m_PlayerPos.z), 2f).setEaseInOutQuart().setOnComplete(GrabAnimation);

            //spotLight.gameObject.transform.position = new Vector3(m_PlayerPos.x,spotLight.gameObject.transform.position.y,spotLight.gameObject.transform.position.z);
            spotLight.gameObject.SetActive(true);

            LeanTween.value(1, 0.2f, 2f).setOnUpdate( (float val) => { globalLight.intensity = val; });
            LeanTween.value(0, 1f, 2f).setOnUpdate((float val) => { spotLight.intensity = val; });
            holySound.Play();
            isGrabed = true;
            Invoke("glassesAnimationStart", 5.2f);
        }
    }

    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed)
            GrabSunglasses();
    }

    private void GrabAnimation()
    {
        sunglassesObj.transform.LeanScale(new Vector3(0f, 0f, 0), 5f);
        sunglassesObj.LeanMove(m_PlayerPos, 5f).setOnComplete(LightAnimation);
       
    }
    private void LightAnimation()
    {
        LeanTween.value(1, 0f, 2f).setOnUpdate((float val) => { sparkelsAlpha = val; });
        LeanTween.value(0.2f, 1f, 2f).setOnUpdate((float val) => { globalLight.intensity = val; });
        LeanTween.value(1f, 0f, 2f).setOnUpdate((float val) => { spotLight.intensity = val; }).setOnComplete(DestroyObj);
    }
    private void DestroyObj()
    {
        _sunglasses.setGlassesHolder(true);
        Destroy(spotLight.gameObject);
        Destroy(sunglassesObj);
        this.gameObject.GetComponent<PlayerInput>().enabled = true;
    }

    private void glassesAnimationStart()
    {
        glassesIcon.LeanScale(new Vector3(1.2f, 1.2f, 1.2f), .7f).setOnComplete(glassesIconAnimation);
    }
    private void glassesIconAnimation()
    {
        glassesIcon.LeanScale(Vector3.one, .3f).setEaseInQuart();
    }
}
