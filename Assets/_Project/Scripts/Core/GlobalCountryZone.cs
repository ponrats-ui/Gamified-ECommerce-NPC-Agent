using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    public string storeName;
    public string regionName;
    public CountryRegion region;
    public float baseItemPrice;
    public StoreVisualTheme storeTheme;

    // 🏗️ ฟังก์ชันสะพานเชื่อมข้อมูล (ล็อกให้อยู่ถาวร ห้ามหายเด็ดขาด!)
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
        // 🤵 ตรวจจับพิเศษ: หากคลิกตึกสำนักงานใหญ่สีทอง
        CSOAgentController csoAgent = GetComponent<CSOAgentController>();
        if (csoAgent != null)
        {
            csoAgent.InteractWithFounder(UserType.CasualShopper);
            
            // 🚀 สั่งการให้ลูกน้อง AI ออกมารายงานทำหน้าที่ทันที
            if (MerchantStaffManager.Instance != null)
            {
                MerchantStaffManager.Instance.DelegateTasksToStaff();
            }
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
