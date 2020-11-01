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
                    var groupData = File.ReadAllText("../Infrastructure/Data/SeedData/GroupSeed.json");
                    var groups = JsonConvert.DeserializeObject<List<Group>>(groupData);

                    foreach (var group in groups) await context.Groups.AddAsync(@group);

                    await context.SaveChangesAsync();
                }

                if (!context.Statuses.Any())
                {
                    var statusData = File.ReadAllText("../Infrastructure/Data/SeedData/StatusSeed.json");

                    var statuses = JsonConvert.DeserializeObject<List<Status>>(statusData);

                    foreach (var status in statuses) await context.Statuses.AddAsync(status);

                    await context.SaveChangesAsync();
                }

                if (!context.Titles.Any())
                {
                    var titlesData = File.ReadAllText("../Infrastructure/Data/SeedData/TitleSeed.json");

                    var titles = JsonConvert.DeserializeObject<List<Title>>(titlesData);

                    foreach (var title in titles) await context.Titles.AddAsync(title);

                    await context.SaveChangesAsync();
                }


                if (!context.Publishers.Any())
                {
                    var publishersData = File.ReadAllText("../Infrastructure/Data/SeedData/PublisherSeed.json");

                    var publishers = JsonConvert.DeserializeObject<List<Publisher>>(publishersData);

                    foreach (var publisher in publishers) await context.Publishers.AddAsync(publisher);

                    await context.SaveChangesAsync();
                }

                if (!context.PublisherTitles.Any())
                {
                    var publisherTitleData =
                        File.ReadAllText("../Infrastructure/Data/SeedData/PublisherTitleSeed.json");

                    var publishersTitles = JsonConvert.DeserializeObject<List<PublisherTitle>>(publisherTitleData);

                    foreach (var publisherTitle in publishersTitles)
                        await context.PublisherTitles.AddAsync(publisherTitle);

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