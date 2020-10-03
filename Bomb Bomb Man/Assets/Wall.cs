using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IExplodable
{
    public void Damage()
    {
        Destroy(this);
    }
}
public interface IExplodable
{
    void Damage();
}
