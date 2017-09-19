using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UWPReactiveUI.Services.Interfaces;
using UWPReactiveUI.Services.Models;

namespace UWPReactiveUI.Services.Impl
{
    public class HipsterService : IHipsterService
    {
        public async Task<HipsterSentence> GetSentenceAsync(int paragraphs = 4, HipsterType type = HipsterType.Centric, bool useHtml = false)
        {
            try
            {
                // To be able to see the effects (for the demo)
                await Task.Delay(TimeSpan.FromSeconds(3));

                using (HttpClient client = new HttpClient())
                {
                    var typeAsParameter = type == HipsterType.Latin ? "hipster-latin": "hipster -centric";
                    var uri = string.Format("http://hipsterjesus.com/api/?paras={0}&type={1}&html={2}", paragraphs, typeAsParameter, useHtml);
                    var responseMessage = await client.GetAsync(uri);

                    responseMessage.EnsureSuccessStatusCode();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsStringAsync();                            
                        var result = await Task.Run(() => JsonConvert.DeserializeObject<HipsterSentence>(response));
                        return result;

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
