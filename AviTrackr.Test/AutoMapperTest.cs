using System.Reflection;
using AutoMapper;
using AviTrackr.Domain.Base.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AviTrackr.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestMethod]
        public void automapper_mappings_valid()
        {
            Mapper.Initialize(i => i.AddProfiles(typeof(BaseEntity).GetTypeInfo().Assembly));
            Mapper.AssertConfigurationIsValid();
        }
    }
}
