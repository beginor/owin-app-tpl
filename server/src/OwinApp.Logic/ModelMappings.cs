using System;
using AutoMapper;
using Castle.Core;
using NHibernate.AspNet.Identity;
using Beginor.OwinApp.Model;
using Beginor.OwinApp.Data;

namespace Beginor.OwinApp.Logic {

    public class ModelMappings : IStartable {

        private static bool mapperInitialized;
        
        public void Start() {
            if (mapperInitialized) {
                return;
            }
            Mapper.Initialize(cfg => {
                cfg.CreateMap<IdentityUser, ApplicationUserModel>();
                cfg.CreateMap<IdentityRole, ApplicationRoleModel>();
                cfg.CreateMap<SampleEntity, SampleModel>();
                cfg.CreateMap<SampleModel, SampleEntity>();
            });
            mapperInitialized = true;
        }

        public void Stop() {
            throw new NotImplementedException();
        }
    }

}
