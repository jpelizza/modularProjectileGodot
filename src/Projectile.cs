using Godot;
using System;

public class Projectile : Node2D {
    //damage
    protected int DAMAGE = 1;
    protected float DAMAGE_MUL = 1.0f;
    //speed
    protected int SPEED = 7;
    protected float SPEED_MUL = 1.0f;

    protected int SIZE = 1;
    protected float SIZE_MUL = 1f;


    public Sprite sprite;
    public Area2D hitBox;
    public CollisionShape2D hitBoxCollision;
    public Timer timerFree;

    public Godot.Collections.Array<VPA> atribList = new Godot.Collections.Array<VPA>();




    [Signal] public delegate void signalInit();
    [Signal] public delegate void signalProc(float _delta);
    [Signal] public delegate void signalHit(Node2D _area);

    public override void _Ready() {
        sprite = GetNode<Sprite>("Sprite");
        hitBox = GetNode<Area2D>("Area2D");
        hitBoxCollision = hitBox.GetNode<CollisionShape2D>("CollisionShape2D");

        timerFree = GetNode<Timer>("TimerFree");

        timerFree.Connect("timeout", this, "freeTimerProcess", null, 0);
        hitBox.Connect("area_entered", this, "hit", null, 0);
    }

    public void init(Projectile p, Vector2 _pos, float _rot) {
        foreach (VPA r in p.atribList) {
            VPA auxPar = r.getNewInstance();
            AddChild(auxPar);
            atribList.Add(auxPar);
            Connect("signalInit", auxPar, "init", null, 0);
            Connect("signalProc", auxPar, "process", null, 0);
            Connect("signalHit", auxPar, "hit", null, 0);
            auxPar.Connect("signalReadyToFree", this, "freeHit", null, 0);
        }
        EmitSignal("signalInit");

        Position = _pos;
        Rotation = _rot;

        setDamage(p.DAMAGE);
        setSpeed(p.SPEED);
        setSize(p.SIZE);

        setDamageMul(p.DAMAGE_MUL);
        setSpeedMul(p.SPEED_MUL);
        setSizeMul(p.SIZE_MUL);

        Scale = new Vector2(SIZE * SIZE_MUL, SIZE * SIZE_MUL);
    }

    public override void _Process(float delta) {
        base._Process(delta);
        EmitSignal("signalProc", delta);
    }
    //Has connection reference
    public void hit(Node2D _o) {
        EmitSignal("signalHit", _o);
        DamageDisplay dd = (DamageDisplay)((PackedScene)GD.Load("res://scenes/DamageDisplay.tscn")).Instance();
        GetParent().AddChild(dd, false);
        dd.display(DAMAGE * DAMAGE_MUL, ((Node2D)_o.GetParent()).Position);
    }

    public void freeHit() {
        foreach (VPA r in atribList) {
            bool b = r.getReadyToFree();
            if (!b) {
                return;
            }
        }
        QueueFree();
    }

    public void freeTimerProcess() {
        QueueFree();
    }






    // ### ADD && REMOVE
    public void addAtribList(VPA _vpr) {
        atribList.Add(_vpr);
        AddChild(_vpr);
        atribList[atribList.Count - 1].init();
    }
    public void removeAtribList(String _vpr_name) {
        for (int i = 0; i < atribList.Count; i++) {
            if (_vpr_name == atribList[i].getPAName()) {
                VPA aux = atribList[i];
                atribList.Remove(atribList[i]);
                aux.QueueFree();
                return;
            }
        }
    }

    // ### GET && SET
    public int getDamage() { return this.DAMAGE; }
    public void setDamage(int _d) { this.DAMAGE = _d; }
    public float getDamageMul() { return this.DAMAGE_MUL; }
    public void setDamageMul(float _dm) { this.DAMAGE_MUL = _dm; }
    public int getSpeed() { return this.SPEED; }
    public void setSpeed(int _s) { this.SPEED = _s; }
    public float getSpeedMul() { return this.SPEED_MUL; }
    public void setSpeedMul(float _sm) { this.SPEED_MUL = _sm; }
    public int getSize() { return this.SIZE; }
    public void setSize(int _s) { this.SIZE = _s; }
    public float getSizeMul() { return this.SIZE_MUL; }
    public void setSizeMul(float _sm) { this.SIZE_MUL = _sm; }

}

