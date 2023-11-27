using System.Security.Cryptography;
using LunaApiVultr;
using LunaApiVultr.Models.OperatingSystem;
using LunaApiVultr.Models.Scripts;
using LunaApiVultr.Models.Shared;

namespace VultrApi;
class Program
{
    static async Task Main()
    {
        string vultrApiKey = "";

        // Create an instance of HttpClient with default headers
        var httpClient = new HttpClient();

        // Create an instance of VultrApiClient, passing the HttpClient
        // Create an instance of VultrApiClient, passing the HttpClient
        using (VultrApiClient vultrApiClient = new VultrApiClient(vultrApiKey, httpClient))
        {
            // Console.WriteLine("[SCRIPTS]");
            // List<StartupScript> scripts = await Vultr.GetStartupScriptsAsync(vultrApiClient);
            // foreach (var i in scripts)
            // {
            //     Console.WriteLine(i.Name);
            // }
            // Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

            // Console.WriteLine("[REGIONS]");
            // List<Region> regions = await Vultr.GetRegionsAsync(vultrApiClient);
            // regions = regions.OrderBy(region => region.Country).ToList();
            // foreach (var i in regions)
            // {
            //     Console.WriteLine(i.Id);
            //     Console.WriteLine(i.City);
            //     Console.WriteLine(i.Country);
            // }
            // Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

            // Console.WriteLine("[COUNTRIES]");
            // List<string> countries = await Vultr.GetCountriesAsync(vultrApiClient);
            // foreach (var c in countries)
            // {
            //     Console.WriteLine(c);
            // }
            // Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

            // Console.WriteLine("[OSes]");
            // List<O> osList = await Vultr.GetAvilableOsAsync(vultrApiClient);
            // foreach (var o in osList)
            // {
            //     Console.WriteLine(o.Name);
            // }
            // Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

            // create an instance
            List<string> tags = new() { "f900054a-ca11-4eb5-bb6a-083379566695" };
            await Vultr.CreateNewInstanceAsync(vultrApiClient, serverTags: tags);

            // // delete an instance
            // List<string> ids = new() {
            //     "27bba940-49bc-4a8e-9936-61af13bac93a",
            //     "b612406f-3b39-40eb-8da4-233d1fe042c5",
            //     "061c0f70-21b1-4dd8-a6e0-83f1cdeba1a7",
            //     "0412d113-cffb-44a6-9a33-4c64044c27ca" };
            // foreach (var i in ids)
            // {
            //     await Vultr.DeleteInstanceAsync(vultrApiClient, instanceId: i);
            // }
        }
    }
}

//curl "https://api.vultr.com/v2/plans" -X GET -H "Authorization: Bearer HOVQFXIP4I3PASZBZ3PMX256OC5EKSNP5URQ"