using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveByKey : MonoBehaviour
{
    public CharacterController controller;
    public float speed;

    private void Update()
    {
        var right = Input.GetAxis("Horizontal");
        var forward = Input.GetAxis("Vertical");
        var moveDirection = new Vector3(right, 0, forward);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.SimpleMove(moveDirection.normalized * speed);
    }

    private void OnValidate() => controller = GetComponent<CharacterController>();
}
