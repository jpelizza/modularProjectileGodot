using Godot;
using System;

public class PAmultiHit : VPA {
    private Godot.Collections.Array<ulong> nodeCollisionTimeout = new Godot.Collections.Array<ulong>();
    private Godot.Collections.Array<Timer> timerCollisionTimeout = new Godot.Collections.Array<Timer>();
    private int numHits = 2;


    public override void init() {
        base.init();
        numHits = 2;
        PAName = "PAmultiHit";
    }

    public override VPA getNewInstance() {
        return new PAmultiHit();
    }

    public override void process(string _delta) {
        base.process(_delta);
        foreach (Area2D a in p.hitBox.GetOverlappingAreas()) {
            // GD.Print("Processing multihit, current list:", nodeCollisionTimeout);
            if (!nodeCollisionTimeout.Contains(a.GetInstanceId())) {
                // GD.Print("Processing multihit: On area NOT ON LIST");
                p.hitBox.EmitSignal("area_entered", a);
            }
        }
    }

    //Returns true if ready to free;
    public override void hit(Node2D _o) {
        if (!nodeCollisionTimeout.Contains(_o.GetInstanceId()) && numHits > 1) {
            setCollisionTimeout(_o);
            numHits -= 1;
            return;
        } else if (nodeCollisionTimeout.Contains(_o.GetInstanceId())) {
            return;
        }
        base.hit(_o);
    }

    public void setCollisionTimeout(Node2D _o) {
        Timer t = new Timer();
        p.AddChild(t, false);
        t.OneShot = true;
        t.WaitTime = 1;
        t.Start();
        timerCollisionTimeout.Add(t);
        nodeCollisionTimeout.Add(_o.GetInstanceId());
        t.Connect("timeout", this, "resetCollisionTimeout", new Godot.Collections.Array { nodeCollisionTimeout[timerCollisionTimeout.Count - 1] }, 0);
    }

    public void resetCollisionTimeout(String collisionID) {
        for (int i = 0; i < nodeCollisionTimeout.Count; i++) {
            if (nodeCollisionTimeout[i].ToString() == collisionID) {
                timerCollisionTimeout.RemoveAt(i);
                nodeCollisionTimeout.RemoveAt(i);
            }
        }
    }


}