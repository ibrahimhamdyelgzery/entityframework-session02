using Assignmnet_2_EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignmnet_2_EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EventHubContext();
            context.Database.Migrate();
        }
    }
}
