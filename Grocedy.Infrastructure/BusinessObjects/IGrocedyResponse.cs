using System;
namespace Grocedy.Infrastructure.BusinessObjects
{
    public interface IGrocedyResponse
    {
        bool Status { get; set; }
        string Message { get; set; }
    }
}
