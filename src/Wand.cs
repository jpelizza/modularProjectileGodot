using Godot;

public class Wand : Node2D {

    private Timer shootTimer = null;
    private Node shotList = null;
    private Projectile projRoot = null;

    public override void _Ready() {
        shootTimer = (Timer)GetNode("ShootTimer");
        shotList = (Node)GetNode("ShotList");
        projRoot = (Projectile)GetNode("projRoot");

        projRoot.hitBoxCollision.Disabled = true;
        projRoot.SetProcess(false);
        projRoot.timerFree.Stop();

        shootTimer.Connect("timeout", this, "shoot", null, 0);
    }

    public void addAtrib(VPA _vpr) {
        projRoot.addAtribList(_vpr);
    }
    public void removeAtrib(string _vpr_name) {
        projRoot.removeAtribList(_vpr_name);
    }

    public override void _Process(float delta) {
        //base._Process(delta);
    }

    //has connection reference
    public void shoot() {
        Projectile p = (Projectile)((PackedScene)GD.Load("res://scenes/Projectile.tscn")).Instance();
        shotList.AddChild(p, false);
        p.init(projRoot, Position, Rotation);
    }


    // ### GET && SET
    public void setDamage(int _d) { projRoot.setDamage(_d); }
    public int getDamage() { return projRoot.getDamage(); }
    public void setDamageMul(float _dm) { projRoot.setDamageMul(_dm); }
    public float getDamageMul() { return projRoot.getDamageMul(); }
    public void setSpeed(int _s) { projRoot.setSpeed(_s); }
    public int getSpeed() { return projRoot.getSpeed(); }
    public void setSpeedMul(float _sm) { projRoot.setSpeedMul(_sm); }
    public float getSpeedMul() { return projRoot.getSpeedMul(); }
    public void setSize(int _s) { projRoot.setSize(_s); }
    public int getSize() { return projRoot.getSize(); }
    public void setSizeMul(float _sm) { projRoot.setSizeMul(_sm); }
    public float getSizeMul() { return projRoot.getSizeMul(); }


}
