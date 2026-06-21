using UnityEngine;

public class GlobalCountryZone : MonoBehaviour
{
    [Header("Platform Space Setup")]
    public CountryRegion region = CountryRegion.Thailand; // รอบนี้ตั้งต้นลองเป็นประเทศไทยดูเลยครับ!
    public string plotID;
    public string currentTenant = "Siam Paragon Simulated Shop"; 
    public bool isRented = true; 
    public float monthlyRentPrice = 49.00f; 

    private ShopVendorManager vendorManager;

    void Start()
    {
        if (string.IsNullOrEmpty(plotID))
        {
            plotID = "PLOT-" + System.Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }
        
        vendorManager = GetComponent<ShopVendorManager>();
        
        // แปลงค่าเช่าที่ดินรายเดือนเป็นค่าเงินประจำชาตินั้น ๆ โชว์ตั้งแต่เปิดระบบ
        string convertedRent = CurrencyConverter.GetConvertedPrice(monthlyRentPrice, region);
        Debug.Log("[Virtual Mall] Plot ID: " + plotID + " (" + region + ") is active. Rent Price: " + convertedRent);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
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
            string convertedRent = CurrencyConverter.GetConvertedPrice(monthlyRentPrice, region);
            Debug.Log("[Business UI] Space Available! Region: " + region + " | Price: " + convertedRent);
        }
        else
        {
            Debug.Log("[Storefront] ยินดีต้อนรับสู่ร้าน: " + currentTenant + " (โซนประเทศ: " + region + ")");
            
            if (vendorManager != null && vendorManager.inventory.Count > 0)
            {
                // ดึงสินค้าชิ้นแรกออกมาราคากลาง 
                var item = vendorManager.inventory[0];
                
                // สั่งแปลงค่าเงิน  ของสินค้าชิ้นนั้น ให้กลายเป็นเงินบาท หรือเงินประจำโซนประเทศทันที!
                string localPriceText = CurrencyConverter.GetConvertedPrice(item.price, region);
                
                Debug.Log("[Currency Engine] แปลงค่าเงินสินค้า '" + item.productName + "' จากราคาฐาน $" + item.price + " -> กลายเป็นค่าเงินท้องถิ่น: " + localPriceText);
                
                vendorManager.AddToCart(0);
            }
        }
    }
}
