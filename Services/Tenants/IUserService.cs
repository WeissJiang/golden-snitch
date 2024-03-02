using golden_snitch.DTOs;
using golden_snitch.DTOs.Tenants;

namespace golden_snitch.Services.Tenants
{
    public interface IUserService
    {
        ApiResponse<IEnumerable<ResponseUser>> GetAll();
        ApiResponse<ResponseUser> GetById(int id);
    }
}