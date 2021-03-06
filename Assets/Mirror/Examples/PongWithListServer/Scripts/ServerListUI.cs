using System.Collections.Generic;
using Mirror.CloudServices.ListServerService;
using UnityEngine;

namespace Mirror.CloudServices.Example
{
    public class ServerListUI : MonoBehaviour
    {
        [SerializeField] ServerListUIItem itemPrefab = null;
        [SerializeField] Transform parent = null;

        readonly List<ServerListUIItem> items = new List<ServerListUIItem>();

        void OnValidate()
        {
            if (parent == null)
            {
                parent = transform;
            }
        }

        public void UpdateList(ServerCollectionJson serverCollection)
        {
            DeleteOldItems();
            CreateNewItems(serverCollection.servers);
        }

        void CreateNewItems(ServerJson[] servers)
        {
            foreach (ServerJson server in servers)
            {
                ServerListUIItem clone = Instantiate(itemPrefab, parent);
                clone.Setup(server);
                items.Add(clone);
            }
        }

        void DeleteOldItems()
        {
            foreach (ServerListUIItem item in items)
            {
                Destroy(item.gameObject);
            }

            items.Clear();
        }
    }
}
