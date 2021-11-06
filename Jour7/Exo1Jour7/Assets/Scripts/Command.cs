using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute(Transform transform, float velocity, float deltaTime);
}

public class PerformMove : Command
{
    public override void Execute(Transform transform, float velocity, float deltaTime)
    {
        transform.Translate(0,0, velocity * deltaTime);
    }
}

public class PerformRotate : Command
{
    public override void Execute(Transform transform, float velocity, float deltaTime)
    {
        transform.Rotate(Vector3.up, velocity * deltaTime);
    }
}