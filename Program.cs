using LunaApiVultr;
using LunaApiVultr.Models.Scripts;

namespace VultrApi;
class Program
{
    static async Task Main()
    {
        string variableName = "VULTR_API_KEY";
        string vultrApiKey = string.Empty;

        // try to get the value of the environment variable.
        string? variableValue = Environment.GetEnvironmentVariable(variableName);

        if (variableValue == null)
        {
            Console.WriteLine($"The value of {variableName} is not set.");

        }
        else if (!string.IsNullOrEmpty(vultrApiKey))
        {
            vultrApiKey = variableValue;
        }
        else
        {
            Console.WriteLine("There is no API key set with env or in code");
            Environment.Exit(1);
        }
        
        // Create an instance of HttpClient with default headers
        var httpClient = new HttpClient();

        // Create an instance of VultrApiClient, passing the HttpClient
        using (VultrApiClient vultrApiClient = new VultrApiClient(vultrApiKey, httpClient))
        {
            Console.WriteLine("[SCRIPTS]");
            List<StartupScript> scripts = await Vultr.GetStartupScriptsAsync(vultrApiClient);
            foreach (var i in scripts)
            {
                Console.WriteLine(i.Name);
                Console.WriteLine(i.Id);
            }
            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=");

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

            // // create an instance
            // List<string> tags = new() { "f900054a-ca12-4eb5-bb6a-083379566695" };
            // await Vultr.CreateNewInstanceAsync(vultrApiClient, serverTags: tags, scriptId: "8e443ea6-e120-4e7d-9e8a-bb475f9ddc2f");

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

            // // get instance data
            // Instance instance = await Vultr.GetInstanceDetails(vultrApiClient, instanceId: "73be7cb2-8c02-4af8-908d-ef85a0da4c6d");
            // Console.WriteLine($"os:       {instance.Os}");
            // Console.WriteLine($"ipv4:     {instance.MainIp}");
            // Console.WriteLine($"ipv6:     {instance.V6MainIp}");
            // Console.WriteLine($"created:  {instance.DateCreated}");
        }
    }
}
