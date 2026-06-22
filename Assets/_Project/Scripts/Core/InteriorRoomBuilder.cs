using UnityEngine;

public class InteriorRoomBuilder : MonoBehaviour
{
    public static InteriorRoomBuilder Instance { get; private set; }
    
    [Header("Interior Placement Location")]
    public Vector3 roomPosition = new Vector3(0f, -20f, 0f); // ซ่อนห้องไว้ใต้ดิน ลึก 20 เมตรเพื่อไม่ให้บังวิวเมือง!

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    void Start()
    {
        // 1. เสกพื้นห้องภายในร้านค้าย่อย
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.name = "Interior_Shop_Floor";
        floor.transform.position = roomPosition;
        floor.transform.localScale = new Vector3(1.5f, 1f, 1.5f); // ขนาดห้องกว้างกำลังดี

        // 2. เสกกล่องลูกบาศก์จำลองโต๊ะเคาน์เตอร์แคชเชียร์ (เหมือนในวิดีโอ)
        GameObject counter = GameObject.CreatePrimitive(PrimitiveType.Cube);
        counter.name = "Interior_Cashier_Counter";
        counter.transform.position = roomPosition + new Vector3(0f, 0.5f, 2f);
        counter.GetComponent<Renderer>().material.color = Color.gray; // สีเทาชั่วคราว
        
        Debug.Log("[Interior System] เนรมิตโครงสร้างห้องจำลองภายในร้านค้าใต้ดินเรียบร้อย!");
    }
}
