using System;
using AutoMapper;
using Castle.Core;
using NHibernate.AspNet.Identity;
using Beginor.OwinApp.Model;
using Beginor.OwinApp.Data;

namespace Beginor.OwinApp.Logic {

    public class ModelMappings : IStartable {
        
        public void Start() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<IdentityUser, ApplicationUserModel>();
                cfg.CreateMap<IdentityRole, ApplicationRoleModel>();
                cfg.CreateMap<SampleEntity, SampleModel>();
                cfg.CreateMap<SampleModel, SampleEntity>();
            });
        }

        public void Stop() {
            throw new NotImplementedException();
        }
    }

}
