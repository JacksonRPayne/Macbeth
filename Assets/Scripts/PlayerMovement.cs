using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    public float sensitivity = 2f;
    public Camera cam;

    public float maxCameraRotation = -90;
    public float minCameraRotation = 90;

    float xRot;
    float yRot;

    Rigidbody rb;

    public Animator knifeAnim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        xRot = Input.GetAxis("Mouse X") * sensitivity;
        yRot = Input.GetAxis("Mouse Y") * sensitivity * -1;

        transform.Rotate(0, xRot, 0);
        cam.transform.Rotate(yRot, 0, 0);

        Vector3 xMovement = Input.GetAxisRaw("Horizontal") * transform.right;
        Vector3 zMovement = Input.GetAxisRaw("Vertical") * transform.forward;
        Vector3 velocity = (xMovement + zMovement).normalized * speed;

        if (velocity != Vector3.zero)
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if(!DialogueManager.Instance.dialogueInProgress && Input.GetMouseButton(0))
        {
            knifeAnim.SetBool("IsSwinging", true);
        }
        else
        {
            knifeAnim.SetBool("IsSwinging", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Title");
        }

    }

}
