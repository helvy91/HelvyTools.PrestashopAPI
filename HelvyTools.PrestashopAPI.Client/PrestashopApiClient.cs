using System.Web;
using System.Text;
using System.Xml.Linq;
using HelvyTools.Utils.Xml;
using System.Net.Http.Headers;
using HelvyTools.Utils.Attributes;
using HelvyTools.Prestashop.Api.Data;
using HelvyTools.Prestashop.Api.Attributes;

namespace HelvyTools.PrestashopAPI.Client
{
    public class PrestashopApiClient
    {
        private readonly string _apiUrl;
        private readonly Http.HttpClient _httpClient;

        public PrestashopApiClient(string apiUrl, string apiKey)
        {
            _apiUrl = apiUrl;

            var netClient = new HttpClient();
            netClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:")));
            _httpClient = new Http.HttpClient(netClient);
        }

        public async Task<TResource> GetAsync<TResource>(int id)
            where TResource : PrestashopResource
        {
            var url = GetResourceUrl<TResource>() + "/" + id;
            var xml = await _httpClient.GetAsync<string>(url);
            var resourceXml = GetResourceNode(xml);
            return GetResource<TResource>(resourceXml);
        }

        public async Task<List<TResource>> GetAsync<TResource>(string field, string value)
            where TResource : PrestashopResource
        {
            var xml = await _httpClient.GetAsync<string>(GetResourceUrl<TResource>() + $"?filter[{field}]=[{HttpUtility.UrlEncode(value)}]");

            var results = new List<TResource>();
            if (TryGetFilterResourceIds<TResource>(xml, out var ids))
            {
                foreach (var id in ids)
                {
                    var result = await GetAsync<TResource>(id);
                    results.Add(result);
                }
            }

            return results;
        }

        public async Task<TResource> AddAsync<TResource>(TResource resource)
            where TResource : PrestashopResource
        {
            var xml = XmlUtils.Serialize(resource);

            xml = AddPrestashopRootNode(xml);
            var content = new StringContent(xml, Encoding.UTF8);
            var responseXml = await _httpClient.PostAsync<string>(GetResourceUrl<TResource>(), content);
            var productNode = GetResourceNode(responseXml);
            return GetResource<TResource>(productNode);
        }

        public async Task DeleteAsync<TResource>(int id)
            where TResource : PrestashopResource
        {
            await _httpClient.DeleteAsync(GetResourceUrl<TResource>() + "/" + id);
        }

        public async Task DeleteImageAsync<TResource>(int resourceId, int imageId)
            where TResource : PrestashopResource
        {
            await _httpClient.DeleteAsync($"{GetBaseUrl()}images/{GetResourceName<TResource>()}/{resourceId}/{imageId}");
        }

        public async Task<Image> UploadPoductImageAsync(int id, byte[] imageBytes, string imageName)
        {
            var byteContent = new ByteArrayContent(imageBytes);
            byteContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

            var form = new MultipartFormDataContent();
            form.Add(byteContent, "image", imageName);

            var responseXml = await _httpClient.PostAsync<string>($"{GetBaseUrl()}images/products/{id}", form);
            var imageNode = GetResourceNode(responseXml);
            return GetResource<Image>(imageNode);
        }

        public async Task UpdateAsync<TResource>(TResource value)
            where TResource : PrestashopResource
        {
            var xml = XmlUtils.Serialize(value);

            xml = AddPrestashopRootNode(xml);
            var content = new StringContent(xml, Encoding.UTF8);
            await _httpClient.PutAsync<string>(GetResourceUrl<TResource>(), content);
        }

        private string AddPrestashopRootNode(string xml)
        {
            var xdoc = XDocument.Parse(xml);
            var rootXDoc = new XDocument(new XElement("prestashop", xdoc.Root));

            return rootXDoc.ToString();
        }

        private bool TryGetFilterResourceIds<TResource>(string xml, out List<int> results)
            where TResource : PrestashopResource
        {
            results = new List<int>();

            var xdoc = XDocument.Parse(xml);
            var resourceSingleName = AttributeReader.ReadClassName<ApiResourceName, TResource>();
            var resourceElements = xdoc.Descendants(XName.Get(resourceSingleName.Remove(resourceSingleName.Length - 1, 1))).ToList();
            if (resourceElements.Count >= 1)
            {
                foreach (var element in resourceElements)
                {
                    var id = element.Attribute(XName.Get("id")).Value;
                    results.Add(int.Parse(id));
                }

                return true;
            }

            return false;
        }

        private string GetResourceNode(string xml)
        {
            var xdoc = XDocument.Parse(xml);
            var resourceNode = xdoc.Root.Nodes().First();
            return resourceNode.ToString();
        }

        private TResource GetResource<TResource>(string xml)
            where TResource: PrestashopResource
            => XmlUtils.Deserialize<TResource>(xml);
        private string GetResourceName<TResource>()
            => AttributeReader.ReadClassName<ApiResourceName, TResource>();
        private string GetBaseUrl()
            => _apiUrl;
        private string GetResourceUrl<T>()
            => $"{GetBaseUrl()}{GetResourceName<T>()}";
    }
}
