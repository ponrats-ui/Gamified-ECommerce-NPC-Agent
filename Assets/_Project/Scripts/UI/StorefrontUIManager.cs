using UnityEngine;

public class StorefrontUIManager : MonoBehaviour
{
    public static StorefrontUIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public void OpenShoppingApp(string storeName, string regionName, string itemPriceText, CountryRegion region, float baseItemPrice)
    {
        string npcSpeech = NPCDialogueController.GetLocalizedWelcomeMessage(region, storeName);

        Debug.Log($"[UI Engine] ---- 📱 หน้าจอแอป SHOPPING เปิดใช้งาน ----");
        Debug.Log($"[UI Engine] ร้านค้า: {storeName} | ภูมิภาค: {regionName}");
        Debug.Log($"[NPC AI Speech] {npcSpeech}");
        
        // ---- 🎯 กลไกเสกความสนุก ล่าคูปอง Gamified Vouchers ----
        var assignedVoucher = VoucherRewardSystem.GenerateRandomVoucher(region);
        float discountedBasePrice = VoucherRewardSystem.CalculateDiscountedPrice(baseItemPrice, assignedVoucher.discountPercentage);
        string localDiscountedPriceText = CurrencyConverter.GetConvertedPrice(discountedBasePrice, region);

        Debug.Log($"[UI Engine] ราคาฐานตั้งต้น: {itemPriceText}");
        Debug.Log($"[🛒 PROMO CHECKOUT] โค้ดที่ใช้: {assignedVoucher.code} | ราคาพิเศษหลังหักส่วนลด: {localDiscountedPriceText} 🔥");
        Debug.Log($"[UI Engine] ----------------------------------------");

        // ---- จำลองระบบแดชบอร์ดส่งรายงานให้เจ้าของร้าน ----
        float simulatedTotalSales = 1250f;
        int simulatedStock = 3; 
        string storeReport = StoreAIAgentManager.GenerateStoreReport(storeName, region, simulatedTotalSales, simulatedStock);
        Debug.Log(storeReport);
    }
}
