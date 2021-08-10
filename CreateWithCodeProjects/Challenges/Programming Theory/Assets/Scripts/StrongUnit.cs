using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Demonstration of Inheritance
public class StrongUnit : EnemyUnits
{
    //Demonstration of Polymorphism
    public override void tellWhoYouAre()
    {
        Debug.Log("I am strong.");
    }
}
