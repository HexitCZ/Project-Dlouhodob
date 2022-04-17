using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable
{
    //Gets called when hit by a player
    void GetHit();
}
