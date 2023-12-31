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

namespace Tomori.Epartner.Core.Response
{
    public partial class PagePermissionResponse: IMapResponse<PagePermissionResponse, Tomori.Epartner.Data.Model.PagePermission>
    {
		public Guid Id{ get; set; }
		public string Name{ get; set; }
        public bool Active { get; set; }
        public PageResponse Page { get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.PagePermission, PagePermissionResponse> map)
        {
            //use this for mapping
            map.ForMember(d => d.Page, opt => opt.MapFrom(s => s.IdPageNavigation));

        }
    }
}

