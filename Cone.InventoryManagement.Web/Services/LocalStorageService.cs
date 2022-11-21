using Cone.InventoryManagement.Web.Contracts.Persistence;
using Hanssens.Net;

namespace Cone.InventoryManagement.Web.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private LocalStorage _storage;

        public LocalStorageService()
        {
            var config = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "ConeInvWeb"
            };

            _storage = new LocalStorage(config);
        }
    
        public void ClearStorage(List<string> keys)
        {
            foreach (string key in keys)
            {
                _storage.Remove(key);
            }
        }

        public bool Exists(string key)
        {
            return _storage.Exists(key);
        }

        public T GetStorageValue<T>(string key)
        {
            return _storage.Get<T>(key);
        }

        public void SetStorageValue<T>(T storageValue, string key)
        {
            _storage.Store(key, storageValue);
            _storage.Persist();
        }
    }
}
