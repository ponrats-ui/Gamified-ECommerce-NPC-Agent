using UnityEngine;

public class MallSpawner : MonoBehaviour
{
    private string[] storeNames = { "Siam Paragon Pop-Up", "Beijing Silk Market", "Shibuya Trends", "Gangnam Beauty Lab", "Dubai Luxury Mall" };
    private CountryRegion[] regions = { CountryRegion.Thailand, CountryRegion.China, CountryRegion.Japan, CountryRegion.Korea, CountryRegion.MiddleEast };
    private float[] basePrices = { 800f, 150f, 3500f, 32000f, 500f };

    void Start()
    {
        SpawnMegaMallHQ();
        SpawnInternationalPlots();
    }

    private void SpawnMegaMallHQ()
    {
        GameObject hqPlot = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hqPlot.name = "MEGA_MALL_HEADQUARTERS";
        hqPlot.transform.position = new Vector3(0f, 2f, 0f); 
        hqPlot.transform.localScale = new Vector3(2f, 2.5f, 2f); 

        var zoneData = hqPlot.AddComponent<GlobalCountryZone>();
        zoneData.SetupZone("Mega Mall HQ", "Global Center", CountryRegion.Thailand, 0f, StoreVisualTheme.LuxuryGold);
        
        StoreThemeManager.ApplyThemeToStore(hqPlot, StoreVisualTheme.LuxuryGold);

        // 🤵 บรรจุอวตารคุณพี (CSO) เข้าไปสถิต
        hqPlot.AddComponent<CSOAgentController>();

        Debug.Log("[HQ System] 🏛️ สำนักงานใหญ่ส่วนกลางและอวตารคุณพี (CSO) ถูกสร้างเสร็จสมบูรณ์!");
    }

    private void SpawnInternationalPlots()
    {
        float startX = -6f;
        float spacing = 3.0f;

        for (int i = 0; i < storeNames.Length; i++)
        {
            GameObject plot = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plot.name = $"Automated_Plot_{regions[i]}";
            plot.transform.position = new Vector3(startX + (i * spacing), 0f, 0f);
            plot.transform.rotation = Quaternion.Euler(0f, 25f, 0f);

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
