using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseKnife : MonoBehaviour
{ /// <summary>
//this script can be used to impleament the knife choose functionality its impleamentation is
//can be completed in wheelrotaion script for  instantiating our desired knife
/// </summary>
    public static ChooseKnife instance;
    public bool firstKnife;
    public bool secondKnife;
    public bool thirdKnife;

    void Awake()
    {
        instance = this;
    }

    public void EnableFirstKnife()
    {
        firstKnife = true;
        secondKnife = false;
        thirdKnife = false;
    }
    public void EnableSecondKnife()
    {
        firstKnife = false;
        secondKnife = true;
        thirdKnife = false;
    }
    public void EnableThirdKnife()
    {
        firstKnife = false;
        secondKnife = false;
        thirdKnife = true;
    }

}
