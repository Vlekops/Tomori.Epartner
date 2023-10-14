using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomori.Epartner.Core.Attributes
{
    public class CacheKey
    {
        #region Identity
        public const string PAGE = "page";
        public const string ROLE = "role";
        public const string ROLE_PERMISSION = "role_permission";
        public const string PAGE_PERMISSION = "page_permission";
        public const string USER_PERMISSION = "user_permission";
        public const string USER_ROLE= "user_role";
        public const string USER_ROLE_PERMISSION = "user_role_permission";
        #endregion

        #region General
        public const string CONFIG = "config";
        public const string REPOSITORY = "repository";
        public const string PDF_TEMPLATE = "pdf_template";
        public const string CHANGE_CONFIG = "change_config";
        public const string DOCUMENT_TEMPLATE = "document_template";
        public const string COUNTER_TRANSACTION = "counter_transaction";
        
        #endregion

        #region Master
        public const string MASTER_DATA = "master_data";
        public const string MASTER_CATEGORY = "master_category";
        public const string BANK = "bank";
        public const string REGION_PROVINCE = "region_province";
        public const string REGION_DISTRICT = "region_district";
        public const string REGION_CITY = "region_city";
        public const string REGION_VILLAGE = "region_village";
        #endregion
    }
}
