using golden_snitch.DTOs;
using golden_snitch.Entities;
using golden_snitch.DTOs.Scheduler;

namespace golden_snitch.Services.Scheduler
{
    public class JobService
    {
        private readonly ILogger<JobService> _logger;
        private readonly EntitiesDbContext _dbContext;

        public JobService(EntitiesDbContext dbContext, ILogger<JobService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public ApiResponse<IEnumerable<ResponseJob>> GetAll()
        {
            try
            {
                return new ApiResponse<IEnumerable<ResponseJob>>
                {
                    Message = ApiResponseMessage.GetSuccessfulResponse("Get Jobs"),
                    IsSuccessful = true,
                    Data = _dbContext.Jobs
                            .Select(x => new ResponseJob(x)).ToList(),
                };
            }
            catch (Exception e)
            {
                return ApiResponseError<IEnumerable<ResponseJob>>.GenerateUnknownError(
                    ErrorCodes.ServerError, e.Message);
            }
        }
    }
}
