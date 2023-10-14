using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Helper;
using System.Linq.Expressions;

namespace Tomori.Epartner.Core.Identity.User.Query
{
    public class GetUserListRequest : ListRequest,IListRequest<GetUserListRequest>,IRequest<ListResponse<UserResponse>>
    {
    }
    internal class GetUserListHandler : IRequestHandler<GetUserListRequest, ListResponse<UserResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserListHandler(
            ILogger<GetUserListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<UserResponse>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<UserResponse> result = new ListResponse<UserResponse>();
            try
            {
				var query = _context.Entity<Data.Model.User>().AsQueryable();

				#region Filter
				Expression<Func<Data.Model.User, object>> column_sort = null;
				List<Expression<Func<Data.Model.User, bool>>> where = new List<Expression<Func<Data.Model.User, bool>>>();
				if (request.Filter != null && request.Filter.Count > 0)
				{
					foreach (var f in request.Filter)
					{
						var obj = ListExpression(f.Search, f.Field, true);
						if (obj.where != null)
							where.Add(obj.where);
					}
				}
				if (where != null && where.Count() > 0)
				{
					foreach (var w in where)
					{
						query = query.Where(w);
					}
				}
				if (request.Sort != null)
                {
					column_sort = ListExpression(request.Sort.Field, request.Sort.Field, false).order!;
					if(column_sort != null)
						query = request.Sort.Type == SortTypeEnum.ASC ? query.OrderBy(column_sort) : query.OrderByDescending(column_sort);
					else
						query = query.OrderBy(d=>d.Id);
				}
				#endregion

				var query_count = query;
				if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
					query = query.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value);
				var data_list = await query.ToListAsync();

				result.List = _mapper.Map<List<UserResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List User", request);
                result.Error("Failed Get List User", ex.Message);
            }
            return result;
        }

        #region List Utility
        private (Expression<Func<Tomori.Epartner.Data.Model.User, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.User, object>> order) ListExpression(string search, string field, bool is_where)
        {
            Expression<Func<Tomori.Epartner.Data.Model.User, object>> result_order = null;
            Expression<Func<Tomori.Epartner.Data.Model.User, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
                    case "id":
                        if (is_where)
                        {
                            if (Guid.TryParse(search, out var _Id))
                                result_where = (d => d.Id == _Id);
                            else
                                result_where = (d => d.Id == Guid.Empty);
                        }
                        else
                            result_order = (d => d.Id);
                        break;
                    case "active":
                        if (is_where)
                        {
                            if (bool.TryParse(search, out var _Active))
                                result_where = (d => d.Active == _Active);
                        }
                        else
                            result_order = (d => d.Active);
                        break;
                    case "createdate":
                        if (is_where)
                        {
                            if (DateTime.TryParse(search, out var _CreateDate))
                                result_where = (d => d.CreateDate == _CreateDate);
                        }
                        else
                            result_order = (d => d.CreateDate);
                        break;
                    case "fullname":
                        if (is_where)
                        {
                            result_where = (d => d.Fullname.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.Fullname);
                        break;
                    case "islockout":
                        if (is_where)
                        {
                            if (bool.TryParse(search, out var _IsLockout))
                                result_where = (d => d.IsLockout == _IsLockout);
                        }
                        else
                            result_order = (d => d.IsLockout);
                        break;
                    case "mail":
                        if (is_where)
                        {
                            result_where = (d => d.Mail.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.Mail);
                        break;
                    case "phonenumber":
                        if (is_where)
                        {
                            result_where = (d => d.PhoneNumber.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.PhoneNumber);
                        break;
                    case "photourl":
                        if (is_where)
                        {
                            result_where = (d => d.PhotoUrl.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.PhotoUrl);
                        break;
                    case "username":
                        if (is_where)
                        {
                            result_where = (d => d.Username.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.Username);
                        break;
                    case "searchterm":
                        if (is_where)
                        {
                            result_where = (d =>
                                                d.Username.Trim().ToLower().Contains(search) ||
                                                d.Fullname.Trim().ToLower().Contains(search) ||
                                                d.PhoneNumber.Trim().ToLower().Contains(search) ||
                                                d.Mail.Trim().ToLower().Contains(search));
                        }
                        break;
                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

