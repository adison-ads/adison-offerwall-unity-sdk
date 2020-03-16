using System;

using AdisonOfferwall;
using AdisonOfferwall.Common;

namespace AdisonOfferwall.Api
{
    //public class RewardBasedVideoAd
    //{
    //    private IRewardBasedVideoAdClient client;
    //    private static readonly RewardBasedVideoAd instance = new RewardBasedVideoAd();

    //    public static RewardBasedVideoAd Instance
    //    {
    //        get
    //        {
    //            return instance;
    //        }
    //    }

    //    // Creates a Singleton RewardBasedVideoAd.
    //    private RewardBasedVideoAd()
    //    {
    //        this.client = GoogleMobileAdsClientFactory.BuildRewardBasedVideoAdClient();
    //        client.CreateRewardBasedVideoAd();

    //        this.client.OnAdLoaded += (sender, args) =>
    //        {
    //            if (this.OnAdLoaded != null)
    //            {
    //                this.OnAdLoaded(this, args);
    //            }
    //        };

    //        this.client.OnAdFailedToLoad += (sender, args) =>
    //        {
    //            if (this.OnAdFailedToLoad != null)
    //            {
    //                this.OnAdFailedToLoad(this, args);
    //            }
    //        };

    //        this.client.OnAdOpening += (sender, args) =>
    //        {
    //            if (this.OnAdOpening != null)
    //            {
    //                this.OnAdOpening(this, args);
    //            }
    //        };

    //        this.client.OnAdStarted += (sender, args) =>
    //        {
    //            if (this.OnAdStarted != null)
    //            {
    //                this.OnAdStarted(this, args);
    //            }
    //        };

    //        this.client.OnAdClosed += (sender, args) =>
    //        {
    //            if (this.OnAdClosed != null)
    //            {
    //                this.OnAdClosed(this, args);
    //            }
    //        };

    //        this.client.OnAdLeavingApplication += (sender, args) =>
    //        {
    //            if (this.OnAdLeavingApplication != null)
    //            {
    //                this.OnAdLeavingApplication(this, args);
    //            }
    //        };

    //        this.client.OnAdRewarded += (sender, args) =>
    //        {
    //            if (this.OnAdRewarded != null)
    //            {
    //                this.OnAdRewarded(this, args);
    //            }
    //        };

    //        this.client.OnAdCompleted += (sender, args) =>
    //        {
    //            if (this.OnAdCompleted != null)
    //            {
    //                this.OnAdCompleted(this, args);
    //            }
    //        };
    //    }

    //    // These are the ad callback events that can be hooked into.
    //    public event EventHandler<EventArgs> OnAdLoaded;

    //    public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

    //    public event EventHandler<EventArgs> OnAdOpening;

    //    public event EventHandler<EventArgs> OnAdStarted;

    //    public event EventHandler<EventArgs> OnAdClosed;

    //    public event EventHandler<Reward> OnAdRewarded;

    //    public event EventHandler<EventArgs> OnAdLeavingApplication;

    //    public event EventHandler<EventArgs> OnAdCompleted;

    //    // Loads a new reward based video ad request
    //    public void LoadAd(AdRequest request, string adUnitId)
    //    {
    //        client.LoadAd(request, adUnitId);
    //    }

    //    // Determines whether the reward based video has loaded.
    //    public bool IsLoaded()
    //    {
    //        return client.IsLoaded();
    //    }

    //    // Shows the reward based video.
    //    public void Show()
    //    {
    //        client.ShowRewardBasedVideoAd();
    //    }

    //    // Sets the user id of current user.
    //    public void SetUserId(string userId)
    //    {
    //        client.SetUserId(userId);
    //    }

    //    // Returns the mediation adapter class name.
    //    public string MediationAdapterClassName()
    //    {
    //        return this.client.MediationAdapterClassName();
    //    }
    //}
}
