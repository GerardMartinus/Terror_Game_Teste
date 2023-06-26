using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MoverChar : MonoBehaviour
{
    // Move and Jump
    public float speed = 6f;
    public CharacterController controller;
    [SerializeField] float turnSmoothVelocity;
    [SerializeField] float TurnSmoothTime;
    [SerializeField] Transform cam;


    public CinemachineVirtualCamera virtualCamera;
    public float amplitudeGain;
    public CinemachineBasicMultiChannelPerlin handheldNormalStrong;
    public CinemachineBasicMultiChannelPerlin handheldNormalMild;
    bool move;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15f;
        }
        else
        {
            speed = 6f;
            amplitudeGain = 1;
        }

        if (amplitudeGain <= 3 && speed > 10)
        {
            for (int i = 0; i <= 2; i++)
            {
                amplitudeGain += 0.5f;
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeGain;
            }
        }
        else if(speed < 10)
        {
            for (int i = 0; i <= 2; i++)
            {
                amplitudeGain -= 0.5f;
                virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeGain;
            }
        }

    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);

        }
    }

}