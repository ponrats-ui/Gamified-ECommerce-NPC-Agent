using UnityEngine;

public class MallSpawner : MonoBehaviour
{
    void Start()
    {
        // รายชื่อโซนประเทศที่เราจะส่ง AI ไปเปิดตลาดรวดเดียวจบ
        CountryRegion[] regionsToSpawn = { 
            CountryRegion.Thailand, 
            CountryRegion.China, 
            CountryRegion.Japan, 
            CountryRegion.Korea, 
            CountryRegion.MiddleEast 
        };

        string[] shopNames = { 
            "Siam Paragon Pop-up", 
            "Beijing Silk Market", 
            "Akihabara Anime Hub", 
            "Gangnam Beauty Lab", 
            "Dubai Luxury Boutique" 
        };

        // ลูปอัจฉริยะ: สั่งสร้างตึกและผูกสคริปต์อัตโนมัติ โดยเว้นระยะห่างตึกละ 2 เมตร
        for (int i = 0; i < regionsToSpawn.Length; i++)
        {
            // 1. เสกกล่อง Cube เปล่า ๆ ขึ้นมากลางอากาศ
            GameObject newPlot = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newPlot.name = "Automated_Plot_" + regionsToSpawn[i];
            
            // 2. จัดวางตำแหน่งแบบเรียงหน้ากระดาน (X ขยับไปเรื่อย ๆ)
            newPlot.transform.position = new Vector3((i - 2) * 2.5f, 0.5f, 0f);

            // 3. ยัดไส้ระบบ E-Commerce (ShopVendorManager) เข้าไปในตึกทันที
            ShopVendorManager vendor = newPlot.AddComponent<ShopVendorManager>();
            vendor.vendorName = shopNames[i];

            // 4. ยัดไส้ระบบทวีป (GlobalCountryZone) เข้าไปควบคุมต่อ
            GlobalCountryZone zone = newPlot.AddComponent<GlobalCountryZone>();
            zone.region = regionsToSpawn[i];
            zone.currentTenant = shopNames[i];
            zone.isRented = true; // เปิดระบบพร้อมช้อปปิ้งทันทีทุกตึก!
        }

        Debug.Log($"[AI Master Spawner] ประสบความสำเร็จ! เสกตึกร้านค้าข้ามชาติ 5 ประเทศเข้าสู่ระบบเรียบร้อย!");
    }
}
