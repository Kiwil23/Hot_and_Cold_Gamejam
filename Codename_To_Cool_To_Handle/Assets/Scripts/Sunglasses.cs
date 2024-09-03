using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class Sunglasses : MonoBehaviour
{
    [SerializeField] private GameObject sunglasses;
    private Vector3 m_PlayerPos;
    [SerializeField] private float grabDistance = 5f;
    public bool isHolderOfGlasses = false;
    private bool isInDistance = false;
    [SerializeField] private Light2D globalLight;
    [SerializeField] private Light2D spotLight;
    [SerializeField] private SpriteRenderer sparkelsA;
    [SerializeField] private SpriteRenderer sparkelsB;
    [SerializeField] private SpriteRenderer sparkelsC;
    [SerializeField] private SpriteRenderer sparkelsD;
    private Color tempColor;
    private float sparkelsAlpha = 1f;
    [SerializeField] AudioSource holySound;

    private void Start()
    {
        tempColor = sparkelsA.color;
    }
    private void Update()
    {
        m_PlayerPos = this.transform.position;

        if (sunglasses)
            if (CalculateObjDistance(sunglasses) < grabDistance)
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
    }
       

    private float CalculateObjDistance(GameObject objPos)
    {
        float distance = Vector3.Distance(m_PlayerPos, objPos.transform.position);
        return distance;
    }

    public void GrabSunglasses()
    {
        if (isInDistance && sunglasses)
        {
            this.gameObject.GetComponent<PlayerInput>().enabled = false;
            sunglasses.transform.LeanScale(new Vector3(2f, 2f, 0), 2f).setEaseOutQuad();
            sunglasses.LeanMove(new Vector3(m_PlayerPos.x, m_PlayerPos.y+ 5f, m_PlayerPos.z), 2f).setEaseInOutQuart().setOnComplete(GrabAnimation);

            //spotLight.gameObject.transform.position = new Vector3(m_PlayerPos.x,spotLight.gameObject.transform.position.y,spotLight.gameObject.transform.position.z);
            spotLight.gameObject.SetActive(true);

            LeanTween.value(1, 0.2f, 2f).setOnUpdate( (float val) => { globalLight.intensity = val; });
            LeanTween.value(0, 1f, 2f).setOnUpdate((float val) => { spotLight.intensity = val; });
            holySound.Play();
        }
    }

    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed)
            GrabSunglasses();
    }

    private void GrabAnimation()
    {
        sunglasses.transform.LeanScale(new Vector3(0f, 0f, 0), 5f);
        sunglasses.LeanMove(m_PlayerPos, 5f).setOnComplete(LightAnimation);
        isHolderOfGlasses = true;
    }
    private void LightAnimation()
    {
        LeanTween.value(1, 0f, 2f).setOnUpdate((float val) => { sparkelsAlpha = val; });
        LeanTween.value(0.2f, 1f, 2f).setOnUpdate((float val) => { globalLight.intensity = val; });
        LeanTween.value(1f, 0f, 2f).setOnUpdate((float val) => { spotLight.intensity = val; }).setOnComplete(DestroyObj);
    }
    private void DestroyObj()
    {
        Destroy(spotLight.gameObject);
        Destroy(sunglasses);
        this.gameObject.GetComponent<PlayerInput>().enabled = true;
    }
}
