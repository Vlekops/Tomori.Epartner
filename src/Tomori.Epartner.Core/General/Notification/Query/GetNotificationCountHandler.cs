﻿using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vleko.DAL.Interface;

namespace Tomori.Epartner.Core.Notification.Query
{
    public class GetNotificationCountRequest : IRequest<ObjectResponse<int>>
    {
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public bool IsOpen { get; set; }
    }

    internal class GetNotificationCountHandler : IRequestHandler<GetNotificationCountRequest, ObjectResponse<int>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetNotificationCountHandler(ILogger<GetNotificationCountHandler> logger, IUnitOfWork<ApplicationDBContext> context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ObjectResponse<int>> Handle(GetNotificationCountRequest request, CancellationToken cancellationToken)
        {
            var result = new ObjectResponse<int>();
            try
            {
                var data = await _context.Entity<Tomori.Epartner.Data.Model.Notification>().Where(d => d.IdUser == request.IdUser && d.IsOpen == request.IsOpen).CountAsync();
                result.Data = data;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Count Notification", request);
                result.Error("Failed Get Count Notification", ex.Message);
            }
            return result;
        }
    }
}
