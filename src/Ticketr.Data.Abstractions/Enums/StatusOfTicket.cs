namespace Ticketr.Data.Enums
{
    public enum StatusOfTicket
    {
        None = 0,
        Unassigned = 1,
        Assigned = 2,
        InProgress = 3,
        WaitingForClient = 4,
        ClientNoteAdded = 5,
        Completed = 6,
        Reopened = 7,
        Abandoned = 8
    }
}
