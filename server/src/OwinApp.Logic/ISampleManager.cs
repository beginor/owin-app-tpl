using System.Collections.Generic;
using Beginor.OwinApp.Model;

namespace Beginor.OwinApp.Logic {

    public interface ISampleManager {

        IList<SampleModel> GetAll();

    }

}
