﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using AdisonOfferwallPlugin;

using AdisonOfferwall;
using AdisonOfferwall.Api;
using AdisonOfferwall.Common;

public class SampleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        Adison.Initialize("PJbqHq7dY9N5mJ1EyT9c6mQ3");
        Adison.SetEnvironment(Environment.Development);
        Adison.SetDebugEnabled(true);
        Adison.SetUid(null);
        Adison.SetIsTester(true);
        Adison.SetBirthYear(1983);
        Adison.SetGender(Gender.Male);

        AdisonConfig config = new AdisonConfig();
        config.OfferwallListTitle = "테스트 오퍼월";
        config.PrepareViewHidden = true;
        Adison.SetConfig(config);

        AdisonColorScheme colorScheme = new AdisonColorScheme();
        colorScheme.PrimaryColor = "#9f83cb";
        colorScheme.PrimaryColorVariant = "#9f83cb";
        colorScheme.OnPrimaryColor = "#ffffff";
        Adison.SetColorScheme(colorScheme);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        Adison.ShowOfferwall();
    }
}
