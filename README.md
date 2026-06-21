# MegaVirtualMall (Gamified E-Commerce Architecture)
พัฒนาภายใต้เอนจิน **Unity 6 (6000.0.5f1)**

## 🎯 Target Product Goal
ระบบจำลองห้างสรรพสินค้าเสมือนจริงในรูปแบบ Gamified Tycoon ที่เชื่อมต่อโลกเกมเข้ากับข้อมูลสินค้าและการชำระเงินในโลกจริง (Real-World E-Commerce Integration)

## 🏗️ ปัจจุบันเสร็จสิ้นแล้ว (Core Backend Logic)
* **Master Spawner:** ระบบจัดการแผงวงจรส่วนกลาง สั่งเสกโครงสร้างที่ดินร้านค้าข้ามชาติอัตโนมัติรวดเดียวจบ
* **Multi-Vendor Core:** ระบบผูกข้อมูลคลังสินค้า (Inventory) แยกตามรายร้านค้า
* **Global Cart:** ระบบตะกร้าสินค้าส่วนกลางคำนวณยอดรวมทั้งแพลตฟอร์ม
* **7-Region Currency Converter:** เอนจินคำนวณและแปลงค่าเงินตราท้องถิ่น Real-time ผูกตามสัญชาติภูมิภาคของร้านค้า (THB, CNY, JPY, KRW, VND, AED)

## 🗺️ Next Milestones (Sprint 5)
* **Interior State Transition:** ระบบสลับสถานะจำลองการเดินก้าวเข้าสู่ภายในหน้าร้านค้าย่อย (Greyboxing Room)
* **UI Mobile App Canvas:** พัฒนาระบบหน้าต่าง UI แสดงตู้สินค้าที่ดึงค่ามาจากระบบคำนวณอัตราแลกเปลี่ยน
* **NPC Dialogue Controller:** ระบบกล่องคำพูดสำหรับพนักงานประจำร้าน
