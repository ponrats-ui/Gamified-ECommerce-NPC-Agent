using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StorefrontUIManager : MonoBehaviour
{
    public static StorefrontUIManager Instance { get; private set; }

    [Header("UI Canvas Hierarchy")]
    private GameObject canvasObject;
    private GameObject appPanel;
    private Text shopNameText;
    private Text npcSpeechText;
    private Text priceText;
    private Text voucherText;
    private Button backButton;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        CreateDynamicCanvasFramework();
    }

    // 🏗️ มหากาพย์ฟังก์ชัน: สั่งเสกโครงสร้าง UI Canvas ทั้งหมดจากอากาศธาตุด้วยโค้ด 100%
    private void CreateDynamicCanvasFramework()
    {
        // 1. สร้างวัตถุ Canvas หลัก
        canvasObject = new GameObject("Dynamic_Shopping_Canvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasObject.AddComponent<GraphicRaycaster>();
        canvasObject.transform.SetParent(this.transform);

        // 2. สร้างแผง Panel จำลองกรอบหน้าจอมือถือสี่เหลี่ยมแนวตั้ง (Smartphone Frame)
        appPanel = new GameObject("Smartphone_Panel");
        Image panelImage = appPanel.AddComponent<Image>();
        panelImage.color = new Color(0.1f, 0.1f, 0.1.f, 0.95f); // สีดำหรูโปร่งแสงนิดๆ
        RectTransform panelRect = appPanel.GetComponent<RectTransform>();
        panelRect.SetParent(canvasObject.transform);
        panelRect.anchorMin = new Vector2(0.5f, 0.5f);
        panelRect.anchorMax = new Vector2(0.5f, 0.5f);
        panelRect.pivot = new Vector2(0.5f, 0.5f);
        panelRect.sizeDelta = new Vector2(400f, 650f); // อัตราส่วนหน้าจอมือถือแนวตั้งเป๊ะๆ

        // สร้าง Font มาตรฐานชั่วคราว
        Font arialFont = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // 3. เสกกล่องข้อความชื่อร้านค้า (Shop Title Text)
        GameObject shopTitleObj = new GameObject("Text_ShopTitle");
        shopNameText = shopTitleObj.AddComponent<Text>();
        shopNameText.font = arialFont;
        shopNameText.fontSize = 24;
        shopNameText.alignment = TextAnchor.MiddleCenter;
        shopNameText.color = Color.cyan;
        RectTransform titleRect = shopTitleObj.GetComponent<RectTransform>();
        titleRect.SetParent(appPanel.transform);
        titleRect.anchoredPosition = new Vector3(0f, 270f, 0f);
        titleRect.sizeDelta = new Vector2(350f, 50f);

        // 4. เสกกล่องคำพูด NPC ประจำชาติ (NPC Speech Text)
        GameObject npcTextObj = new GameObject("Text_NPCSpeech");
        npcSpeechText = npcTextObj.AddComponent<Text>();
        npcSpeechText.font = arialFont;
        npcSpeechText.fontSize = 18;
        npcSpeechText.alignment = TextAnchor.UpperLeft;
        npcSpeechText.color = Color.white;
        RectTransform npcRect = npcTextObj.GetComponent<RectTransform>();
        npcRect.SetParent(appPanel.transform);
        npcRect.anchoredPosition = new Vector3(0f, 150f, 0f);
        npcRect.sizeDelta = new Vector2(350f, 120f);

        // 5. เสกป้ายโชว์ราคาตั้งต้น (Price Text)
        GameObject priceObj = new GameObject("Text_PriceDisplay");
        priceText = priceObj.AddComponent<Text>();
        priceText.font = arialFont;
        priceText.fontSize = 20;
        priceText.alignment = TextAnchor.MiddleCenter;
        priceText.color = Color.gray;
        RectTransform priceRect = priceObj.GetComponent<RectTransform>();
        priceRect.SetParent(appPanel.transform);
        priceRect.anchoredPosition = new Vector3(0f, 20f, 0f);
        priceRect.sizeDelta = new Vector2(350f, 40f);

        // 6. เสกป้ายคูปองและราคาลดพิเศษสายเดือด (Voucher & Discount Text)
        GameObject voucherObj = new GameObject("Text_VoucherDisplay");
        voucherText = voucherObj.AddComponent<Text>();
        voucherText.font = arialFont;
        voucherText.fontSize = 22;
        voucherText.alignment = TextAnchor.MiddleCenter;
        voucherText.color = Color.green;
        RectTransform voucherRect = voucherObj.GetComponent<RectTransform>();
        voucherRect.SetParent(appPanel.transform);
        voucherRect.anchoredPosition = new Vector3(0f, -50f, 0f);
        voucherRect.sizeDelta = new Vector2(350f, 50f);

        // 7. เสกปุ่มกดปิด/ถอยกลับไปแผนที่เมือง (Back Button) ลอยเด่นขอบล่าง
        GameObject btnObj = new GameObject("Button_BackToTown");
        Image btnImage = btnObj.AddComponent<Image>();
        btnImage.color = new Color(0.8f, 0.2f, 0.2f, 1f); // สีแดงโดดเด่น
        backButton = btnObj.AddComponent<Button>();
        RectTransform btnRect = btnObj.GetComponent<RectTransform>();
        btnRect.SetParent(appPanel.transform);
        btnRect.anchoredPosition = new Vector3(0f, -240f, 0f);
        btnRect.sizeDelta = new Vector2(250f, 50f);

        // เติมตัวอักษรใส่ปุ่มกด Back
        GameObject btnTextObj = new GameObject("Text");
        Text btnText = btnTextObj.AddComponent<Text>();
        btnText.font = arialFont;
        btnText.text = "CLOSE / BACK TO TOWN";
        btnText.fontSize = 16;
        btnText.alignment = TextAnchor.MiddleCenter;
        btnText.color = Color.white;
        btnText.GetComponent<RectTransform>().SetParent(btnObj.transform);
        btnText.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;

        // ผูก Event ปุ่มกด ให้วิ่งไปสั่ง State Manager ถอยกลับเข้าเมืองทันทีเมื่อคลิก!
        backButton.onClick.AddListener(() => {
            if (UnityEngine.EventSystems.EventSystem.current != null)
            {
                // บังคับปลดโฟกัสปุ่มป้องกันบั๊กกดย้ำ
                UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            }
            TriggerBackToTown();
        });

        // ตอนเริ่มเกม ให้ซ่อนหน้าต่างแอปมือถือไว้ก่อนชั่วคราว
        appPanel.SetActive(false);
    }

    // 📱 ฟังก์ชันอัปเดตหน้าตา UI และสั่งแสดงผลบนจอจริงแบบ Real-time
    public void OpenShoppingApp(string storeName, string regionName, string itemPriceText, CountryRegion region, float baseItemPrice)
    {
        if (appPanel == null) return;

        // ดึงระบบจำลองคำพูดและระบบคูปองส่วนลดหลังบ้านมาประมวลผล
        string npcSpeech = NPCDialogueController.GetLocalizedWelcomeMessage(region, storeName);
        var assignedVoucher = VoucherRewardSystem.GenerateRandomVoucher(region);
        float discountedBasePrice = VoucherRewardSystem.CalculateDiscountedPrice(baseItemPrice, assignedVoucher.discountPercentage);
        string localDiscountedPriceText = CurrencyConverter.GetConvertedPrice(discountedBasePrice, region);

        // พ่นข้อมูลลงสู่ Text Component บนหน้าจอจริงของยูสเซอร์!
        shopNameText.text = storeName.ToUpper();
        npcSpeechText.text = npcSpeech;
        priceText.text = $"ราคาตั้งต้น: {itemPriceText}";
        voucherText.text = $"โค้ด: {assignedVoucher.code} ลดเหลือ {localDiscountedPriceText} 🔥";

        // เปิดสวิตช์แสดงหน้าจอแอปมือถือลอยขึ้นมา!
        appPanel.SetActive(true);

        // พ่น Log รายงานแดชบอร์ด AI ควบคู่ไปด้วย
        string storeReport = StoreAIAgentManager.GenerateStoreReport(storeName, region, 1250f, 3);
        Debug.Log(storeReport);
    }

    private void TriggerBackToTown()
    {
        appPanel.SetActive(false);
        if (Core.SceneStateManager.Instance != null)
        {
            Core.SceneStateManager.Instance.SwitchState(Core.MallState.Overworld);
        }
    }

    // ฟังก์ชันเปิดทางให้ State Manager สั่งซ่อนหน้าจอได้กรณีผู้เล่นกดคลิกขวาถอยหลัง
    public void HideCanvasApp()
    {
        if (appPanel != null) appPanel.SetActive(false);
    }
}
