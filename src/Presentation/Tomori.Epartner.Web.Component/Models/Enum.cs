namespace Tomori.Epartner.Web.Component.Models
{
    public enum ConfigCategory
    {
        SETTING,
        COMPANY,
        EMAIL,
        INTEGRATION
    }

    public enum RepositoryModul
    {
        ParticipantBeneficiary
    }

    public enum PermissionEnum
    {
        VIEW,
        ADD,
        EDIT,
        DELETE
    }
    public enum PageActionType
    {
        Index,
        Add,
        Edit,
        Detail
    }


    public enum StatusApproval
    {
        // Register
        None,
        Draft,
        ProcessApproval,
        Rejected,
        Active,
        NotActive,
        // Edit
        ProcessApprovalEdit,
        ActiveEdit,
        // TransferMember
        Approved,
    }

}
