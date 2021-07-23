using Godot;
using System;

public class Player : Character
{
    private Vector2 motion = new Vector2(0, 0);
    private InputEventScreenTouch t = new InputEventScreenTouch();

    public override void _Process(float delta)
    {
        UpdateMotion(delta);
        MoveAndSlide(motion);
    }

    public void UpdateMotion(float delta)
    {
        LookAt(GetGlobalMousePosition());

        if (Input.IsActionPressed("ui_left") &&  !Input.IsActionPressed("ui_right")) {
            motion.x = Mathf.Clamp((motion.x - SPEED), -MAX_SPEED, 0);
        }else if (Input.IsActionPressed("ui_right") && !Input.IsActionPressed("ui_left")) {
            motion.x = Mathf.Clamp((motion.x + SPEED), 0, MAX_SPEED);
        }
        else
        {
            motion.x = Mathf.Lerp(motion.x, 0, FRICTION);
        }

        if (Input.IsActionPressed("ui_up") && !Input.IsActionPressed("ui_down"))
        {
            motion.y = Mathf.Clamp((motion.y - SPEED), -MAX_SPEED, 0);
        }else if (Input.IsActionPressed("ui_down") && !Input.IsActionPressed("ui_up")) 
        {
            motion.y = Mathf.Clamp((motion.y + SPEED), 0, MAX_SPEED);
        }else{
            motion.y = Mathf.Lerp(motion.y, 0, FRICTION);
        }
        //Move();
    }

    public void Move()
    {
    }

}
