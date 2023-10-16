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

namespace Tomori.Epartner.Core.SusunanSaham.Query
{
    public class GetSusunanSahamListRequest : ListRequest,IListRequest<GetSusunanSahamListRequest>,IRequest<ListResponse<SusunanSahamResponse>>
    {
    }
    internal class GetSusunanSahamListHandler : IRequestHandler<GetSusunanSahamListRequest, ListResponse<SusunanSahamResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetSusunanSahamListHandler(
            ILogger<GetSusunanSahamListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<SusunanSahamResponse>> Handle(GetSusunanSahamListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<SusunanSahamResponse> result = new ListResponse<SusunanSahamResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.TrsSusunanSaham>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, bool>>>();
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

				result.List = _mapper.Map<List<SusunanSahamResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List SusunanSaham", request);
                result.Error("Failed Get List SusunanSaham", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.TrsSusunanSaham, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "id" : 
						if(is_where){
							if (int.TryParse(search, out var _Id))
								result_where = (d=>d.Id == _Id);
						}
						else
							result_order = (d => d.Id);
					break;
					case "badanusaha" : 
						if(is_where){
							result_where = (d=>d.BadanUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BadanUsaha);
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
					case "docnpwp" : 
						if(is_where){
							result_where = (d=>d.DocNpwp.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.DocNpwp);
					break;
					case "email" : 
						if(is_where){
							result_where = (d=>d.Email.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Email);
					break;
					case "jumlahsaham" : 
						if(is_where){
							if (decimal.TryParse(search, out var _JumlahSaham))
								result_where = (d=>d.JumlahSaham == _JumlahSaham);
						}
						else
							result_order = (d => d.JumlahSaham);
					break;
					case "nama" : 
						if(is_where){
							result_where = (d=>d.Nama.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Nama);
					break;
					case "noktpkitas" : 
						if(is_where){
							result_where = (d=>d.NoKtpKitas.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NoKtpKitas);
					break;
					case "perorangan" : 
						if(is_where){
							if (bool.TryParse(search, out var _Perorangan))
								result_where = (d=>d.Perorangan == _Perorangan);
						}
						else
							result_order = (d => d.Perorangan);
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
					case "vendorid" : 
						if(is_where){
							if (int.TryParse(search, out var _VendorId))
								result_where = (d=>d.VendorId == _VendorId);
						}
						else
							result_order = (d => d.VendorId);
					break;
					case "warganegara" : 
						if(is_where){
							result_where = (d=>d.WargaNegara.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.WargaNegara);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

