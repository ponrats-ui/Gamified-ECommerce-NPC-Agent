using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    [Header("Platform Space Setup")]
    public CountryRegion region = CountryRegion.Thailand; 
    public string plotID;
    public string currentTenant = "Siam Paragon Simulated Shop"; 
    public bool isRented = true; 
    public float monthlyRentPrice = 49.00f; 

    private ShopVendorManager vendorManager;

    void Start()
    {
        if (string.IsNullOrEmpty(plotID))
        {
            plotID = "PLOT-" + System.Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
        vendorManager = GetComponent<ShopVendorManager>();
    }

    void Update()
    {
        if (SceneStateManager.Instance != null && SceneStateManager.Instance.currentState != MallState.Overworld) return;

        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform)
                {
                    TriggerClickAction();
                }
            }
        }
    }

    private void TriggerClickAction()
    {
        if (isRented)
        {
            if (vendorManager != null && vendorManager.inventory.Count > 0)
            {
                var item = vendorManager.inventory[0];
                string localPriceText = CurrencyConverter.GetConvertedPrice(item.price, region);
                
                // ส่งตัวแปรราคาสินค้าฐานพ่วงท้ายเข้าไปในท่อ UI
                if (StorefrontUIManager.Instance != null)
                {
                    StorefrontUIManager.Instance.OpenShoppingApp(currentTenant, region.ToString(), localPriceText, region, item.price);
                }
                
                if (SceneStateManager.Instance != null)
                {
                    SceneStateManager.Instance.SwitchState(MallState.InsideShop);
                }

                vendorManager.AddToCart(0);
            }
        }
    }
}
