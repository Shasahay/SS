using AutoMapper;
using SS.StudentStore.Services.API.Extensions;
using SS.StudentStore.Services.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SS.StudentStore.Services.API
{
    public class AutoMapperConfiguration
    {
        public IMapper Configure()
        {
            var profiles = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(a => typeof(DataMapperProfile).IsAssignableFrom(a));

            // Initialize AutoMapper with each instance of profiles found

            var mapperConfiguration = new MapperConfiguration(m => profiles.ForEach(m.AddProfile));
            return mapperConfiguration.CreateMapper();

        }
    }
}
