using UnityEngine;

public class CheckoutPaymentGateway : MonoBehaviour
{
    // ฟังก์ชันประมวลผลจำลองการส่งข้อมูลไปตัดเงินจริงผ่านระบบธนาคารข้ามชาติ
    public static void ProcessSecureCheckout(string storeName, string finalPriceText, string voucherUsed)
    {
        Debug.Log($"\n=== 🔐 WEB3 / REAL-WORLD PAYMENT GATEWAY ===");
        Debug.Log($"[Gateway] รับยอดจากร้านค้า: {storeName.ToUpper()}");
        Debug.Log($"[Gateway] ส่วนลดคูปองที่ใช้ดักจับ: {voucherUsed}");
        Debug.Log($"[Gateway] ยอดรวมสุทธิที่ส่งคำสั่งตัดบัตร: {finalPriceText}");
        Debug.Log($"[Logistics API] 🚚 สั่งการสำเร็จ: แจ้งเตือนพัสดุเตรียมแพ็กของจัดส่งในโลกจริงเรียบร้อย!");
        Debug.Log($"[Transaction] STATUS: 🟢 Purchase Successful! (200 OK)");
        Debug.Log($"================================================\n");
    }
}
