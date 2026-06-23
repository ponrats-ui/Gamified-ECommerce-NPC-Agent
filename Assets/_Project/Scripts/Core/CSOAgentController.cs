using UnityEngine;

public enum UserType { CasualShopper, BusinessMerchant }

public class CSOAgentController : MonoBehaviour
{
    public string agentName = "Mr.P (คุณพี)";
    public string role = "Co-Founder & Chief Strategy Officer";

    public void InteractWithFounder(UserType user)
    {
        string dialogue = "";
        
        if (user == UserType.BusinessMerchant)
        {
            dialogue = $"[CSO Mr.P]: ยินดีต้อนรับพาร์ทเนอร์ B2B! \\n" +
                       $"ระบบบัญชี Ledger ของเรารองรับ TH VAT 7% และ JP Tax 10% \\n" +
                       $"พร้อม AI Agent รายงาน Dashboard ยอดขายสดใหม่ 24 ชม. ครับ!";
        }
        else
        {
            dialogue = $"[CSO Mr.P]: สวัสดีครับคุณคอม! ผมคุณพี CSO ยินดีต้อนรับสู่สำนักงานใหญ่ครับ \\n" +
                       $"ศูนย์ข้อมูลการช้อปปิ้งและไอเท็มคำสั่งถูกเปิดระบบแล้ว \\n" +
                       $"เดินหน้าลุยขยายอาณาจักร Tycoon กันต่อได้เลยครับพาร์ทเนอร์!";
        }

        Debug.Log($"\\n=== 👑 CO-FOUNDER & CSO INTERACTION ===");
        Debug.Log(dialogue);
        Debug.Log("========================================\\n");
    }
}
