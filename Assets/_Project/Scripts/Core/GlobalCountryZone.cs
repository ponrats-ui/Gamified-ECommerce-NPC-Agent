using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    public string storeName;
    public string regionName;
    public CountryRegion region;
    public float baseItemPrice;
    public StoreVisualTheme storeTheme;

    // 🏗️ ฟังก์ชันสะพานเชื่อมหลักที่ระบบ Spawner เรียกใช้ (ใส่กลับมาให้ครบถ้วนแล้ว!)
    public void SetupZone(string name, string regName, CountryRegion reg, float price, StoreVisualTheme theme)
    {
        storeName = name;
        regionName = regName;
        region = reg;
        baseItemPrice = price;
        storeTheme = theme;
    }

    // ระบบตรวจจับคลิกเมาส์และยิงข้อมูลข้ามมิติเข้าหน้าจอ 3D และท่อส่งเงินโลกจริง
    void Update()
    {
        // ตรวจสอบว่าระบบต้องอยู่ในสเตทเมือง (Overworld) เท่านั้นถึงจะคลิกตึกได้ ป้องกันการคลิกซ้อน
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
        // แปลงค่าราคาฐาน (baseItemPrice) เป็นเงินตราท้องถิ่นข้ามสัญชาติ
        string localPriceText = CurrencyConverter.GetConvertedPrice(baseItemPrice, region);
        
        // 1. สั่งยิงข้อมูลทะลวงตรงเข้าหน้าจอแอป 3D พร้อมประมวลผลคูปองและสรุปบัญชี
        if (StorefrontUIManager.Instance != null)
        {
            StorefrontUIManager.Instance.OpenShoppingApp(storeName, region.ToString(), localPriceText, region, baseItemPrice);
        }
        
        // 2. สั่งกล้องดีดวาร์ปข้ามมิติลงห้องใต้ดินภายในร้านค้าย่อยทันที
        if (Core.SceneStateManager.Instance != null)
        {
            Core.SceneStateManager.Instance.SwitchState(Core.MallState.InsideShop);
        }
    }
}
