using UnityEngine;

namespace Core
{
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
            originalCameraPos = Camera.main.transform.position;
            originalCameraRot = Camera.main.transform.rotation;
        }

        public void SwitchState(MallState newState)
        {
            currentState = newState;

            if (currentState == MallState.InsideShop)
            {
                Camera.main.transform.position = new Vector3(0f, -18.5f, -4f);
                Camera.main.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
                Debug.Log("[State Switcher] 🎬 กล้องสลับเข้าสเตท: INSIDE SHOP");
            }
            else
            {
                Camera.main.transform.position = originalCameraPos;
                Camera.main.transform.rotation = originalCameraRot;
                Debug.Log("[State Switcher] 🎬 กล้องถอยกลับเข้าสเตท: OVERWORLD");
                
                // สั่งให้ระบบ UI ซ่อนตัวเองเมื่อถอยกลับเข้าเมือง
                if (StorefrontUIManager.Instance != null)
                {
                    StorefrontUIManager.Instance.HideCanvasApp();
                }
            }
        }

        void Update()
        {
            // หากผู้เล่นกดคลิกขวา หรือ Backspace ให้สั่งถอยหลังกลับและปิด UI ทันที
            if (currentState == MallState.InsideShop && (Input.GetKeyDown(KeyCode.Backspace) || Input.GetMouseButtonDown(1)))
            {
                SwitchState(MallState.Overworld);
            }
        }
    }
}
