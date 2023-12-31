//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Tomori.Epartner.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tomori.Epartner.Data.Model;
using Vleko.Result;

namespace Tomori.Epartner.Core.Response
{
    public partial class PageResponse: IMapResponse<PageResponse, Tomori.Epartner.Data.Model.Page>
    {
		public Guid Id{ get; set; }
        public Guid? IdParent { get; set; }
        public string Section { get; set; }
        public string Code{ get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
		public string Icon{ get; set; }
		public string Navigation{ get; set; }
        public int Sort{ get; set; }
        public bool Active { get; set; }
        public List<string> Permission { get; set; }
        public List<PageResponse> Childs { get; set; } = new List<PageResponse>();

        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.Page, PageResponse> map)
        {
            //use this for mapping
            map.ForMember(d => d.Childs, opt => opt.MapFrom(s => s.InverseIdParentNavigation != null && s.InverseIdParentNavigation.Count() > 0 ? s.InverseIdParentNavigation : null));
        }
    }
}

