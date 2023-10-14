//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Log.Command;
using Microsoft.EntityFrameworkCore;

namespace Tomori.Epartner.Core.Report.Command
{

    #region Request
    public class AddReportRoleMapping : Profile
    {
        public AddReportRoleMapping()
        {
            CreateMap<AddReportRoleRequest, ReportRoleRequest>().ReverseMap();
        }
    }
    public class AddReportRoleRequest : ReportRoleRequest, IMapRequest<Tomori.Epartner.Data.Model.ReportRole, AddReportRoleRequest>, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        public void Mapping(IMappingExpression<AddReportRoleRequest, Tomori.Epartner.Data.Model.ReportRole> map)
        {
        }
    }
    #endregion

    internal class AddReportRoleHandler : IRequestHandler<AddReportRoleRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddReportRoleHandler(
            ILogger<AddReportRoleHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(AddReportRoleRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Data.Model.ReportRole>().Where(d => d.IdReport == request.IdReport).ToListAsync();
                if (item != null && item.Count > 0)
                    _context.Delete(item);

                if (request.IdRoles.Count > 0)
                {
                    var add = request.IdRoles.Select(d => new Data.Model.ReportRole()
                    {
                        CreateBy = request.Token.Username,
                        CreateDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        IdReport = request.IdReport,
                        IdRole = d
                    }).ToList();

                    _context.Add(add);
                }

                var save = await _context.Commit();
                if (save.Success)
                {
                    _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save.log }));
                    result.OK();
                }
                else
                    result.BadRequest(save.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add ReportRole", request);
                result.Error("Failed Add ReportRole", ex.Message);
            }
            return result;
        }
    }
}
