using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    private float followSpeed;
    [SerializeField] private float followSpeedLow = 2f;
    [SerializeField] private float followSpeedHigh = 5f;
    [SerializeField] private float yOffset = 0;
    [SerializeField] private float runningOffset = 1f;
    [SerializeField] private float runningOffsetSpeed = 3f;
    private Vector3 m_newPos;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private float lookAheadDragR = 13f;
    [SerializeField] private float lookAheadDragL = 13f;
    [SerializeField] private float xOffsetR = 15;
    [SerializeField] private float xOffsetL = 15;
    [SerializeField] private float lowYOffset;
    [SerializeField] private float highYOffset;

    private Vector3 temp;

    private Vector3 CamPos;

    private void Update()
    {
        if(playerMovement.getIsPlayerElevatet())
        {
            yOffset = highYOffset;
            followSpeed = followSpeedHigh;
        }
        else
        {
            yOffset = lowYOffset;
            followSpeed = followSpeedLow;
        }

        CamPos = new Vector3(this.transform.position.x,this.transform.position.y,transform.position.z);

        //if (playerMovement.getPlayerDirection() > 0 || playerMovement.getVelocity().x > 0)
        //{
        //    m_newPos = new Vector3(cameraTarget.position.x + xOffsetR, yOffset, -10f);
        //    transform.position = Vector3.Lerp(CamPos, m_newPos, playerMovement.getVelocity().x / lookAheadDragR * Time.deltaTime);
        //}

        //if (playerMovement.getPlayerDirection() < 0 || playerMovement.getVelocity().x < 0)
        //{
        //    m_newPos = new Vector3(cameraTarget.position.x - xOffsetL, yOffset, -10f);
        //    transform.position = Vector3.Lerp(CamPos, m_newPos, -playerMovement.getVelocity().x / lookAheadDragL * Time.deltaTime);
        //}

        //if (playerMovement.getPlayerDirection() == 0)
        //{
        //    m_newPos = new Vector3(cameraTarget.position.x, yOffset, -10f);
        //    transform.position = Vector3.Slerp(CamPos, m_newPos, followSpeed * Time.deltaTime);
        //}      

        if (playerMovement.getPlayerDirection() > 0 || playerMovement.getVelocity().x > 0)
        {
            m_newPos = new Vector3(cameraTarget.position.x + xOffsetR, yOffset, -10f);
            temp.x = Mathf.Lerp(CamPos.x, m_newPos.x, playerMovement.getVelocity().x / lookAheadDragR * Time.deltaTime);
            temp.y = Mathf.Lerp(CamPos.y, m_newPos.y, followSpeed * Time.deltaTime);
            temp.z = m_newPos.z;
            transform.position = temp;
        }

        if (playerMovement.getPlayerDirection() < 0 || playerMovement.getVelocity().x < 0)
        {
            m_newPos = new Vector3(cameraTarget.position.x - xOffsetL, yOffset, -10f);
            temp.x = Mathf.Lerp(CamPos.x, m_newPos.x, -playerMovement.getVelocity().x / lookAheadDragR * Time.deltaTime);
            temp.y = Mathf.Lerp(CamPos.y, m_newPos.y, followSpeed * Time.deltaTime);
            temp.z = m_newPos.z;
            transform.position = temp;
        }

        if (playerMovement.getPlayerDirection() == 0)
        {
            m_newPos = new Vector3(cameraTarget.position.x, yOffset, -10f);
            transform.position = Vector3.Slerp(CamPos, m_newPos, followSpeed * Time.deltaTime);
        }
    }
}
