//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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

namespace Tomori.Epartner.Core.DocumentPayment.Query
{
    public class GetDocumentPaymentListRequest : ListRequest,IListRequest<GetDocumentPaymentListRequest>,IRequest<ListResponse<DocumentPaymentResponse>>
    {
    }
    internal class GetDocumentPaymentListHandler : IRequestHandler<GetDocumentPaymentListRequest, ListResponse<DocumentPaymentResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetDocumentPaymentListHandler(
            ILogger<GetDocumentPaymentListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<DocumentPaymentResponse>> Handle(GetDocumentPaymentListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<DocumentPaymentResponse> result = new ListResponse<DocumentPaymentResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.DocumentPayment>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, bool>>>();
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

				result.List = _mapper.Map<List<DocumentPaymentResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List DocumentPayment", request);
                result.Error("Failed Get List DocumentPayment", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.DocumentPayment, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "id" : 
						if(is_where){
							if (Guid.TryParse(search, out var _Id))
								result_where = (d=>d.Id == _Id);
								else
								result_where = (d=>d.Id == Guid.Empty);
						}
						else
							result_order = (d => d.Id);
					break;
					case "active" : 
						if(is_where){
							if (bool.TryParse(search, out var _Active))
								result_where = (d=>d.Active == _Active);
						}
						else
							result_order = (d => d.Active);
					break;
					case "code" : 
						if(is_where){
							result_where = (d=>d.Code.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Code);
					break;
					case "createby" : 
						if(is_where){
							result_where = (d=>d.CreateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.CreateBy);
					break;
					case "createdate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _CreateDate))
								result_where = (d=>d.CreateDate == _CreateDate);
						}
						else
							result_order = (d => d.CreateDate);
					break;
					case "description" : 
						if(is_where){
							result_where = (d=>d.Description.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Description);
					break;
					case "fileextension" : 
						if(is_where){
							result_where = (d=>d.FileExtension.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileExtension);
					break;
					case "filemaxsize" : 
						if(is_where){
							if (long.TryParse(search, out var _FileMaxSize))
								result_where = (d=>d.FileMaxSize == _FileMaxSize);
						}
						else
							result_order = (d => d.FileMaxSize);
					break;
					case "ismandatory" : 
						if(is_where){
							if (bool.TryParse(search, out var _IsMandatory))
								result_where = (d=>d.IsMandatory == _IsMandatory);
						}
						else
							result_order = (d => d.IsMandatory);
					break;
					case "mastervaluecode" : 
						if(is_where){
							result_where = (d=>d.MasterValueCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.MasterValueCode);
					break;
					case "mastervaluetext" : 
						if(is_where){
							result_where = (d=>d.MasterValueText.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.MasterValueText);
					break;
					case "programdana" : 
						if(is_where){
							result_where = (d=>d.ProgramDana.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.ProgramDana);
					break;
					case "sort" : 
						if(is_where){
							if (int.TryParse(search, out var _Sort))
								result_where = (d=>d.Sort == _Sort);
						}
						else
							result_order = (d => d.Sort);
					break;
					case "title" : 
						if(is_where){
							result_where = (d=>d.Title.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Title);
					break;
					case "type" : 
						if(is_where){
							result_where = (d=>d.Type.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Type);
					break;
					case "updateby" : 
						if(is_where){
							result_where = (d=>d.UpdateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.UpdateBy);
					break;
					case "updatedate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _UpdateDate))
								result_where = (d=>d.UpdateDate == _UpdateDate);
						}
						else
							result_order = (d => d.UpdateDate);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

