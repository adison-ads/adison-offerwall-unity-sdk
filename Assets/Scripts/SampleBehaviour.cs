using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdisonOfferwallPlugin;

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
        Adison.setUid("sangkyoonnam");
        Adison.setIsTester(true);
        Adison.setBirthYear(1983);
        Adison.setGender(Gender.MALE);
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
