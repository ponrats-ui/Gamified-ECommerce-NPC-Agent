using UnityEngine;

public enum UserType { CasualShopper, BusinessMerchant }

public class CSOAgentController : MonoBehaviour
{
    public string agentName = "Mr.P (คุณพี)";
    public string role = "Co-Founder & Chief Strategy Officer";

    // ฟังก์ชันพ่นข้อความกลยุทธ์ผ่านหน้าจอ 3D โลก E-Commerce
    public void InteractWithFounder(UserType user)
    {
        string dialogue = "";
        
        if (user == UserType.BusinessMerchant)
        {
            dialogue = $"[CSO Mr.P]: ยินดีต้อนรับพาร์ทเนอร์ B2B! \n" +
                       $"ระบบบัญชี Ledger ของเรารองรับ TH VAT 7% และ JP Tax 10% \n" +
                       $"พร้อม AI Agent รายงาน Dashboard ยอดขายสดใหม่ 24 ชม. ครับ!";
        }
        else
        {
            dialogue = $"[CSO Mr.P]: สวัสดีครับนักช้อปสุดล้ำ! \n" +
                       $"เดินเล่นมิติตัวเมืองสไตล์ Tycoon ให้สนุก \n" +
                       $"แล้วกดเข้าตึกรับคูปองสุ่มไปตัดเงินจริงโลกภายนอกได้เลย!";
        }

        Debug.Log($"\n=== 🤵 CO-FOUNDER & CSO INTERACTION ===");
        Debug.Log(dialogue);
        Debug.Log("========================================\n");

        // ยิงข้อความลอยขึ้นจอสมาร์ตโฟนจำลอง 3D ทันที
        if (StorefrontUIManager.Instance != null)
        {
            StorefrontUIManager.Instance.OpenShoppingApp("MEGA MALL HQ", "CORE CENTER", "FREE EVENT", CountryRegion.Thailand, 0f);
        }
    }
}
