using Godot;
using System;

public class VPA : Node {
    //A Counter is a int that can be used for several purposes on each PR
    protected Boolean readyToFree = false;

    protected string PAName = "VPA";
    //Parent projectile
    public Projectile p = null;

    [Signal] public delegate void signalReadyToFree();


    virtual public void process(string _delta) {
    }

    //Returns true if ready to free;
    virtual public void hit(Node2D _o) {
        if (!readyToFree) {
            readyToFree = true;
            EmitSignal("signalReadyToFree");
        }
    }

    virtual public void init() {
        p = GetParent<Projectile>();
        PAName = "VPA";
    }

    virtual public VPA getNewInstance() {
        return new VPA();
    }


    virtual public bool getReadyToFree() {
        return readyToFree;
    }

    virtual public string getPAName() {
        return PAName;
    }

}