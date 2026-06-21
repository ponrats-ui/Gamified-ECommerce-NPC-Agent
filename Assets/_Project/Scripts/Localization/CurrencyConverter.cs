using UnityEngine;

// ลงทะเบียนประเภทโซนประเทศไว้ตรงนี้ด้วย เพื่อป้องกันปัญหาหาข้ามโฟลเดอร์ไม่เจอ
#if !COUNTRY_REGION_DEFINED
public enum CountryRegion
{
    Global, Thailand, China, Japan, Korea, Vietnam, MiddleEast
}
#endif

public class CurrencyConverter : MonoBehaviour
{
    public static string GetConvertedPrice(float priceInUSD, CountryRegion region)
    {
        float exchangeRate = 1.0f;
        string currencySymbol = "USD ($)";

        switch (region)
        {
            case CountryRegion.Thailand:
                exchangeRate = 36.5f; 
                currencySymbol = "THB (฿)";
                break;
            case CountryRegion.China:
                exchangeRate = 7.2f;  
                currencySymbol = "CNY (¥)";
                break;
            case CountryRegion.Japan:
                exchangeRate = 155.0f; 
                currencySymbol = "JPY (¥)";
                break;
            case CountryRegion.Korea:
                exchangeRate = 1350.0f; 
                currencySymbol = "KRW (₩)";
                break;
            case CountryRegion.Vietnam:
                exchangeRate = 25000.0f; 
                currencySymbol = "VND (₫)";
                break;
            case CountryRegion.MiddleEast:
                exchangeRate = 3.67f; 
                currencySymbol = "AED (د.إ)";
                break;
            default:
                exchangeRate = 1.0f;
                currencySymbol = "USD ($)";
                break;
        }

        float finalPrice = priceInUSD * exchangeRate;
        return finalPrice.ToString("F2") + " " + currencySymbol;
    }
}
