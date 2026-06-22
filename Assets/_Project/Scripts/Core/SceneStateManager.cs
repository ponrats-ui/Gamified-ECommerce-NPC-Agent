using UnityEngine;

public enum MallState { Overworld, InsideShop }

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager Instance { get; private set; }
    
    public MallState currentState = MallState.Overworld;
    
    private Vector3 originalCameraPos;
    private Quaternion originalCameraRot;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    void Start()
    {
        // จดจำตำแหน่งกล้องหลักในวิวเมืองไว้ก่อน
        originalCameraPos = Camera.main.transform.position;
        originalCameraRot = Camera.main.transform.rotation;
    }

    // ฟังก์ชันสั่งสลับฉากข้ามมิติ
    public void SwitchState(MallState newState)
    {
        currentState = newState;

        if (currentState == MallState.InsideShop)
        {
            // วาร์ปกล้องหลักลงมาโฟกัสที่ห้องภายในร้านค้าย่อยด้านล่างทันที!
            Camera.main.transform.position = new Vector3(0f, -18.5f, -4f);
            Camera.main.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
            Debug.Log("[State Switcher] 🎬 กล้องสลับเข้าสเตท: INSIDE SHOP (ภายในหน้าร้าน)");
        }
        else
        {
            // ดึงกล้องกลับไปที่วิวเมืองตามเดิม
            Camera.main.transform.position = originalCameraPos;
            Camera.main.transform.rotation = originalCameraRot;
            Debug.Log("[State Switcher] 🎬 กล้องถอยกลับเข้าสเตท: OVERWORLD (แผนที่เมือง)");
        }
    }

    void Update()
    {
        // ปุ่มลัดทางเลือก: กดปุ่ม Backspace หรือคลิกขวา เพื่อกดออกจากร้านค้าถอยกลับไปที่เมือง
        if (currentState == MallState.InsideShop && (Input.GetKeyDown(KeyCode.Backspace) || Input.GetMouseButtonDown(1)))
        {
            SwitchState(MallState.Overworld);
        }
    }
}
