using Godot;
using System;

public class VPATemplate : VPA {
    //A Counter is a int that can be used for several purposes on each PR

    public override void process(string _delta) {
        //code
    }

    //Returns true if ready to free;
    public override void hit(Node2D _o) {
        //code
        base.hit(_o);
    }

    public override void init() {
        base.init();
        PAName = "VPATemplate";
    }

    public override VPA getNewInstance() {
        return new VPATemplate();
    }
}