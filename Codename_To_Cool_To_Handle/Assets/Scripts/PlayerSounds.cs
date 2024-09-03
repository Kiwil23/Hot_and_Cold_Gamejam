using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource stepsSource;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float snowStepsPitchControll = 1f;
    [SerializeField] private AudioClip snowSteps;
    [SerializeField] private AudioClip stoneSteps;
    [SerializeField] private GroundChecker groundChecker;
    private string currentGround = " ";

    private void Update()
    {
        if (playerMovement.getIsPlayerMoving() && playerMovement.getIsPlayerGrounded())
        {
            if(stepsSource.volume <= 0.6f)
            stepsSource.volume += 0.1f * (Time.deltaTime * 40f);
        }
        else
        {
            stepsSource.volume -= 0.1f * (Time.deltaTime * 40f);
        }

        //For hiher the pitch if velocity picks Up
        //stepsSound.pitch = Mathf.Abs(playerMovement.getVelocity()) * snowStepsPitchControll;

        if (groundChecker.getCollisionTag() == "stone" && getIsGroundChange())
        {
            currentGround = groundChecker.getCollisionTag();
            stepsSource.clip = stoneSteps;
            playNewSteps();
          
     
        }
        else if(groundChecker.getCollisionTag() == "snow" && getIsGroundChange())
        {

            currentGround = groundChecker.getCollisionTag();
            stepsSource.clip = snowSteps;
            playNewSteps();
        }
    }

  private void playNewSteps()
    {     
            stepsSource.Play();       
    }

    private bool getIsGroundChange()
    {
        if (currentGround != groundChecker.getCollisionTag())
        {
            return true;
        }
        else { return false; }
    }

    public void playJump()
    {
        jumpSource.Play();
    }
}
