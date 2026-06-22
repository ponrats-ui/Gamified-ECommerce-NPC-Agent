using UnityEngine;

public enum StoreVisualTheme { ModernMinimalist, ClassicTownship, CyberNeon, LuxuryGold }

public class StoreThemeManager : MonoBehaviour
{
    // ฟังก์ชันอัจฉริยะ: ปรับแต่งสกินของตึกจำลองตามธีมที่แบรนด์เลือกซื้อ/เช่าพื้นที่
    public static void ApplyThemeToStore(GameObject storeObject, StoreVisualTheme theme)
    {
        Renderer renderer = storeObject.GetComponent<Renderer>();
        if (renderer == null) return;

        switch (theme)
        {
            case StoreVisualTheme.ModernMinimalist:
                renderer.material.color = new Color(0.9f, 0.94f, 1f); // ขาวอมฟ้าสไตล์กระจกไฮเทค
                break;
            case StoreVisualTheme.ClassicTownship:
                renderer.material.color = new Color(0.85f, 0.65f, 0.45f); // น้ำตาลอบอุ่นสไตล์ร้านค้าในเมือง Township
                break;
            case StoreVisualTheme.CyberNeon:
                renderer.material.color = new Color(0.1f, 0.0f, 0.2f); // ม่วงเข้มสะท้อนแสงนีออน
                break;
            case StoreVisualTheme.LuxuryGold:
                renderer.material.color = new Color(0.85f, 0.7f, 0.2f); // ทองคำหรูหราสำหรับแบรนด์เนมระดับโลก
                break;
        }

        Debug.Log($"[Theme Engine] 🎨 เปลี่ยนสกินร้านค้า '{storeObject.name}' เป็นธีม {theme} สำเร็จ!");
    }
}
