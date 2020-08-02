using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 29.2f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 29.2f;


    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -1.05f;
    [SerializeField] float positionYawFactor = 0.9f;
    [SerializeField] float positionRollFactor = -9.7f;

    [Header("Control-throw Based")]
    [SerializeField] float pitchMoveFactor = -20f;
    [SerializeField] float rollMoveFactor = -50.3f;

    float xThrow, yThrow;
    bool isControlEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    
   
    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();

        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    private void ProcessTranslation()
    {
       xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
       yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        //float xoffset = Time.deltaTime * horizontalThrow;
        //print(xoffset);

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x + xOffset, -24f, 24f),
            Mathf.Clamp(transform.localPosition.y + yOffset, -15f, 20f),
            transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * pitchMoveFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = transform.localPosition.z * positionRollFactor + xThrow * rollMoveFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
