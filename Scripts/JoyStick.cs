using Godot;
using System;

public class JoyStick : Control
{   
    private InputEventScreenTouch t = new InputEventScreenTouch();
    private TouchScreenButton Btn = new TouchScreenButton();
     JoyStick()
    {
        //279
    }


    public override void _Input(InputEvent @event)
    {
        GD.Print("true");
        Console.WriteLine("true");
        if (@event is InputEventScreenTouch touch){
            //GD.Print(touch.Index);
            //Console.WriteLine("true");
            // Btn = GetNode<TouchScreenButton>("Button");
            // var MaxXPosition = 558/2;
            // var MaxYPosition = 560/2;
            // var newXPosition = touch.Position.x;
            // var newYPosition = touch.Position.y;
            // var X = 0.0;
            // var Y = 0.0;
 
            // if (newXPosition <= MaxXPosition){
            //     X = newXPosition;
            // }

            // if (newYPosition <= MaxYPosition){
            //     Y = newYPosition;
            // }
            // var joyBtn = new Vector2((float) X, (float)Y);
            // //Btn.Position
            // Btn.Position = joyBtn;
            // GD.Print(touch.Position);
        }
        
        //Btn.LookAt(@event)
    }
}
