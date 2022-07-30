using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    // As the Json result has 2 objects, I created 2 classes(success,contents)
    public class LeetSpeakTranslator //as a view-model
    {
        public Success success { get; set; }
        public Contents contents { get; set; }

    }
    public class Success
    {
        public int total { get; set; }

    }
    public class Contents
    {
        public int Id { get; set; }
        public string text { get; set; }
        public string translated { get; set; }
        //IsActive: to Delete a record from client side by making it false, but it will remain in database
        public bool IsActive { get; set; } = true;
    }
}
