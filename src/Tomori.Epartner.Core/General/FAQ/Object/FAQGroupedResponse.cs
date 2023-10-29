using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomori.Epartner.Core.Response
{
    public class FAQGroupedResponse
    {
        public string Section { get; set; }
        public List<FaqSectionValue> SectionValues { get; set; }
    }

    public class FaqSectionValue
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
