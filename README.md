# MegaVirtualMall - Vision & Technical Framework
* **Engine Target:** Unity 6 (6000.0.5f1)
* **Architecture Pattern:** Singleton Master Spawner & Event-Driven Core
* **Repository Stable Version:** 1.1.0

---

## 🎯 1. Strategic Vision (Game Mechanics & Engagement)
MegaVirtualMall พลิกโฉมประสบการณ์การช้อปปิ้งออนไลน์แบบเดิม (2D E-Commerce) ให้กลายเป็นแพลตฟอร์มโลกเสมือนสามมิติในรูปแบบ **Gamified City-Builder Tycoon** ที่ผูกโยงข้อมูลสินค้า คลังสินค้า และระบบธุรกรรมในโลกจริงเข้ากับกลไกลูปความสนุกของเกมอย่างแนบเนียน ผ่าน 3 เสาหลัก:
1. **The Living World:** สร้างระบบสภาพแวดล้อมจำลอง (Living Environment) เพื่อดึงดูดกลุ่มผู้เล่นสายผ่อนคลาย (Explorers) ให้ใช้เวลาบนแพลตฟอร์มนานขึ้น (Maximizing Retention Rate)
2. **Gamified Conversion Engine:** เปลี่ยนการล่าส่วนลดให้เป็นมินิเกมเควสต์สั้น คุยกับ NPC ประจำแบรนด์เพื่อปลดล็อกคูปอง (Real-world Vouchers) ไปใช้จริงในขั้นตอนการช้อปปิ้ง
3. **Tycoon Progression Loop:** ทุกกิจกรรมการเดินห้างหรือซื้อของจะช่วยสะสมแต้มเลเวลและประชากรในเมือง (Progression & Population Setup) เพื่อปลดล็อกสิทธิ์การแต่งเมือง สร้างแรงจูงใจให้กลับมาเปิดใช้ระบบทุกวัน

---

## 🏗️ 2. Comprehensive Business Model (The Revenue Stack)
การออกแบบสถาปัตยกรรมหลังบ้านได้รับการวางโครงสร้างระบบให้กระจายความเสี่ยงและสร้างรายได้ข้ามพรมแดนแบบยั่งยืนผ่าน 4 ช่องทางหลัก (4-Tier Revenue Stack):
* **Virtual Storefront Subscription (B2B):** คิดค่าบริการเปิดใช้งานตึกจากระบบ Spawner แยกรายสิทธิ์ของแบรนด์สร้างกระแสเงินสดคงที่ (Predictable MRR)
* **Transaction Fee / Take Rate (B2B):** หักเปอร์เซ็นต์ส่วนแบ่งผ่านระบบตะกร้าสินค้าส่วนกลาง (Global Cart) รายได้ส่วนนี้จะโตแบบก้าวกระโดดตามยอดขายรวม (GMV) ทั้งแพลตฟอร์ม
* **In-Game Retail Advertising (B2B):** เปิดบิลบอร์ดโฆษณาตามจุดจำลอง หรือส่ง AI NPC ไปโปรโมตโค้ดของสปอนเซอร์ สร้างรายได้ที่มีต้นทุนต่ำ (High-Margin Income)
* **In-game Microtransactions (B2C):** เปิดระบบให้ผู้เล่นเติมเงินซื้อไอเทมทอง/เพชรจำลอง เพื่อความสวยงามหรืออัปเกรดเมืองทางลัด เพิ่มค่า Lifetime Value (LTV) ของผู้เล่นทั่วไป

---

## 🛠️ 3. Technical Status & Roadmap

### ✅ พัฒนาเสร็จสิ้นแล้ว (Completed Core Backend Logic)
* **Automated Mall Spawner Framework:** เขียนคำสั่งเดียวระบบจัดแจงเสกตึกคูหาร้านค้าข้ามชาติขึ้นหน้าจอพร้อมกัน 5 ประเทศอัตโนมัติ (ไทย, จีน, ญี่ปุ่น, เกาหลี, ตะวันออกกลาง) รองรับการสเกลระดับ 100-1000 ตึกในอนาคต
* **Dynamic Slot & Multi-Vendor Management:** โครงสร้างหลังบ้านแยกสิทธิ์ระบบคลังสินค้า (Inventory List) ประจำแต่ละวัตถุตึกอย่างชัดเจน
* **7-Region Currency Converter Engine:** เอนจินแปลงค่าเงินตราอัตโนมัติอ้างอิงตามภูมิภาคของร้านค้านั้น ๆ แบบ Real-time ทันทีที่ระบบโหลด (แปลง  หรือ  ออกมาเป็นค่าเงิน THB ฿ หรือ JPY ¥ อย่างแม่นยำ)
* **Static Global Cart Core:** สถาปัตยกรรมตะกร้าสินค้าส่วนกลางข้ามชาติ สามารถจดจำ คัดแยก และบวกยอดเงินสะสมรวมทั้งแพลตฟอร์มได้จริงผ่านการตรวจจับ Raycasting Input

### 🔮 แผนงานขั้นต่อไป (Next Sprints Focus)
1. **Sprint 5 - Interior State Transition & UI Canvas:** สร้างระบบ State Switcher สลับกล้องจากวิวเมืองนอกร้าน ตัดสลับเข้าสู่ห้องจำลองหน้าร้านภายใน พร้อมเปิดระบบหน้าต่าง UI Canvas รูปทรงมือถือเพื่อดึงข้อมูลสินค้ามาแสดงผลหน้าจอจริง
2. **Sprint 6 - AI Agent Dialogue System:** ระบบกล่องข้อความจำลองบทสนทนาประจำชาติ (Dialogue Engine) ให้ NPC สามารถพูดต้อนรับตามสัญชาติภาษาของตึกนั้น ๆ เมื่อผู้เล่นเข้าใกล้
3. **Sprint 7 - Asset Replacement (Reskinning):** การเปลี่ยนวัตถุทรงกล่องชั่วคราว (Placeholder Assets) ให้กลายเป็นโมเดลสิ่งก่อสร้างและตัวละครสามมิติตามรูปแบบอาร์ตเวิร์กเป้าหมาย
