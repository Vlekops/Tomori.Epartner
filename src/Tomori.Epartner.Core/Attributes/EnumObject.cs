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
        EMAIL
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

    public enum ParticipantKelengkapanDokumen
    {
        Participant_Formulir_Pendaftaran,
        Participant_Salinan_KTP,
        Participant_Salinan_Kartu_Keluarga,
        Participant_Buku_Tabungan,
        Participant_Salinan_Nomor_NPWP
    }

    public enum GroupParticipantKelengkapanDokumen
    {
        GroupParticipant_Formulir_Pendaftaran,
        GroupParticipant_Salinan_Akta_Pendirian,
        GroupParticipant_Salinan_Surat_Izin_Usaha,
        GroupParticipant_Salinan_AD_ART_Perusahaan,
        GroupParticipant_Salinan_Nomor_NPWP,
        GroupParticipant_Salinan_Nomor_Identitas,
    }

    public enum PaymentType
    {
        None,
        Individu,
        Group
    }

    public enum ParticipantTypeEnum
    {
        None,
        Individu,
        Group
    }

    public enum ParticipantTransferTypeEnum
    {
        In,
        Out
    }
}
