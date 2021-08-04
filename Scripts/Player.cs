using Godot;
using System;

public class Player : Character
{
    private Vector2 motion = new Vector2(0, 0);
    private InputEventScreenTouch t = new InputEventScreenTouch();//not done yet
    private Light2D torch = new Light2D();
    private bool is_torch_active;

    public override void _Ready()
    {
        AddToGroup("player");
    }
    public void Torch(){
        if(Input.IsActionPressed("torch")){
            torch = GetNode<Light2D>("Torch");
            if(torch.Enabled){
                torch.Enabled = false;
                is_torch_active = false;
                GetTree().CallGroup("gamestate", "changeTorchSkin", is_torch_active);
            }else{
                torch.Enabled = true;
                is_torch_active = true;
                GetTree().CallGroup("gamestate", "changeTorchSkin", is_torch_active);
            }
        }
    }

    public void Torch2(){
        if(Input.IsActionPressed("torch2"))
        {
            Input.ActionRelease("torch2");
            torch = GetNode<Light2D>("Torch");
            if(torch.Enabled){
                torch.Enabled = false;
                is_torch_active = false;
                GetTree().CallGroup("gamestate", "changeTorchSkin", is_torch_active);
            }else{
                torch.Enabled = true;
                is_torch_active = true;
                GetTree().CallGroup("gamestate", "changeTorchSkin", is_torch_active);
            }
        }
    }
    public override void _Process(float delta)
    {
        UpdateMotion(delta);
        MoveAndSlide(motion);
        Torch2();
    }

    public override void _Input(InputEvent @event)
    {
        Torch(); 
    }


    public void UpdateMotion(float delta)
    {
        LookAt(GetGlobalMousePosition());
        Move();
    }
    public void Move()
    {
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

    }

}
