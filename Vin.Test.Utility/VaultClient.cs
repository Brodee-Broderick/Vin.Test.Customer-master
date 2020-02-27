using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Vin.Test.Utility
{
    public class VaultClient
    {
        private readonly string _vaultUsername;
        private readonly string _vaultPassword;

        public VaultClient()
        {
            _vaultUsername = Environment.GetEnvironmentVariable("vaultUser");
            _vaultPassword = Environment.GetEnvironmentVariable("vaultPass");
        }

        public string GetSecret(string path)
        {
            var vaultAuthRequest = new VaultAuthRequest { password = _vaultPassword };

            var vaultClient = new HttpClient();

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(vaultAuthRequest), Encoding.UTF8, "application/json");

            var response = vaultClient.PostAsync($"https://vault.vindevops.cloud/v1/auth/userpass/login/{_vaultUsername}", postContent).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            VaultAuthResponse vaultResponse = JsonConvert.DeserializeObject<VaultAuthResponse>(jsonResponse);
            string vaultToken = vaultResponse.auth.client_token;

            vaultClient.DefaultRequestHeaders.Add("X-Vault-Token", vaultToken);
            HttpResponseMessage secretResponse = vaultClient.GetAsync("https://vault.vindevops.cloud/v1/secret/" + path).Result;
            string jsonSecretResponse = secretResponse.Content.ReadAsStringAsync().Result;

            VaultSecretResponse vaultSecretResponseObject = JsonConvert.DeserializeObject<VaultSecretResponse>(jsonSecretResponse);
            Data vaultData = vaultSecretResponseObject.data;

            return vaultData.value;
        }

        public class VaultAuthRequest
        {
            public string password { get; set; }
        }

        public class VaultAuthResponse
        {
            public string request_id { get; set; }
            public string lease_id { get; set; }
            public bool renewable { get; set; }
            public int lease_duration { get; set; }
            public object data { get; set; }
            public object wrap_info { get; set; }
            public object warnings { get; set; }
            public Auth auth { get; set; }
        }

        public class Auth
        {
            public string client_token { get; set; }
            public string accessor { get; set; }
            public string[] policies { get; set; }
            public Metadata metadata { get; set; }
            public int lease_duration { get; set; }
            public bool renewable { get; set; }
            public string entity_id { get; set; }
        }

        public class Metadata
        {
            public string username { get; set; }
        }

        public class VaultSecretResponse
        {
            public string request_id { get; set; }
            public string lease_id { get; set; }
            public bool renewable { get; set; }
            public int lease_duration { get; set; }
            public Data data { get; set; }
            public object wrap_info { get; set; }
            public object warnings { get; set; }
            public object auth { get; set; }
        }

        public class Data
        {
            public string value { get; set; }
        }
    }
}
