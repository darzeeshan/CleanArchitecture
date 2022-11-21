using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace Cone.InventoryManagement.Settings.Access
{
    public static class JsonSettingsFile
    {
        private static string jsonFile;

        public static void GetSettingsPath()
        {
            //A environment variable is defined in Windows > Systems > Advanced > Environment > 
            //Physical path to settings project is defined.
            jsonFile = Environment.GetEnvironmentVariable("Cone.InventoryManagement.Settings");
        }

        public static void ReadJsonFile(string additionalPath)
        {
            GetSettingsPath();

            jsonFile = jsonFile + additionalPath;
        }

        //public static void GetAppPhysicalPath()
        //{
        //    string applicationPath = System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //    int indexCount = applicationPath.IndexOf("\\Cone.InventoryManagement.");

        //    jsonFile = applicationPath.Substring(0, indexCount) + @"\\Cone.InventoryManagement.Settings";
        //}

        //public static void GetAppPhysicalPath(string additionalPath)
        //{
        //    string applicationPath = System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //    int indexCount = applicationPath.IndexOf("\\Cone.InventoryManagement.");

        //    jsonFile = applicationPath.Substring(0, indexCount) + "\\Cone.InventoryManagement.Settings"+ additionalPath;
        //}

        public static string GetParentNodeValue(string node1)
        {
            JsonNode jsonStream = JsonNode.Parse(File.ReadAllText(jsonFile));
            JsonNode parentNode = jsonStream[node1];

            return parentNode.ToString();
        }

        public static string GetParentNodeValue(string node1, string node2)
        {
            JsonNode jsonStream = JsonNode.Parse(File.ReadAllText(jsonFile));
            JsonNode parentNode = jsonStream[node1][node2];

            return parentNode.ToString();
        }

        public static string GetParentNodeValue(string node1, string node2, string node3)
        {
            JsonNode jsonStream = JsonNode.Parse(File.ReadAllText(jsonFile));
            JsonNode parentNode = jsonStream[node1][node2][node3];

            return parentNode.ToString();
        }

        public static IDictionary<string, string> GetKeyPairNodeValue(string node1)
        {
            JsonNode jsonStream = JsonNode.Parse(File.ReadAllText(jsonFile));
            JsonNode parentNode = jsonStream[node1];

            IDictionary<string, string> keyValuePair = new Dictionary<string, string>();

            foreach (var item in parentNode.AsObject())
            {
                keyValuePair.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
            }

            return keyValuePair;
        }

        public static IDictionary<string, string> GetKeyPairNodeValue(string node1, string node2)
        {
            JsonNode jsonStream = JsonNode.Parse(File.ReadAllText(jsonFile));
            JsonNode parentNode = jsonStream[node1][node2];

            IDictionary<string, string> keyValuePair = new Dictionary<string, string>();

            foreach (var item in parentNode.AsObject())
            {
                keyValuePair.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
            }

            return keyValuePair;
        }

        public static IDictionary<string, string> GetKeyPairNodeValue(string node1, string node2, string node3)
        {
            JsonNode jsonStream = JsonNode.Parse(File.ReadAllText(jsonFile));
            JsonNode parentNode = jsonStream[node1][node2][node3];

            IDictionary<string, string> keyValuePair = new Dictionary<string, string>();

            foreach (var item in parentNode.AsObject())
            {
                keyValuePair.Add(new KeyValuePair<string, string>(item.Key, item.Value.ToString()));
            }

            return keyValuePair;
        }
    }
}
