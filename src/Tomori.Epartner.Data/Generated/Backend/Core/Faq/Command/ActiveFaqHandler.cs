//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.Faq.Command
{

    #region Request
    public class ActiveFaqRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Inputer { get; set; }
    }
    #endregion

    internal class ActiveFaqHandler : IRequestHandler<ActiveFaqRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public ActiveFaqHandler(
            ILogger<ActiveFaqHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(ActiveFaqRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Faq>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    item.Active = request.Active;
                    item.UpdateBy = request.Inputer;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);
                    return result;
                }
                else
                    result.NotFound($"Id Faq {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Active Faq", request);
                result.Error("Failed Active Faq", ex.Message);
            }
            return result;
        }
    }
}

