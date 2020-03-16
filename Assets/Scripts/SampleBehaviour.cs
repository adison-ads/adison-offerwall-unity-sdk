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
        Adison.initialize("UQfbKPb7hAjWirWZVnzVfGdE");
        //Adison.initialize("PJbqHq7dY9N5mJ1EyT9c6mQ3");
        Adison.setServer(Environment.Development);
        Adison.setDebugEnabled(true);
        Adison.setUid(null);
        Adison.setIsTester(true);
        Adison.setBirthYear(1983);
        Adison.setGender(Gender.Male);

        //OfferwallClient.OnLoginRequested =

        OfferwallConfig config = new OfferwallConfig();
        config.offerwallListTitle = "122323";
        config.prepareViewHidden = true;

        //AndroidJavaObject config = new AndroidJavaObject("co.adison.offerwall.AdisonConfig");
        //config.Set("offerwallListTitle", "123");
        //config.Set("prepareViewHidden", true);

        Adison.setConfig(config);
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
