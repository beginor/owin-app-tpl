using System.Collections.Generic;
using Beginor.AppFx.Core;
using NHibernate;
using Beginor.AppFx.Repository.Hibernate;

namespace Beginor.OwinApp.Data {

    public class SampleRepository
        : HibernateRepository<SampleEntity, int>, ISampleRepository {

        public SampleRepository(ISessionFactory factory) : base(factory) { }

    }

}
