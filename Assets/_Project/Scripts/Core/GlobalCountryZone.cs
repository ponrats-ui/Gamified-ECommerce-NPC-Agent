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
                
                // สั่งการยิงข้อมูลผ่านวงจรระบบ เข้าสู่หน้าต่าง UI ทันที!
                if (StorefrontUIManager.Instance != null)
                {
                    StorefrontUIManager.Instance.OpenShoppingApp(currentTenant, region.ToString(), localPriceText);
                }
                else
                {
                    Debug.LogWarning("[Core] ไม่พบ StorefrontUIManager ในฉาก! กำลังพิมพ์ข้อความสำรองผ่าน Console...");
                    Debug.Log($"[Storefront] ร้าน: {currentTenant} | ราคา: {localPriceText}");
                }

                vendorManager.AddToCart(0);
            }
        }
    }
}
