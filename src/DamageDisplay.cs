using Godot;
using System;

public class DamageDisplay : Node2D {
    private Timer timerFree;
    private RichTextLabel text;

    public override void _Ready() {
        timerFree = GetNode<Timer>("TimerFree");
        timerFree.Connect("timeout", this, "timeoutFree", null, 0);
        text = GetNode<RichTextLabel>("Text");
    }

    public void display(float Damage, Vector2 _pos) {
        Position = _pos;
        text.Text = Damage.ToString();
        text.Visible = true;
        timerFree.WaitTime = 0.7f;
        timerFree.Start();
    }

    public void timeoutFree() {
        QueueFree();
    }

    public override void _Process(float delta) {
        base._Process(delta);
        Position += new Vector2(0, -0.5f);
    }

}
