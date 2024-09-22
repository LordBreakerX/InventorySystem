using TMPro;
using UnityEngine;

namespace LordBreakerX
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        float _speed = 20;

        [SerializeField]
        private GameObject inventoryUI;

        [SerializeField]
        private GameObject hotbar;

        [SerializeField]
        private TMP_Text _healthTextbox;

        [SerializeField]
        [Min(1)]
        private int _maxHealth = 100;

        private int _health = 100;

        public static bool InventoryOpen { get; private set; }

        public static Player Instance { get; private set; }

        private void Awake()
        {
            _health = _maxHealth;
            _healthTextbox.text = "Health: " + _health.ToString();
        }

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void OnDisable()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        void Update()
        {
            float xMovement = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
            float yMovement = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

            transform.position = transform.position + new Vector3(xMovement, yMovement);

            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryOpen = !InventoryOpen;
                inventoryUI.SetActive(InventoryOpen);
                hotbar.SetActive(!InventoryOpen);

                if (InventoryOpen && Chest.OpenableChest != null) 
                {
                    Chest.OpenableChest.OpenChest();
                }
                else if (!InventoryOpen && Chest.OpenableChest != null)
                {
                    Chest.OpenableChest.CloseChest();
                }
            }
        }

        public void CloseInventory()
        {
            InventoryOpen = false;
            inventoryUI.SetActive(InventoryOpen);
            hotbar.SetActive(!InventoryOpen);
            if (Chest.OpenableChest != null) Chest.OpenableChest.CloseChest();
        }

        public void Damage(int amount)
        {
            _health = Mathf.Max(_health - amount, 0);
            _healthTextbox.text = "Health: " + _health.ToString();
        }

        public void Heal(int amount)
        {
            _health = Mathf.Min(_maxHealth, _health + amount);
            _healthTextbox.text = "Health: " + _health.ToString();
        }
    }
}
