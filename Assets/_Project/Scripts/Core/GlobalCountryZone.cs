using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    public string storeName;
    public string regionName;
    public CountryRegion region;
    public float baseItemPrice;
    public StoreVisualTheme storeTheme; // เพิ่มตัวแปรเก็บข้อมูลสกินของแบรนด์

    private bool isPlayerInside = false;

    public void SetupZone(string name, string regName, CountryRegion reg, float price, StoreVisualTheme theme)
    {
        storeName = name;
        regionName = regName;
        region = reg;
        baseItemPrice = price;
        storeTheme = theme;
    }

    private void OnMouseDown()
    {
        TriggerClickAction();
    }

    public void TriggerClickAction()
    {
        if (SceneStateManager.Instance.CurrentState == MallState.Overworld)
        {
            SceneStateManager.Instance.SwitchState(MallState.InsideShop);
            
            string formattedPrice = CurrencyConverter.GetConvertedPrice(baseItemPrice, region);
            
            // ส่งค่าธีมของร้านเข้าไปที่ UI ระบบ App ด้วย
            StorefrontUIManager.Instance.OpenShoppingApp(storeName, regionName, formattedPrice, region, baseItemPrice);
        }
    }

    void Update()
    {
        if (SceneStateManager.Instance.CurrentState == MallState.InsideShop && Input.GetMouseButtonDown(1))
        {
            ReturnToOverworld();
        }
        if (SceneStateManager.Instance.CurrentState == MallState.InsideShop && Input.GetKeyDown(KeyCode.Backspace))
        {
            ReturnToOverworld();
        }
    }

    private void ReturnToOverworld()
    {
        SceneStateManager.Instance.SwitchState(MallState.Overworld);
        StorefrontUIManager.Instance.HideCanvasApp();
    }
}
