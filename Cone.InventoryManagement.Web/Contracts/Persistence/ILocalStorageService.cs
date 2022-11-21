﻿namespace Cone.InventoryManagement.Web.Contracts.Persistence
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> keys);

        bool Exists(string key);

        T GetStorageValue<T>(string key);

        void SetStorageValue<T>(T storageValue, string key);
    }
}
