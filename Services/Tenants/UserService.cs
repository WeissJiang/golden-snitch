using golden_snitch.DTOs;
using golden_snitch.DTOs.Tenants;
using golden_snitch.Entities;
using golden_snitch.Entities.Users;

namespace golden_snitch.Services.Tenants
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly EntitiesDbContext _dbContext;

        public UserService(ILogger<UserService> logger, EntitiesDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public ApiResponse<IEnumerable<ResponseUser>> GetAll()
        {
            try
            {
                return new ApiResponse<IEnumerable<ResponseUser>>
                {
                    Message = ApiResponseMessage.GetSuccessfulResponse("Get Users"),
                    IsSuccessful = true,
                    Data = _dbContext.Users
                            .Select(x => new ResponseUser(x)).ToList(),
                };
            }
            catch (Exception e)
            {
                return ApiResponseError<IEnumerable<ResponseUser>>.GenerateUnknownError(
                    ErrorCodes.ServerError, e.Message);
            }
        }

        public ApiResponse<ResponseUser> GetById(int id)
        {
            try
            {
                User? user = _dbContext.Users
                            .SingleOrDefault(x => x.Id == id);

                if (user is null) return ApiResponseError<ResponseUser>.GenerateResponseError(ErrorCodes.CanNotFind, "User", "id", id.ToString());

                return new ApiResponse<ResponseUser>
                {
                    Message = ApiResponseMessage.GetSuccessfulResponse($"Get User"),
                    IsSuccessful = true,
                    Data = new ResponseUser(user),
                };
            }
            catch (Exception e)
            {
                return ApiResponseError<ResponseUser>.GenerateUnknownError(
                    ErrorCodes.ServerError, e.Message);
            }
        }
    }
}
