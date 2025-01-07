using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.GoldHolder.Behaviours
{
    public class GoldHolder: MonoBehaviour
    {
        public TextMeshProUGUI Amount;
        private IStorageUiService _storageUiService;

        [Inject]
        private void Construct(IStorageUiService storageUiService)
        {
            _storageUiService = storageUiService;
        }
        
        private void Start()
        {
            _storageUiService.GoldChanged += UpdateGold;
            
            UpdateGold();
        }
        
        private void OnDestroy()
        {
            _storageUiService.GoldChanged -= UpdateGold;
        }

        private void UpdateGold()
        {
            Amount.text = _storageUiService.CurrentGold.ToString("0");
        }
    }
}