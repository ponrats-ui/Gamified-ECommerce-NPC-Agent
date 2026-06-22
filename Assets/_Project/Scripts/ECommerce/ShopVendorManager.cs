using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct ProductItem
{
    public string productName;
    public float price;
    public string currency;
}

public class ShopVendorManager : MonoBehaviour
{
    [Header("Vendor Profile")]
    public string vendorName = "Unassigned Vendor";
    public string businessType = "General Retail";
    
    [Header("Store Inventory (Sample)")]
    public List<ProductItem> inventory = new List<ProductItem>();

    [Header("Global Shopping Cart")]
    private static List<ProductItem> globalCart = new List<ProductItem>();

    void Start()
    {
        // จำลองการใส่สินค้าเริ่มต้นให้กับร้านค้าจำลองนี้
        if (inventory.Count == 0)
        {
            inventory.Add(new ProductItem { productName = "Premium T-Shirt", price = 25.00f, currency = "USD" });
            inventory.Add(new ProductItem { productName = "Smart Gadget", price = 99.00f, currency = "USD" });
        }
    }

    // ฟังก์ชันหลักสำหรับให้ผู้เล่นกดซื้อสินค้าจากร้านนี้เข้าตะกร้าส่วนกลาง
    public void AddToCart(int itemIndex)
    {
        if (itemIndex >= 0 && itemIndex < inventory.Count)
        {
            ProductItem selectedItem = inventory[itemIndex];
            globalCart.Add(selectedItem);
            
            Debug.Log($"[Shopping Cart] เพิ่ม '" + selectedItem.productName + "' ($" + selectedItem.price + ") เข้าตะกร้าส่วนกลางเรียบร้อย!");
            DisplayTotalCartValue();
        }
    }

    private void DisplayTotalCartValue()
    {
        float total = 0;
        foreach (var item in globalCart)
        {
            total += item.price;
        }
        Debug.Log($"[Global Cart Summary] จำนวนสินค้าในตะกร้าขณะนี้: " + globalCart.Count + " ชิ้น | ยอดรวมทั้งแพลตฟอร์ม: $" + total);
    }
}
