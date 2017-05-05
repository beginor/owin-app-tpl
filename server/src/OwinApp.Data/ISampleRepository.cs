using System.Collections.Generic;

namespace Beginor.OwinApp.Data {
    
    public interface ISampleRepository {

        IList<SampleEntity> GetAll();

    }
}
