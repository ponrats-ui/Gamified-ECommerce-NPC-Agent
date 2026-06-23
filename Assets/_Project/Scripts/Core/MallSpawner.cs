using UnityEngine;

public class MallSpawner : MonoBehaviour
{
    // ตัวแปรสาธารณะสำหรับลากโมเดล 3D ตัวจริง (ตึก/ต้นไม้/พนักงาน) มาใส่ในหน้าจอ Inspector ของ Unity 6
    [Header("🎨 3D Real Assets Setup")]
    public GameObject hqRealPrefab;       // โมเดลตึกสำนักงานใหญ่สุดหรู
    public GameObject storeRealPrefab;    // โมเดลร้านค้านานาชาติสไตล์ Township
    public GameObject treeRealPrefab;     // โมเดลต้นไม้สวยๆ
    public GameObject npcRealPrefab;      // โมเดลพนักงานต้อนรับ (น้องส้ม 3D)

    private string[] storeNames = { "Siam Paragon Pop-Up", "Beijing Silk Market", "Shibuya Trends", "Gangnam Beauty Lab", "Dubai Luxury Mall" };
    private CountryRegion[] regions = { CountryRegion.Thailand, CountryRegion.China, CountryRegion.Japan, CountryRegion.Korea, CountryRegion.MiddleEast };
    private float[] basePrices = { 800f, 150f, 3500f, 32000f, 500f };

    void Start()
    {
        Camera.main.gameObject.AddComponent<RTSCameraController>();
        Camera.main.transform.position = new Vector3(0f, 15f, -12f);
        Camera.main.transform.rotation = Quaternion.Euler(45f, 0f, 0f);

        if (FindObjectOfType<MerchantStaffManager>() == null)
        {
            GameObject staffManagerObj = new GameObject("_MerchantStaffManager");
            staffManagerObj.AddComponent<MerchantStaffManager>();
        }

        SpawnEnvironment();
        SpawnMegaMallHQ();
        SpawnInternationalPlots();
    }

    private void SpawnEnvironment()
    {
        // ถนนเส้นหลักสีเทา
        GameObject road = GameObject.CreatePrimitive(PrimitiveType.Cube);
        road.name = "CITY_MAIN_ROAD";
        road.transform.position = new Vector3(0f, -0.45f, -1.5f);
        road.transform.localScale = new Vector3(25f, 0.1f, 2f);
        road.GetComponent<Renderer>().material.color = new Color(0.2f, 0.2f, 0.2f);

        // เสกต้นไม้ (ถ้ายอมลาก Prefab จริงมาใส่ จะใช้โมเดลจริงทันที ถ้าไม่มีจะใช้ทรงกระบอกแทนไปก่อน)
        for (int i = -3; i <= 3; i += 2)
        {
            if (i == 0) continue;
            GameObject treeObj;
            if (treeRealPrefab != null) {
                treeObj = Instantiate(treeRealPrefab, new Vector3(i * 2.5f, 0f, 3f), Quaternion.identity);
            } else {
                treeObj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                treeObj.transform.position = new Vector3(i * 2.5f, 0.5f, 3f);
                treeObj.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
                treeObj.GetComponent<Renderer>().material.color = new Color(0.1f, 0.6f, 0.2f);
            }
            treeObj.name = $"City_Decorative_Tree_{i}";
        }
    }

    private void SpawnMegaMallHQ()
    {
        GameObject hqPlot;
        // 🏛️ กลไกอัจฉริยะ: ถ้าคุณคอมใส่โมเดลตึกจริงมา ระบบจะเอามาตั้งแทนกล่องสี่เหลี่ยมทันที!
        if (hqRealPrefab != null) {
            hqPlot = Instantiate(hqRealPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        } else {
            hqPlot = GameObject.CreatePrimitive(PrimitiveType.Cube);
            hqPlot.transform.position = new Vector3(0f, 1.25f, 0f); 
            hqPlot.transform.localScale = new Vector3(2f, 2.5f, 2f); 
            StoreThemeManager.ApplyThemeToStore(hqPlot, StoreVisualTheme.LuxuryGold);
        }
        
        hqPlot.name = "MEGA_MALL_HEADQUARTERS";
        var zoneData = hqPlot.AddComponent<GlobalCountryZone>();
        zoneData.SetupZone("Mega Mall HQ", "Global Center", CountryRegion.Thailand, 0f, StoreVisualTheme.LuxuryGold);
        hqPlot.AddComponent<CSOAgentController>();

        // 👤 เสกร่างพนักงานต้อนรับ 3D ยืนเฝ้าหน้าร้านค้า
        if (npcRealPrefab != null) {
            GameObject npcSom = Instantiate(npcRealPrefab, hqPlot.transform.position + new Vector3(1.5f, 0f, -1.5f), Quaternion.Euler(0f, 180f, 0f));
            npcSom.name = "NPC_Nong_Som_3D";
        }
    }

    private void SpawnInternationalPlots()
    {
        float startX = -6f;
        float spacing = 3.0f;

        for (int i = 0; i < storeNames.Length; i++)
        {
            GameObject plot;
            if (storeRealPrefab != null) {
                plot = Instantiate(storeRealPrefab, new Vector3(startX + (i * spacing), 0f, -4f), Quaternion.identity);
            } else {
                plot = GameObject.CreatePrimitive(PrimitiveType.Cube);
                plot.transform.position = new Vector3(startX + (i * spacing), 0.5f, -4f);
                StoreThemeManager.ApplyThemeToStore(plot, (StoreVisualTheme)(i % 4));
            }
            
            plot.name = $"Automated_Plot_{regions[i]}";
            var zoneData = plot.AddComponent<GlobalCountryZone>();
            zoneData.SetupZone(storeNames[i], "Region Zone", regions[i], basePrices[i], (StoreVisualTheme)(i % 4));
        }
    }
}
