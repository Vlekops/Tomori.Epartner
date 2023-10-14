using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.Result;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Helper;
using System.ComponentModel.DataAnnotations;
using Tomori.Epartner.Core.Identity.Role.Query;

namespace Tomori.Epartner.Core.Identity.User.Query
{
    public class GetUserRoleListRequest : IRequest<ListResponse<UserRoleResponse>>
    {
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public bool ShowAll { get; set; }
        public int? Start { get; set; }
        public int? Length { get; set; }
    }
    internal class GetUserRoleListHandler : IRequestHandler<GetUserRoleListRequest, ListResponse<UserRoleResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserRoleListHandler(
            ILogger<GetUserRoleListHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
			_mediator = mediator;
            _context = context;
        }

        public async Task<ListResponse<UserRoleResponse>> Handle(GetUserRoleListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<UserRoleResponse> result = new ListResponse<UserRoleResponse>();
            try
            {
                var roles = await _mediator.Send(new GetRoleListRequest());
                var data_list = await _context.Entity<Tomori.Epartner.Data.Model.UserRole>().Where(d => d.IdUser == request.IdUser).ToListAsync();
                result.List = new List<UserRoleResponse>();
                foreach (var role in roles.List)
                {
                    var obj = new UserRoleResponse()
                    {
                        IsActive = false,
                        CreateBy = "-",
                        CreateDate = null,
                        IdRole = role.Id,
                        RoleName = role.Name
                    };
                    var data = data_list.Where(d => d.IdRole == role.Id).FirstOrDefault();
                    if (data != null)
                    {
                        obj.IsActive = true;
                        obj.CreateDate = data.CreateDate;
                        obj.CreateBy = data.CreateBy;
                    }
                    result.List.Add(obj);
                }
                if (!request.ShowAll)
                    result.List.Where(d => d.IsActive).ToList();

                result.Count = result.List.Count();
                result.List = result.List.OrderBy(d => d.IsActive).ToList();

                if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
                    result.List = result.List.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value).ToList();

                result.Filtered = data_list.Count();
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List UserRole", request);
                result.Error("Failed Get List UserRole", ex.Message);
            }
            return result;
        }
    }
}

