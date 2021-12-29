using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public Vector3 shoulderPoint;
    public float armLength;

    public User(Vector3 shoulderPoint, float armLength) {
        this.shoulderPoint = shoulderPoint;
        this.armLength = armLength;
    }

    public float getArmLength() {
        return this.armLength;
    }

    public Vector3 getShoulderPoint() {
        return shoulderPoint;
    }

    public string toString()
    {
        string str = "[User: ArmLength = " + armLength + " Shoulder Point = " + shoulderPoint + "]";
        return str;
    }
}
