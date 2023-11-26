using LunaApiVultr;
using LunaApiVultr.Models.Shared;


class Program
{
    static async Task Main()
    {
        string apiKey = "";

        List<Region> regions = await Vultr.GetRegionsAsync(apiKey);

        regions = regions.OrderBy(region => region.Country).ToList();

        foreach (var i in regions)
        {
            Console.WriteLine(i.Id);
            Console.WriteLine(i.City);
            Console.WriteLine(i.Country);
        }

        Console.WriteLine("------------");

        List<string> countries = await Vultr.GetCountriesAsync(apiKey);
        foreach (var t in countries)
        {
            Console.WriteLine(t);
        }

        LunaApiVultr.Models.PlansAvailable? plans = await Vultr.GetAvailablePlansByRegionAsync(apiKey, "mel", "vc2");
        foreach (var i in plans.AvailablePlans!)
        {
            Console.WriteLine(i);
        }

        var oSes = await Vultr.GetAvilableOsAsync(apiKey);
        foreach (var o in oSes)
        {
            Console.WriteLine(o.Id);
            Console.WriteLine(o.Name);
            Console.WriteLine(o.Family);
        }
    }
}

