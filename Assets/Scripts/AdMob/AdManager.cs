using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    [System.Obsolete]
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
        /*   this.RequestInterstitial();*/
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            string adUnitId = "";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }


    /*    private void RequestInterstitial()
        {
    #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/1033173712";
    #elif UNITY_IPHONE
                string adUnitId = "";
    #else
                string adUnitId = "unexpected_platform";
    #endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }*/

    /*  public void Show_InterstitialAd()
      {
          if (this.interstitial.IsLoaded())
          {
              this.interstitial.Show();
          }
          else
          {
              print("Ad is not show!");
          }
      }*/

}
