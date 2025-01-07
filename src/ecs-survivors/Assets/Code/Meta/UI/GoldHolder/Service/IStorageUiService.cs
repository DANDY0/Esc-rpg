using System;

namespace Code.Meta.UI.GoldHolder.Service
{
    public interface IStorageUiService
    {
        event Action GoldChanged;
        float CurrentGold { get; }
        void UpdateCurrentGold(float gold);
        void Cleanup();
    }
}