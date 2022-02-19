using System.Threading.Tasks;

namespace CoursesAppMVC.Data;

public interface ICoursesAppMVCDbSchemaMigrator
{
    Task MigrateAsync();
}
