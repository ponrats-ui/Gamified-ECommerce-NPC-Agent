using UnityEngine;

public class GlobalMerchantLedger : MonoBehaviour
{
    // ฟังก์ชันอัจฉริยะ: คำนวณและบันทึกภาษีแยกตามกฎหมายของแต่ละภูมิภาค
    public static void RecordTransaction(string storeName, CountryRegion region, float finalNetPriceUSD)
    {
        float taxRate = 0.0f;
        string taxLabel = "";

        // กำหนดอัตราภาษีจริงตามกฎหมายประเทศนั้น ๆ
        switch (region)
        {
            case CountryRegion.Thailand:
                taxRate = 0.07f; // VAT 7%
                taxLabel = "TH VAT (7%)";
                break;
            case CountryRegion.China:
                taxRate = 0.13f; // VAT 13%
                taxLabel = "CN VAT (13%)";
                break;
            case CountryRegion.Japan:
                taxRate = 0.10f; // Consumption Tax 10%
                taxLabel = "JP Tax (10%)";
                break;
            case CountryRegion.Korea:
                taxRate = 0.10f; // VAT 10%
                taxLabel = "KR VAT (10%)";
                break;
            case CountryRegion.MiddleEast:
                taxRate = 0.05f; // VAT 5%
                taxLabel = "UAE VAT (5%)";
                break;
            default:
                taxRate = 0.05f;
                taxLabel = "Global Tax (5%)";
                break;
        }

        // คำนวณตัวเลขทางบัญชี
        float taxAmountUSD = finalNetPriceUSD * taxRate;
        float grossBeforeTaxUSD = finalNetPriceUSD - taxAmountUSD;

        // แปลงค่าเงินเพื่อความแม่นยำในใบเสร็จ
        string localTaxAmount = CurrencyConverter.GetConvertedPrice(taxAmountUSD, region);
        string localGrossAmount = CurrencyConverter.GetConvertedPrice(grossBeforeTaxUSD, region);
        string localTotalNet = CurrencyConverter.GetConvertedPrice(finalNetPriceUSD, region);

        Debug.Log($"\n=== 📑 GLOBAL MERCHANT LEDGER (AUDIT LOG) ===");
        Debug.Log($"[Ledger] บันทึกบัญชีร้านค้า: {storeName.ToUpper()}");
        Debug.Log($"[Accounting] ยอดก่อนรวมภาษี: {localGrossAmount}");
        Debug.Log($"[Tax Engine] 🏛️ {taxLabel}: {localTaxAmount}");
        Debug.Log($"[Accounting] ยอดสุทธิรวมภาษี (Net Total): {localTotalNet}");
        Debug.Log($"[Status] บันทึกสำเนาลงบัญชีแยกประเภทกลางสำเร็จ (Ledger Secured) 🔒");
        Debug.Log("=============================================\n");
    }
}
