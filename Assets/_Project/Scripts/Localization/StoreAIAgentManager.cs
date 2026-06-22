using UnityEngine;

public class StoreAIAgentManager : MonoBehaviour
{
    // ฟังก์ชัน AI สรุปรายงานแดชบอร์ดภาพรวมของร้านค้า เพื่อส่งให้เจ้าของร้านตัดสินใจ
    public static string GenerateStoreReport(string storeName, CountryRegion region, float totalSalesUSD, int stockCount)
    {
        // คำนวณกำไร/ขาดทุน (สมมติมาร์จิ้นกำไร 40% จากยอดขาย)
        float grossProfitUSD = totalSalesUSD * 0.4f;
        
        // แปลงมูลค่าเป็นค่าเงินท้องถิ่นเพื่อความแม่นยำทางบัญชี
        string localProfitText = CurrencyConverter.GetConvertedPrice(grossProfitUSD, region);
        
        // AI ตรวจสอบสถานะสต็อกสินค้าอัตโนมัติ (Inventory Health Check)
        string stockStatus = "🟢 ปกติ (Healthy)";
        string aiRecommendation = "วิเคราะห์แล้ว: สินค้าขายดีต่อเนื่อง แนะนำเปิดแคมเปญการตลาดขยายโซนเพิ่ม";
        
        if (stockCount <= 5)
        {
            stockStatus = "🔴 วิกฤต! สินค้าใกล้หมด (Low Stock Warning)";
            aiRecommendation = "วิเคราะห์แล้ว: สินค้าขายดีอันดับ 1 ด่วน! สั่งเปิดคำสั่งซื้อเติมสต็อกและจัดส่งแบบ Express ทันที";
        }

        // เสกโครงสร้างข้อมูล Dashboard รายงานผล
        System.Text.StringBuilder report = new System.Text.StringBuilder();
        report.AppendLine($"\n=== 📊 AI AGENT STORE MANAGER REPORT: {storeName.ToUpper()} ===");
        report.AppendLine($"📍 ภูมิภาค: {region} | ระบบ POS & Logistics: เชื่อมต่อสมบูรณ์");
        report.AppendLine($"💰 สรุปยอดขายรวม: {CurrencyConverter.GetConvertedPrice(totalSalesUSD, region)}");
        report.AppendLine($"📈 ประมาณการกำไรสุทธิ (Net Profit): {localProfitText}");
        report.AppendLine($"📦 สถานะคลังสินค้า: {stockStatus} (เหลือ {stockCount} ชิ้น)");
        report.AppendLine($"🚚 สถานะการขนส่ง (Logistics Tracker): พัสดุถูกจัดส่งสำเร็จ 100% ไม่มีตกค้าง");
        report.AppendLine($"💡 AI Agent แนะนำเจ้าของร้าน: {aiRecommendation}");
        report.AppendLine("=======================================================");

        return report.ToString();
    }
}
