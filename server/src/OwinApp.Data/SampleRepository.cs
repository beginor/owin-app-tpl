using System.Collections.Generic;
using Beginor.AppFx.Core;
using NHibernate;

namespace Beginor.OwinApp.Data {

    public class SampleRepository : Disposable, ISampleRepository {

        private ISessionFactory factory;

        public SampleRepository(ISessionFactory factory) {
            this.factory = factory;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                this.factory = null;
            }
            base.Dispose(disposing);
        }

        public IList<SampleEntity> GetAll() {
            return new List<SampleEntity>();
        }

    }

}
