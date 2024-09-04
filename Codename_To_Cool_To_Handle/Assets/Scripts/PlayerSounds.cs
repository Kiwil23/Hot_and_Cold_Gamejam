using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource stepsSource;
    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource DMGSource;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float snowStepsPitchControll = 1f;
    [SerializeField] private AudioClip snowSteps;
    [SerializeField] private AudioClip stoneSteps;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private List<AudioClip> dmg_Sounds;
    private string currentGround = " ";

    private void Update()
    {
        if (playerMovement.getIsPlayerMoving() && playerMovement.getIsPlayerGrounded())
        {
            if (stepsSource.volume <= 0.8f)
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
            PlayNewSteps();


        }
        else if (groundChecker.getCollisionTag() == "snow" && getIsGroundChange())
        {

            currentGround = groundChecker.getCollisionTag();
            stepsSource.clip = snowSteps;
            PlayNewSteps();
        }
    }

    private void PlayNewSteps()
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

    public void PlayJump()
    {
        jumpSource.Play();
    }

    public void PlayDMGSound()
    {
        int randNumTemp = UnityEngine.Random.Range(0, 2);
        DMGSource.clip = dmg_Sounds[randNumTemp];
        DMGSource.Play();
    }
}
