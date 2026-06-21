using UnityEngine;

public enum CountryRegion
{
    Global, Thailand, China, Japan, Korea, Vietnam, MiddleEast
}

public class GlobalCountryZone : MonoBehaviour
{
    [Header("Platform Space Setup")]
    public CountryRegion region = CountryRegion.Global;
    public string plotID;
    public string currentTenant = "Available for Rent";
    public bool isRented = false;
    public float monthlyRentPrice = 49.00f; 

    void Start()
    {
        if (string.IsNullOrEmpty(plotID))
        {
            plotID = "PLOT-" + System.Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
        Debug.Log("[Virtual Mall] Plot ID: " + plotID + " in region: " + region + " is ready.");
    }

    // อัปเดต: ใช้ระบบ Update ตรวจจับเมาส์โดยตรง รองรับ Unity 6 ทุกรูปแบบ
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // เมื่อผู้เล่นคลิกซ้าย
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // ถ้าเมาส์จิ้มโดนกล่อง Cube กล่องนี้พอดี
                if (hit.transform == this.transform)
                {
                    TriggerClickAction();
                }
            }
        }
    }

    private void TriggerClickAction()
    {
        if (!isRented)
        {
            Debug.Log("[Business UI] Space Available! Region: " + region + " | Price: $" + monthlyRentPrice);
        }
        else
        {
            Debug.Log("[Storefront] Welcome to " + currentTenant);
        }
    }
}
