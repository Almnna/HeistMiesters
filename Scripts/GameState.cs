using Godot;
using System;

public class GameState : Node
{   
    bool torch_active = false;
    TouchScreenButton torch = new TouchScreenButton();

    public override void _Ready(){
        AddToGroup("gamestate");
        //torch
        torch = GetNode<TouchScreenButton>("VBoxContainer/Torch");
    }

    void changeTorchSkin(bool is_torch_active){
        if(is_torch_active){
            torch.Normal = GD.Load<Texture>("res://GFX/PNG/torch/active.png");
        }else{
            torch.Normal = GD.Load<Texture>("res://GFX/PNG/torch/inactive.png");
        }
    }

    void _on_Torch_pressed(){
        Input.ActionPress("torch2");
    }
}