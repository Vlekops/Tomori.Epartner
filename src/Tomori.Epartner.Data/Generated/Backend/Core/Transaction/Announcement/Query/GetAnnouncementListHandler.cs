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

namespace Tomori.Epartner.Core.Announcement.Query
{
    public class GetAnnouncementListRequest : ListRequest,IListRequest<GetAnnouncementListRequest>,IRequest<ListResponse<AnnouncementResponse>>
    {
    }
    internal class GetAnnouncementListHandler : IRequestHandler<GetAnnouncementListRequest, ListResponse<AnnouncementResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetAnnouncementListHandler(
            ILogger<GetAnnouncementListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<AnnouncementResponse>> Handle(GetAnnouncementListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<AnnouncementResponse> result = new ListResponse<AnnouncementResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.TrsAnnouncement>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, bool>>>();
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

				result.List = _mapper.Map<List<AnnouncementResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List Announcement", request);
                result.Error("Failed Get List Announcement", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.TrsAnnouncement, bool>> result_where = null;
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
					case "announcementcategory" : 
						if(is_where){
							result_where = (d=>d.AnnouncementCategory.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.AnnouncementCategory);
					break;
					case "announcementtype" : 
						if(is_where){
							result_where = (d=>d.AnnouncementType.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.AnnouncementType);
					break;
					case "attachment" : 
						if(is_where){
							result_where = (d=>d.Attachment.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Attachment);
					break;
					case "bidangusaha" : 
						if(is_where){
							result_where = (d=>d.BidangUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BidangUsaha);
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
					case "enddate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _EndDate))
								result_where = (d=>d.EndDate == _EndDate);
						}
						else
							result_order = (d => d.EndDate);
					break;
					case "golonganusaha" : 
						if(is_where){
							result_where = (d=>d.GolonganUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.GolonganUsaha);
					break;
					case "k3sid" : 
						if(is_where){
							if (int.TryParse(search, out var _K3sId))
								result_where = (d=>d.K3sId == _K3sId);
						}
						else
							result_order = (d => d.K3sId);
					break;
					case "k3sname" : 
						if(is_where){
							result_where = (d=>d.K3sName.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.K3sName);
					break;
					case "publishdate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _PublishDate))
								result_where = (d=>d.PublishDate == _PublishDate);
						}
						else
							result_order = (d => d.PublishDate);
					break;
					case "tendertype" : 
						if(is_where){
							result_where = (d=>d.TenderType.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.TenderType);
					break;
					case "title" : 
						if(is_where){
							result_where = (d=>d.Title.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Title);
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

