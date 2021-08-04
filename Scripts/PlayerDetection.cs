using Godot;
using System;

public class PlayerDetection : KinematicBody2D
{ 
    const float FOV_TOLERANCE = 18.0f;
    private Player player;
    private Light2D torch;
    private Color default_camera_beam_color;

    public override void _Ready()
    {
        torch = GetNode<Light2D>("Torch");
        default_camera_beam_color = torch.Color;
    }
    public override void _Process(float delta)
    {
        if (Player_Is_In_FOV_TOLERANCE()){
            torch.Color = Color.ColorN("red", 0.6f);
        }else{
            torch.Color = default_camera_beam_color;
        }
    }


    public bool Player_Is_In_FOV_TOLERANCE(){
        var current_color = torch.Color;
        player = GetNode<Player>("/root/Level1/Player");
        var NPC_facing_direction = new Vector2(1, 0).Rotated(GlobalRotation);
        var direction_to_player = (player.Position - GlobalPosition).Normalized();

        if (Mathf.Abs(direction_to_player.AngleTo(NPC_facing_direction)) < Mathf.Deg2Rad(FOV_TOLERANCE)){
            return true;
        }
        return false;
    }
}
