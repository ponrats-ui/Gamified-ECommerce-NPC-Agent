using UnityEngine;

public enum CountryRegion
{
    Global, Thailand, China, Japan, Korea, Vietnam, MiddleEast
}

public class GlobalCountryZone : MonoBehaviour
{
    [Header("Platform Space Setup")]
    public CountryRegion region = CountryRegion.Global;
    public string plotID;
    public string currentTenant = "Premium Sneaker Shop"; 
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
        
        Debug.Log("[Virtual Mall] Plot ID: " + plotID + " (" + region + ") is active.");
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
        if (!isRented)
        {
            Debug.Log("[Business UI] Space Available! Region: " + region + " | Price: $" + monthlyRentPrice);
        }
        else
        {
            Debug.Log("[Storefront] ยินดีต้อนรับสู่ร้าน: " + currentTenant + " (โซน " + region + ")");
            
            if (vendorManager != null)
            {
                vendorManager.AddToCart(0);
            }
        }
    }
}
