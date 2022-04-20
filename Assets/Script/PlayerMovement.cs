using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 8f;
    public Transform rayPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;
        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            HitObstacle();
        }
    }

    private void HitObstacle()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(rayPoint.position, rayPoint.forward, out hitInfo, 100f))
        {
            GameObject hitObstacle = hitInfo.collider.gameObject;
            if (hitObstacle.tag == "Obstacle")
            {
                Destroy(hitObstacle);
            }
        }
    }
}
