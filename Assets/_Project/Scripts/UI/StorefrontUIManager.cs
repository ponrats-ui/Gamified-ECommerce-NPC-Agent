using UnityEngine;

public class StorefrontUIManager : MonoBehaviour
{
    public static StorefrontUIManager Instance { get; private set; }

    [Header("3D Phone Virtual Screen")]
    private GameObject virtualPhoneObject;
    private TextMesh titleTextMesh;
    private TextMesh contentTextMesh;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        Create3DVirtualPhone();
    }

    // 🏗️ ปฏิวัติวงการ: สร้างหน้าจอจำลองด้วย 3D Primitives สยบบั๊ก Unity 6
    private void Create3DVirtualPhone()
    {
        // 1. สร้างบอร์ดป้ายหน้าจอ 3D ผืนผ้า
        virtualPhoneObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        virtualPhoneObject.name = "Virtual_3D_Smartphone_Screen";
        
        // ติดตั้งตัวตรวจจับและตั้งพิกัดให้อยู่ตรงหน้ามุมกล้องภายในร้านพอดี!
        virtualPhoneObject.transform.position = new Vector3(0f, -18.5f, 1f); 
        virtualPhoneObject.transform.localScale = new Vector3(2.5f, 4f, 0.1f);
        virtualPhoneObject.GetComponent<Renderer>().material.color = new Color(0.05f, 0.05f, 0.05f); // สีดำหรู

        // 2. เสกข้อความลอยฟ้าหัวเรื่อง (Title 3D Text)
        GameObject titleObj = new GameObject("3D_Title_Text");
        titleObj.transform.SetParent(virtualPhoneObject.transform);
        titleObj.transform.localPosition = new Vector3(-0.45f, 0.4f, -0.6f);
        titleObj.transform.localScale = new Vector3(0.05f, 0.04f, 1f);
        titleTextMesh = titleObj.AddComponent<TextMesh>();
        titleTextMesh.fontSize = 60;
        titleTextMesh.color = Color.cyan;

        // 3. เสกข้อความรายละเอียดสินค้าและคูปอง (Content 3D Text)
        GameObject contentObj = new GameObject("3D_Content_Text");
        contentObj.transform.SetParent(virtualPhoneObject.transform);
        contentObj.transform.localPosition = new Vector3(-0.45f, 0.2f, -0.6f);
        contentObj.transform.localScale = new Vector3(0.04f, 0.035f, 1f);
        contentTextMesh = contentObj.AddComponent<TextMesh>();
        contentTextMesh.fontSize = 40;
        contentTextMesh.color = Color.white;

        // ตอนเริ่มเกม ให้ซ่อนป้ายหน้าจอสมาร์ทโฟน 3D นี้ไว้ใต้ดินก่อน
        virtualPhoneObject.SetActive(false);
    }

    // 📱 ฟังก์ชันยิงข้อมูลอัปเดตหน้าจอแอป 3D
    public void OpenShoppingApp(string storeName, string regionName, string itemPriceText, CountryRegion region, float baseItemPrice)
    {
        if (virtualPhoneObject == null) return;

        string npcSpeech = NPCDialogueController.GetLocalizedWelcomeMessage(region, storeName);
        var assignedVoucher = VoucherRewardSystem.GenerateRandomVoucher(region);
        float discountedBasePrice = VoucherRewardSystem.CalculateDiscountedPrice(baseItemPrice, assignedVoucher.discountPercentage);
        string localDiscountedPriceText = CurrencyConverter.GetConvertedPrice(discountedBasePrice, region);

        // แสดงผลข้อความลอยฟ้าของจริงบนโลก 3D!
        titleTextMesh.text = storeName.ToUpper();
        
        // ตัดบรรทัดข้อความให้แสดงผลสวยงามบนป้าย 3D
        contentTextMesh.text = $"[ZONE: {regionName}]\n\n" +
                               $"NPC: {npcSpeech.Substring(0, Mathf.Min(npcSpeech.Length, 35))}...\n\n" +
                               $"Original Price: {itemPriceText}\n" +
                               $"Voucher Code: {assignedVoucher.code}\n" +
                               $"PROMO PRICE: {localDiscountedPriceText} 🔥\n\n" +
                               $"--> CLICK RIGHT MOUSE OR BACKSPACE\n" +
                               $"    TO RETURN TO TOWN";

        virtualPhoneObject.SetActive(true);

        // รายงานภาพรวมแดชบอร์ด POS ของ AI Manager ควบคู่
        string storeReport = StoreAIAgentManager.GenerateStoreReport(storeName, region, 1250f, 3);
        Debug.Log(storeReport);
    }

    public void HideCanvasApp()
    {
        if (virtualPhoneObject != null) virtualPhoneObject.SetActive(false);
    }
}
