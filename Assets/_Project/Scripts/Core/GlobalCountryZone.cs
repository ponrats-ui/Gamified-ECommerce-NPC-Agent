using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    public string storeName;
    public string regionName;
    public CountryRegion region;
    public float baseItemPrice;
    public StoreVisualTheme storeTheme;

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
        // 🤵 ดักจับพิเศษ: ถ้าเป็นตึกสำนักงานใหญ่ ให้คุณพี (CSO) ออกมาพูดคุยให้คำปรึกษาทันที!
        CSOAgentController csoAgent = GetComponent<CSOAgentController>();
        if (csoAgent != null)
        {
            // จำลองการดักจับสเตตัส (เช่น เป็นนักช้อปทั่วไปเข้ามาขอข้อมูลคำสั่งไอเท็ม)
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
