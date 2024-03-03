using golden_snitch.DTOs;
using golden_snitch.DTOs.Scheduler;

namespace golden_snitch.Services.Scheduler
{
    public interface IProjectService
    {
        ApiResponse<ResponseProject> Create(RequestProject request);
        ApiResponse<IEnumerable<ResponseProject>> GetAll();
        ApiResponse<ResponseProject> GetById(int id);
    }
}