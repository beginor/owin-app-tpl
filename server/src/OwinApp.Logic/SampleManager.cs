using System;
using System.Collections.Generic;
using System.Linq;
using Beginor.OwinApp.Data;
using Beginor.OwinApp.Model;

namespace Beginor.OwinApp.Logic {

    public class SampleManager {

        private SampleRepository repo = new SampleRepository();

        public SampleManager() {
        }

        public IList<SampleModel> GetAll() {
            throw new NotImplementedException();
            //return this.repo.GetAll().Select(info => new SampleModel {}).ToList();
        }

    }

}
