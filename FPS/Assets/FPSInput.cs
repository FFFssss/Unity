using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//键盘wAsd实现人物前后左右移动

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController _charController;
    public float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;//AD
        float deltaZ = Input.GetAxis("Vertical") * speed;//WS
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);//使对角移动速度和轴移动速度相同
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

    }
}
