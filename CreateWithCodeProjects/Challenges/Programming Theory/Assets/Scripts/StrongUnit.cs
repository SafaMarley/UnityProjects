using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance
public class StrongUnit : EnemyUnits
{
    //Polymorphism
    public override void tellWhoYouAre()
    {
        Debug.Log("I am strong.");
    }
}
