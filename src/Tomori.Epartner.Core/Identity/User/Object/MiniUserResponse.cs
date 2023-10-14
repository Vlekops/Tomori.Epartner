using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tomori.Epartner.Data.Model;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.Response
{
    public partial class MiniUserResponse: IMapResponse<MiniUserResponse, Data.Model.User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }

        public void Mapping(IMappingExpression<Data.Model.User, MiniUserResponse> map)
        {
        }
    }
}

