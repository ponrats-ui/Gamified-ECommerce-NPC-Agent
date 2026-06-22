using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    public string storeName;
    public string regionName;
    public CountryRegion region;
    public float baseItemPrice;
    public StoreVisualTheme storeTheme;

    private ShopVendorManager vendorManager;

    public void SetupZone(string name, string regName, CountryRegion reg, float price, StoreVisualTheme theme)
    {
        storeName = name;
        regionName = regName;
        region = reg;
        baseItemPrice = price;
        storeTheme = theme;
    }

    void Start()
    {
        vendorManager = GetComponent<ShopVendorManager>();
    }

    // แก้ไขจุดตรวจจับคลิกเมาส์ให้วิ่งทะลวงเข้า Namespace 'Core' อย่างถูกระเบียบสากล
    void Update()
    {
        if (Core.SceneStateManager.Instance != null && Core.SceneStateManager.Instance.currentState != Core.MallState.Overworld) return;

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
        if (vendorManager != null && vendorManager.inventory.Count > 0)
        {
            var item = vendorManager.inventory[0];
            string localPriceText = CurrencyConverter.GetConvertedPrice(item.price, region);
            
            if (StorefrontUIManager.Instance != null)
            {
                StorefrontUIManager.Instance.OpenShoppingApp(storeName, region.ToString(), localPriceText, region, item.price);
            }
            
            if (Core.SceneStateManager.Instance != null)
            {
                Core.SceneStateManager.Instance.SwitchState(Core.MallState.InsideShop);
            }

            vendorManager.AddToCart(0);
        }
    }
}
