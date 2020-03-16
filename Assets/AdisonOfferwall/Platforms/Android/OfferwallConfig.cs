using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferwallConfig
{
    public AndroidJavaObject javaObject;

    public OfferwallConfig()
    {
        javaObject = new AndroidJavaObject("co.adison.offerwall.AdisonConfig");
    }

    public string offerwallListTitle
    {
        set
        {
            javaObject.Set("offerwallListTitle", value);

        }
    }

    public bool prepareViewHidden
    {
        set
        {
            javaObject.Set("prepareViewHidden", value);

        }
    }
}
