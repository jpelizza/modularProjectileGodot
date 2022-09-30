using Godot;
using System;

public class ShotControl : Control {
    Wand wand = null;

    Button fm = null;
    bool fmEnabled = false;

    Button mh = null;
    bool mhEnabled = false;

    RichTextLabel damageText = null;
    Button damageButtonPlus = null;
    Button damageButtonMinus = null;
    RichTextLabel damageMulText = null;
    Button damageMulButtonPlus = null;
    Button damageMulButtonMinus = null;

    RichTextLabel speedText = null;
    Button speedButtonPlus = null;
    Button speedButtonMinus = null;
    RichTextLabel speedMulText = null;
    Button speedMulButtonPlus = null;
    Button speedMulButtonMinus = null;

    RichTextLabel sizeText = null;
    Button sizeButtonPlus = null;
    Button sizeButtonMinus = null;
    RichTextLabel sizeMulText = null;
    Button sizeMulButtonPlus = null;
    Button sizeMulButtonMinus = null;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        //-----------------Container    //ControlNode //ROOT
        this.wand = GetParent().GetNode<Wand>("Wand");

        this.fm = GetNode<Button>("VBoxContainerParam/mf");
        this.mh = GetNode<Button>("VBoxContainerParam/mh");
        // TEXT
        this.damageText = GetNode<RichTextLabel>("VBoxContainerStats/DMG/Text");
        this.speedText = GetNode<RichTextLabel>("VBoxContainerStats/SPEED/Text");
        this.sizeText = GetNode<RichTextLabel>("VBoxContainerStats/SIZE/Text");
        this.damageMulText = GetNode<RichTextLabel>("VBoxContainerStats/DMGMUL/Text");
        this.speedMulText = GetNode<RichTextLabel>("VBoxContainerStats/SPEEDMUL/Text");
        this.sizeMulText = GetNode<RichTextLabel>("VBoxContainerStats/SIZEMUL/Text");
        // BASE
        this.damageButtonPlus = GetNode<Button>("VBoxContainerStats/DMG/+");
        this.speedButtonPlus = GetNode<Button>("VBoxContainerStats/SPEED/+");
        this.sizeButtonPlus = GetNode<Button>("VBoxContainerStats/SIZE/+");

        this.damageButtonMinus = GetNode<Button>("VBoxContainerStats/DMG/-");
        this.speedButtonMinus = GetNode<Button>("VBoxContainerStats/SPEED/-");
        this.sizeButtonMinus = GetNode<Button>("VBoxContainerStats/SIZE/-");
        // MULTIPLES
        this.damageMulButtonPlus = GetNode<Button>("VBoxContainerStats/DMGMUL/+");
        this.speedMulButtonPlus = GetNode<Button>("VBoxContainerStats/SPEEDMUL/+");
        this.sizeMulButtonPlus = GetNode<Button>("VBoxContainerStats/SIZEMUL/+");

        this.damageMulButtonMinus = GetNode<Button>("VBoxContainerStats/DMGMUL/-");
        this.speedMulButtonMinus = GetNode<Button>("VBoxContainerStats/SPEEDMUL/-");
        this.sizeMulButtonMinus = GetNode<Button>("VBoxContainerStats/SIZEMUL/-");




        fm.Connect("pressed", this, "fmOnClick", null, 0);
        mh.Connect("pressed", this, "mhOnClick", null, 0);

        damageButtonPlus.Connect("pressed", this, "damagePlus", null, 0);
        damageButtonMinus.Connect("pressed", this, "damageMinus", null, 0);
        damageMulButtonPlus.Connect("pressed", this, "damageMulPlus", null, 0);
        damageMulButtonMinus.Connect("pressed", this, "damageMulMinus", null, 0);

        speedButtonPlus.Connect("pressed", this, "speedPlus", null, 0);
        speedButtonMinus.Connect("pressed", this, "speedMinus", null, 0);
        speedMulButtonPlus.Connect("pressed", this, "speedMulPlus", null, 0);
        speedMulButtonMinus.Connect("pressed", this, "speedMulMinus", null, 0);

        sizeButtonPlus.Connect("pressed", this, "sizePlus", null, 0);
        sizeButtonMinus.Connect("pressed", this, "sizeMinus", null, 0);
        sizeMulButtonPlus.Connect("pressed", this, "sizeMulPlus", null, 0);
        sizeMulButtonMinus.Connect("pressed", this, "sizeMulMinus", null, 0);


        damageText.Text = "Damage: " + wand.getDamage().ToString();
        damageMulText.Text = "DamageMul: " + wand.getDamageMul().ToString();
        speedMulText.Text = "SpeedMul: " + wand.getSpeedMul().ToString();
        sizeMulText.Text = "SizeMul: " + wand.getSizeMul().ToString();
        speedText.Text = "Speed: " + wand.getSpeed().ToString();
        sizeText.Text = "Size: " + wand.getSize().ToString();

    }


    public void fmOnClick() {
        if (fmEnabled) {
            wand.removeAtrib("PAforwardMovement");
            fm.Text = "PAforwardMovement: false";
            fmEnabled = !fmEnabled;
        } else {
            wand.addAtrib(new PAforwardMovement());
            fm.Text = "PAforwardMovement: true";
            fmEnabled = !fmEnabled;
        }
    }

    public void mhOnClick() {
        if (mhEnabled) {
            wand.removeAtrib("PAmultiHit");
            mh.Text = "PAmultiHit: false";
            mhEnabled = !mhEnabled;
        } else {
            wand.addAtrib(new PAmultiHit());
            mh.Text = "PAmultiHit: true";
            mhEnabled = !mhEnabled;
        }
    }

    public void damagePlus() {
        wand.setDamage(wand.getDamage() + 1);
        damageText.Text = "Damage: " + wand.getDamage().ToString();
    }
    public void damageMinus() {
        wand.setDamage(wand.getDamage() - 1);
        damageText.Text = "Damage: " + wand.getDamage().ToString();
    }
    public void damageMulPlus() {
        wand.setDamageMul(wand.getDamageMul() + 1);
        damageMulText.Text = "DamageMul: " + wand.getDamageMul().ToString();
    }
    public void damageMulMinus() {
        wand.setDamageMul(wand.getDamageMul() - 1);
        damageMulText.Text = "DamageMul: " + wand.getDamageMul().ToString();
    }
    public void speedPlus() {
        wand.setSpeed(wand.getSpeed() + 1);
        speedText.Text = "Speed: " + wand.getSpeed().ToString();
    }
    public void speedMinus() {
        wand.setSpeed(wand.getSpeed() - 1);
        speedText.Text = "Speed: " + wand.getSpeed().ToString();
    }
    public void speedMulPlus() {
        wand.setSpeedMul(wand.getSpeedMul() + 1);
        speedMulText.Text = "SpeedMul: " + wand.getSpeedMul().ToString();
    }
    public void speedMulMinus() {
        wand.setSpeedMul(wand.getSpeedMul() - 1);
        speedMulText.Text = "SpeedMul: " + wand.getSpeedMul().ToString();
    }
    public void sizePlus() {
        wand.setSize(wand.getSize() + 1);
        sizeText.Text = "Size: " + wand.getSize().ToString();
    }
    public void sizeMinus() {
        wand.setSize(wand.getSize() - 1);
        sizeText.Text = "Size: " + wand.getSize().ToString();
    }
    public void sizeMulPlus() {
        wand.setSizeMul(wand.getSizeMul() + 1);
        sizeMulText.Text = "SizeMul: " + wand.getSizeMul().ToString();
    }
    public void sizeMulMinus() {
        wand.setSizeMul(wand.getSizeMul() - 1);
        sizeMulText.Text = "SizeMul: " + wand.getSizeMul().ToString();

    }
}
