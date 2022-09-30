using Godot;

public class PAforwardMovement : VPA {
    public override void process(string _delta) {
        base.process(_delta);
        p.Position += new Vector2(
        p.getSpeed() * p.getSpeedMul(), 0
        );
    }

    public override void hit(Node2D _o) {
        base.hit(_o);
    }
    public override void init() {
        base.init();
        PAName = "PAforwardMovement";
    }

    public override VPA getNewInstance() {
        return new PAforwardMovement();
    }
}