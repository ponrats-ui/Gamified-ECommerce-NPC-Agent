using UnityEngine;

public class MallSpawner : MonoBehaviour
{
    private string[] storeNames = { "Siam Paragon Pop-Up", "Beijing Silk Market", "Shibuya Trends", "Gangnam Beauty Lab", "Dubai Luxury Mall" };
    private CountryRegion[] regions = { CountryRegion.Thailand, CountryRegion.China, CountryRegion.Japan, CountryRegion.Korea, CountryRegion.MiddleEast };
    private float[] basePrices = { 800f, 150f, 3500f, 32000f, 500f };

    void Start()
    {
        // ผูกระบบกล้องหลักให้ขยับและซูมได้ทันที
        Camera.main.gameObject.AddComponent<RTSCameraController>();
        // ตั้งตำแหน่งกล้องเริ่มต้นให้อยู่มุมสูงเห็นเมืองชัดเจน สไตล์ Township
        Camera.main.transform.position = new Vector3(0f, 15f, -12f);
        Camera.main.transform.rotation = Quaternion.Euler(45f, 0f, 0f);

        if (FindObjectOfType<MerchantStaffManager>() == null)
        {
            GameObject staffManagerObj = new GameObject("_MerchantStaffManager");
            staffManagerObj.AddComponent<MerchantStaffManager>();
        }

        SpawnEnvironment(); // 🌳 เสกสภาพแวดล้อมรอบๆ เมือง
        SpawnMegaMallHQ();
        SpawnInternationalPlots();
    }

    // เนรมิตระบบโครงสร้างเมืองเบื้องต้น (ถนน + ต้นไม้)
    private void SpawnEnvironment()
    {
        // 🛣️ เสกถนนเส้นหลักตัดผ่านหน้าตึกนานาชาติ
        GameObject road = GameObject.CreatePrimitive(PrimitiveType.Cube);
        road.name = "CITY_MAIN_ROAD";
        road.transform.position = new Vector3(0f, -0.45f, -1.5f);
        road.transform.localScale = new Vector3(25f, 0.1f, 2f);
        road.GetComponent<Renderer>().material.color = new Color(0.2f, 0.2f, 0.2f); // สีเทาดำยางมะตอย

        // 🌳 เสกกลุ่มต้นไม้รอบๆ สำนักงานใหญ่
        for (int i = -3; i <= 3; i += 2)
        {
            if (i == 0) continue; // เว้นตรงกลางไว้ให้ตึก HQ
            GameObject tree = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tree.name = $"City_Decorative_Tree_{i}";
            tree.transform.position = new Vector3(i * 2.5f, 0.5f, 3f);
            tree.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
            tree.GetComponent<Renderer>().material.color = new Color(0.1f, 0.6f, 0.2f); // สีเขียวธรรมชาติ
        }
    }

    private void SpawnMegaMallHQ()
    {
        GameObject hqPlot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hqPlot.name = "MEGA_MALL_HEADQUARTERS";
        hqPlot.transform.position = new Vector3(0f, 1.25f, 0f); 
        hqPlot.transform.localScale = new Vector3(2f, 2.5f, 2f); 

        var zoneData = hqPlot.AddComponent<GlobalCountryZone>();
        zoneData.SetupZone("Mega Mall HQ", "Global Center", CountryRegion.Thailand, 0f, StoreVisualTheme.LuxuryGold);
        
        StoreThemeManager.ApplyThemeToStore(hqPlot, StoreVisualTheme.LuxuryGold);
        hqPlot.AddComponent<CSOAgentController>();

        Debug.Log("[HQ System] 🏛️ สำนักงานใหญ่ส่วนกลางสร้างพร้อมสภาพแวดล้อมสำเร็จ!");
    }

    private void SpawnInternationalPlots()
    {
        float startX = -6f;
        float spacing = 3.0f;

        for (int i = 0; i < storeNames.Length; i++)
        {
            GameObject plot = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plot.name = $"Automated_Plot_{regions[i]}";
            plot.transform.position = new Vector3(startX + (i * spacing), 0.5f, -4f); // ย้ายมาตั้งริมถนน
            plot.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            var zoneData = plot.AddComponent<GlobalCountryZone>();
            StoreVisualTheme assignedTheme = (StoreVisualTheme)(i % 4);
            
            zoneData.SetupZone(storeNames[i], GetRegionName(regions[i]), regions[i], basePrices[i], assignedTheme);
            StoreThemeManager.ApplyThemeToStore(plot, assignedTheme);
        }
    }

    private string GetRegionName(CountryRegion region)
    {
        switch (region)
        {
            case CountryRegion.Thailand: return "Thailand (TH)";
            case CountryRegion.China: return "China (CN)";
            case CountryRegion.Japan: return "Japan (JP)";
            case CountryRegion.Korea: return "Korea (KR)";
            case CountryRegion.MiddleEast: return "Middle East (UAE)";
            default: return "Global Zone";
        }
    }
}
