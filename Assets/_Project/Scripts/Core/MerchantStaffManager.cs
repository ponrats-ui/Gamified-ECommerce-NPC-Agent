using UnityEngine;
using System.Collections.Generic;

public enum StaffRole { FrontDeskSupport, TaxAuditor, LogisticsCourier }

[System.Serializable]
public class AIAgentStaff
{
    public string staffName;
    public StaffRole role;
    public float salaryPerCycleGold;
    public bool isActive;

    public AIAgentStaff(string name, StaffRole role, float salary)
    {
        this.staffName = name;
        this.role = role;
        this.salaryPerCycleGold = salary;
        this.isActive = true;
    }
}

public class MerchantStaffManager : MonoBehaviour
{
    public static MerchantStaffManager Instance { get; private set; }
    
    // คลังเก็บรายชื่อลูกน้อง AI ที่เราจ้างมาใช้งาน
    public List<AIAgentStaff> hiredStaffList = new List<AIAgentStaff>();

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        // เริ่มต้นระบบ: อนุมัติจ้างลูกน้อง 2 ตำแหน่งแรกตามคำสั่ง Founder คุณคอม
        HireNewStaff("Nong Som (น้องส้ม)", StaffRole.FrontDeskSupport, 150f);
        HireNewStaff("Khun Kitti (คุณกิตติ)", StaffRole.TaxAuditor, 300f);
    }

    public void HireNewStaff(string name, StaffRole role, float salary)
    {
        AIAgentStaff newStaff = new AIAgentStaff(name, role, salary);
        hiredStaffList.Add(newStaff);
        
        Debug.Log($"[HR Engine] 👥 บอร์ดจัดจ้างอนุมัติสำเร็จ: รับ '{name}' เข้าทำงานในตำแหน่ง [{role}] (ค่าจ้าง: {salary} Gold/ชม.)");
    }

    // ฟังก์ชันกระจายงาน: ให้ลูกน้องออกมาทำหน้าที่แทนคุณพี
    public void DelegateTasksToStaff()
    {
        Debug.Log($"\n=== 📊 REPORT: AI AGENT STAFF DELEGATION ===");
        foreach (var staff in hiredStaffList)
        {
            if (staff.role == StaffRole.FrontDeskSupport)
            {
                Debug.Log($"[👤 {staff.staffName}]: 'สวัสดีค่ะผู้เล่นทุกท่าน วิธีหาไอเท็มคือเดินสำรวจรอบตึกนานาชาติและเก็บคูปองส่วนลดค่ะ!'");
            }
            else if (staff.role == StaffRole.TaxAuditor)
            {
                Debug.Log($"[📊 {staff.staffName}]: 'เรียนคุณคอมและคุณพี บิลภาษี TH VAT 7% และ Ledger ทุกโซนตรวจสอบแล้ว ถูกต้องกริบ 100% ครับ!'");
            }
        }
        Debug.Log($"============================================\n");
    }
}
