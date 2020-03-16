using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using AdisonOfferwallPlugin;

using AdisonOfferwall;
using AdisonOfferwall.Api;

public class SampleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        Adison.initialize("PJbqHq7dY9N5mJ1EyT9c6mQ3");
        Adison.setServer(Environment.Development);
        Adison.setDebugEnabled(true);
        Adison.setUid(null);
        Adison.setIsTester(true);
        Adison.setBirthYear(1983);
        Adison.setGender(Gender.Male);

        OfferwallConfig config = new OfferwallConfig();
        config.offerwallListTitle = "테스트 오퍼월";
        config.prepareViewHidden = true;
        Adison.setConfig(config);

        AdisonOfwColorScheme colorScheme = new AdisonOfwColorScheme();
        colorScheme.primaryColor = "#9f83cb";
        colorScheme.primaryColorVariant = "#9f83cb";
        colorScheme.onPrimaryColor = "#ffffff";
        Adison.setColorScheme(colorScheme);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        Adison.showOfferwall();
    }
}
