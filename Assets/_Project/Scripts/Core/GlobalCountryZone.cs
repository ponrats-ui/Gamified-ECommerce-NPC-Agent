using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    public string storeName;
    public string regionName;
    public CountryRegion region;
    public float baseItemPrice;
    public StoreVisualTheme storeTheme;

    // 🏗️ ฟังก์ชันสะพานเชื่อมข้อมูลที่ Spawner เรียกใช้
    public void SetupZone(string name, string regName, CountryRegion reg, float price, StoreVisualTheme theme)
    {
        storeName = name;
        regionName = regName;
        region = reg;
        baseItemPrice = price;
        storeTheme = theme;
    }

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
        // 🤵 ดักจับพิเศษ: ถ้ามีคอมโพเนนต์ คุณพี (CSO) ติดอยู่ ให้ทำงานทักทายทันที
        CSOAgentController csoAgent = GetComponent<CSOAgentController>();
        if (csoAgent != null)
        {
            csoAgent.InteractWithFounder(UserType.CasualShopper);
        }

        string localPriceText = CurrencyConverter.GetConvertedPrice(baseItemPrice, region);
        
        if (StorefrontUIManager.Instance != null)
        {
            StorefrontUIManager.Instance.OpenShoppingApp(storeName, regionName, localPriceText, region, baseItemPrice);
        }
        
        if (Core.SceneStateManager.Instance != null)
        {
            Core.SceneStateManager.Instance.SwitchState(Core.MallState.InsideShop);
        }
    }
}
