using UnityEngine;

public class RTSCameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float zoomSpeed = 25f;
    
    public float minY = 5f;
    public float maxY = 35f;
    public float minX = -15f;
    public float maxX = 15f;
    public float minZ = -15f;
    public float maxZ = 15f;

    void Update()
    {
        // ระบบจะอนุญาตให้เลื่อนกล้องและซูมได้ เฉพาะตอนอยู่หน้าเมือง (Overworld) เท่านั้น
        if (Core.SceneStateManager.Instance != null && Core.SceneStateManager.Instance.currentState != Core.MallState.Overworld) return;

        Vector3 pos = transform.position;

        // 1. ระบบเลื่อนกล้องด้วยการกดปุ่ม W, A, S, D หรือลูกศร
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) { pos.z += panSpeed * Time.deltaTime; }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) { pos.z -= panSpeed * Time.deltaTime; }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) { pos.x += panSpeed * Time.deltaTime; }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) { pos.x -= panSpeed * Time.deltaTime; }

        // 2. ระบบซูมเข้า - ซูมออก ด้วย Scroll Wheel ของเมาส์ (แก้ปัญหากล้องแข็งทื่อ)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * zoomSpeed * 100f * Time.deltaTime;

        // ล็อกขอบเขตไม่ให้กล้องหลุดโลก
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
