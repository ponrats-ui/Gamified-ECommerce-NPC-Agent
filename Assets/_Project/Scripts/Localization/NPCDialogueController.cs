using UnityEngine;

public class NPCDialogueController : MonoBehaviour
{
    // ฟังก์ชันอัจฉริยะ คัดเลือกคำพูดต้อนรับตามวัฒนธรรมและภาษาของภูมิภาค
    public static string GetLocalizedWelcomeMessage(CountryRegion region, string storeName)
    {
        switch (region)
        {
            case CountryRegion.Thailand:
                return $"🙏 สวัสดีค่ะ ยินดีต้อนรับสู่ {storeName}! วันนี้เรามีสินค้าพรีเมียมพร้อมส่วนลดพิเศษสำหรับคุณค่ะ";
            
            case CountryRegion.China:
                return $"🇨🇳 欢迎光临 (ยินดีต้อนรับ)! ขอต้อนรับสู่ {storeName} ลองเลือกชมสินค้าคอลเลกชันใหม่ล่าสุดสิคะ";
            
            case CountryRegion.Japan:
                return $"🇯🇵 いらっしゃいませ (ยินดีต้อนรับ)! ยินดีต้อนรับสู่ {storeName} แหล่งรวมไอเทมยอดฮิตประจำฤดูกาลค่ะ";
            
            case CountryRegion.Korea:
                return $"🇰🇷 안녕하세요 (สวัสดีค่ะ)! ยินดีต้อนรับสู่ {storeName} มีสิทธิพิเศษเฉพาะสมาชิกกำลังรอคุณอยู่นะคะ";
            
            case CountryRegion.MiddleEast:
                return $"🇦🇪 أهلاً وسهلاً (ยินดีต้อนรับ)! ขอต้อนรับสู่ {storeName} เชิญสัมผัสประสบการณ์ช้อปปิ้งสุดหรูหราได้เลยค่ะ";
            
            default:
                return $"Welcome to {storeName}! We have premium items recommended just for you.";
        }
    }
}
