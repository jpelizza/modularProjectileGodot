using Godot;

public class PAgasBomb : VPA {
    public override void process(string _delta) {
        base.process(_delta);
    }

    public override void hit(Node2D _o) {
        //code
        base.hit(_o);
    }

    public override void init() {
        base.init();
        PAName = "PAgasBomb";
    }

    public override VPA getNewInstance() {
        return new PAgasBomb();
    }


}