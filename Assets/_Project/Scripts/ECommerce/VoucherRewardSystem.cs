using UnityEngine;

public class VoucherRewardSystem : MonoBehaviour
{
    // โครงสร้างข้อมูลคูปองส่วนลด
    public struct Voucher
    {
        public string code;
        public float discountPercentage; // เช่น 0.10f คือลด 10%
        public string description;
    }

    // ฟังก์ชันอัจฉริยะ: AI Agent สุ่มเสกคูปองมอบแด่ผู้เล่นเมื่อเข้าชมร้านค้า
    public static Voucher GenerateRandomVoucher(CountryRegion region)
    {
        Voucher newVoucher = new Voucher();
        int randomChoice = Random.Range(0, 3);

        switch (randomChoice)
        {
            case 0:
                newVoucher.code = "LUCKYMALL10";
                newVoucher.discountPercentage = 0.10f;
                newVoucher.description = "คูปองต้อนรับนักช้อปหน้าใหม่ ลดทันที 10%";
                break;
            case 1:
                newVoucher.code = "SUPERSALE20";
                newVoucher.discountPercentage = 0.20f;
                newVoucher.description = "คูปองพิเศษสุดเร้าใจจาก AI Agent ลดเน้น ๆ 20%";
                break;
            default:
                newVoucher.code = "MALLFREE5";
                newVoucher.discountPercentage = 0.05f;
                newVoucher.description = "คูปองปลอบใจสายเดินชิลล์ ลดเบา ๆ 5%";
                break;
        }

        Debug.Log($"[Reward Engine] 🎁 AI Agent มอบสิทธิ์พิเศษ คูปองโค้ด: {newVoucher.code} ({newVoucher.description})");
        return newVoucher;
    }

    // ฟังก์ชัน POS คำนวณราคาสินค้าหลังหักส่วนลดคูปอง
    public static float CalculateDiscountedPrice(float originalPrice, float discountPercentage)
    {
        return originalPrice * (1.0f - discountPercentage);
    }
}
