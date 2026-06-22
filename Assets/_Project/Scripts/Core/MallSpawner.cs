using UnityEngine;
using System.Collections.Generic;

public class MallSpawner : MonoBehaviour
{
    private string[] storeNames = { "Siam Paragon Pop-Up", "Beijing Silk Market", "Shibuya Trends", "Gangnam Beauty Lab", "Dubai Luxury Mall" };
    private CountryRegion[] regions = { CountryRegion.Thailand, CountryRegion.China, CountryRegion.Japan, CountryRegion.Korea, CountryRegion.MiddleEast };
    private float[] basePrices = { 800f, 150f, 3500f, 32000f, 500f };

    void Start()
    {
        SpawnInternationalPlots();
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
            
            // สุ่มธีมตกแต่งให้ตึกสัญชาติต่างๆ ตามโมเดลธุรกิจ
            StoreVisualTheme assignedTheme = (StoreVisualTheme)(i % 4);
            
            zoneData.SetupZone(storeNames[i], GetRegionName(regions[i]), regions[i], basePrices[i], assignedTheme);
            
            // สั่งตัวจัดการสกินให้ทาสีเปลี่ยนโฉมตึกทันที
            StoreThemeManager.ApplyThemeToStore(plot, assignedTheme);
        }

        Debug.Log("[AI Master Spawner] ประสบความสำเร็จ! เสกตึกร้านค้าข้ามชาติ 5 ประเทศพร้อมธีมระเบียบเรียบร้อย!");
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
