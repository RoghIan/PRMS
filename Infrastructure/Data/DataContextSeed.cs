using Core.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContextSeed
    {
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Groups.Any())
                {
                    var groupData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/GroupSeed.json");
                    var groups = JsonConvert.DeserializeObject<List<Group>>(groupData);

                    foreach (var group in groups) await context.Groups.AddAsync(@group);

                    await context.SaveChangesAsync();
                }
                
                if (!context.Appointed.Any())
                {
                    var titlesData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/AppointedSeed.json");
                
                    var titles = JsonConvert.DeserializeObject<List<Appointed>>(titlesData);
                
                    foreach (var title in titles) await context.Appointed.AddAsync(title);
                
                    await context.SaveChangesAsync();
                }


                if (!context.Publishers.Any())
                {
                    var publishersData = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/PublisherSeed.json");

                    var publishers = JsonConvert.DeserializeObject<List<Publisher>>(publishersData);

                    foreach (var publisher in publishers) await context.Publishers.AddAsync(publisher);

                    await context.SaveChangesAsync();
                }

                if (!context.AppointedPublishers.Any())
                {
                    var publisherTitleData =
                        await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/AppointedPublisherSeed.json");
                
                    var publishersTitles = JsonConvert.DeserializeObject<List<AppointedPublisher>>(publisherTitleData);
                
                    foreach (var publisherTitle in publishersTitles)
                        await context.AppointedPublishers.AddAsync(publisherTitle);
                
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(e.Message);
            }
        }
    }
}