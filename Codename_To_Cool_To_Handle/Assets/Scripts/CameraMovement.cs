using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private float followSpeed = 2f;
    [SerializeField] private float yOffset = 0;
    [SerializeField] private float runningOffset = 1f;
    [SerializeField] private float runningOffsetSpeed = 3f;
    private Vector3 m_newPos;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField] private float lookAheadDragR = 13f;
    [SerializeField] private float lookAheadDragL = 13f;
    [SerializeField] private float xOffsetR = 15;
    [SerializeField] private float xOffsetL = 15;

    private Vector3 CamPos;

    private void Update()
    {
        CamPos = new Vector3(this.transform.position.x,this.transform.position.y,transform.position.z);

            if (playerMovement.getPlayerDirection() > 0 || playerMovement.getVelocity() > 0)
            {
                m_newPos = new Vector3(cameraTarget.position.x + xOffsetR, yOffset, -10f);
                transform.position = Vector3.Lerp(CamPos, m_newPos, playerMovement.getVelocity() / lookAheadDragR * Time.deltaTime);
            }

            if (playerMovement.getPlayerDirection() < 0 || playerMovement.getVelocity() < 0)
            {
                m_newPos = new Vector3(cameraTarget.position.x - xOffsetL, yOffset, -10f);
                transform.position = Vector3.Lerp(CamPos, m_newPos, -playerMovement.getVelocity() / lookAheadDragL * Time.deltaTime);
            }

            if (playerMovement.getPlayerDirection() == 0)
            {
                m_newPos = new Vector3(cameraTarget.position.x, yOffset, -10f);
                transform.position = Vector3.Slerp(CamPos, m_newPos, followSpeed * Time.deltaTime);
            }      
    }
}
