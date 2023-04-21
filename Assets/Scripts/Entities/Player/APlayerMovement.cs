using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class APlayerMovement : MonoBehaviour
{
    public UnityAction OnMoving;
    public FixedJoystick fixedJoystick;
    public Animator animator;
    private Vector2 joyStickDir;
    private Vector3 moveDirection;
    private bool isRunning;
    public const string JOYSTICK_PATH = "Prefabs/Joystick/";

    private void Awake()
    {
        fixedJoystick = Resources.Load<FixedJoystick>(JOYSTICK_PATH + "Fixed Joystick");
        animator = GetComponent<Animator>();
    }

    public void CreateJoystick(RectTransform joystickZone)
    {
        fixedJoystick = Instantiate(fixedJoystick, joystickZone);
    }

    void Update()
    {
        joyStickDir = fixedJoystick.Direction;
        isRunning = MoveToDir(joyStickDir);
    }

        private bool MoveToDir(Vector2 dir)
    {
        if (dir.sqrMagnitude < 0.1f) return false;

        transform.Translate(dir * 6 * Time.deltaTime, Space.World);
        OnMoving?.Invoke();
        return true;
    }
}
