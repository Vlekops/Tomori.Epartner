namespace Tomori.Epartner.Core.Attributes
{
    public enum RepositoryModul
    {
        ParticipantBeneficiary
    }
    public enum ConfigCategory
    {
        SETTING,
        COMPANY,
        EMAIL,
        INTEGRATION
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
    public enum WorkflowEnum
    {
        Process,
        Reject,
        Approved
    }
    public enum WorkflowStatusEnum
    {
        Waiting = 0,
        Request = 1,
        Review = 2,
        Approve = 3,
        Approve_Parallel = 4,
        Reject = 5,
        Reject_Parallel = 6,
        Adhoc = 7,
        Delegasi = 8,
    }

}
