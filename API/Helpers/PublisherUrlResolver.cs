using API.DTO;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class PublisherUrlResolver : IValueResolver<Publisher, PublisherToReturnDto, string>,
        IValueResolver<Publisher, FlatPublisherToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public PublisherUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Publisher source, PublisherToReturnDto destination, string destMember,
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PhotoUrl)) return _config["ApiUrl"] + source.PhotoUrl;

            return null;
        }

        public string Resolve(Publisher source, FlatPublisherToReturnDto destination, string destMember,
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PhotoUrl)) return _config["ApiUrl"] + source.PhotoUrl;

            return null;
        }
    }
}