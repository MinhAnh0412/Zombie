using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookByMouse : MonoBehaviour
{
    public Transform cameraHolder;
    public float sensitivity;
    public float minPitch;
    public float maxPitch;

    private bool allowRotate;

    private IEnumerator Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(1f);
        allowRotate = true;
    }

    void Update()
    {
        if (!allowRotate) return;

        var xInput = Input.GetAxis("Mouse X");
        var yInput = Input.GetAxis("Mouse Y");

        var deltaYaw = xInput * sensitivity * Time.deltaTime;
        var deltaPitch = -yInput * sensitivity * Time.deltaTime;

        transform.Rotate(0, deltaYaw, 0);
        RotateCameraWithClamp(deltaPitch);
    }

    private void RotateCameraWithClamp(float deltaPitch)
    {
        cameraHolder.Rotate(deltaPitch, 0, 0);
        var pitch = cameraHolder.localEulerAngles.x;
        if (pitch > 180) pitch -= 360;
        if (pitch < -180) pitch += 360;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
    }
}
