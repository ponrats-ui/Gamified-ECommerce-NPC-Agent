using UnityEngine;

public class StorefrontUIManager : MonoBehaviour
{
    public static StorefrontUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public void OpenShoppingApp(string storeName, string regionName, string itemPriceText, CountryRegion region)
    {
        string npcSpeech = NPCDialogueController.GetLocalizedWelcomeMessage(region, storeName);

        Debug.Log($"[UI Engine] ---- 📱 หน้าจอแอป SHOPPING เปิดใช้งาน ----");
        Debug.Log($"[UI Engine] ร้านค้า: {storeName} | ภูมิภาค: {regionName}");
        Debug.Log($"[NPC AI Speech] {npcSpeech}");
        Debug.Log($"[UI Engine] สินค้าแนะนำ: Premium T-Shirt | ราคา: {itemPriceText}");
        Debug.Log($"[UI Engine] ----------------------------------------");

        // ---- จำลองข้อมูลหลังบ้านเพื่อส่งให้ AI Manager สรุปรายงานแดชบอร์ด ----
        // สมมติสถานะ: ร้านนี้ขายของไปได้แล้ว ,250 และสินค้าชิ้นแรกในคลังเหลืออยู่ 3 ชิ้น (เข้าข่ายสต็อกวิกฤต)
        float simulatedTotalSales = 1250f;
        int simulatedStock = 3; 

        // สั่งให้ AI Agent สรุปรายงานแดชบอร์ดส่งให้เจ้าของร้านทันที!
        string storeReport = StoreAIAgentManager.GenerateStoreReport(storeName, region, simulatedTotalSales, simulatedStock);
        Debug.Log(storeReport);
    }
}
