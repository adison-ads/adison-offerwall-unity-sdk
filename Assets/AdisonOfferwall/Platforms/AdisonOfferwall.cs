using System;
using UnityEngine;

using AdisonOfferwall;
using AdisonOfferwall.Api;

namespace AdisonOfferwall
{
#if UNITY_ANDROID
	public class Adison : AdisonOfferwall.Android.OfferwallClient
#elif UNITY_IOS
	public class Adison : AdisonOfferwall.iOS.OfferwallClient
#endif
	{
	}
}
