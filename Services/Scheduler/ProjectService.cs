using golden_snitch.DTOs;
using golden_snitch.DTOs.Scheduler;
using golden_snitch.DTOs.Tenants;
using golden_snitch.Entities;
using golden_snitch.Entities.Projects;

namespace golden_snitch.Services.Scheduler
{
    public class ProjectService : IProjectService
    {
        private readonly ILogger<ProjectService> _logger;
        private readonly EntitiesDbContext _dbContext;

        public ProjectService(ILogger<ProjectService> logger, EntitiesDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public ApiResponse<IEnumerable<ResponseProject>> GetAll()
        {
            try
            {
                return new ApiResponse<IEnumerable<ResponseProject>>
                {
                    Message = ApiResponseMessage.GetSuccessfulResponse("Get Projects"),
                    IsSuccessful = true,
                    Data = _dbContext.Projects
                            .Select(x => new ResponseProject(x)).ToList(),
                };
            }
            catch (Exception e)
            {
                return ApiResponseError<IEnumerable<ResponseProject>>.GenerateUnknownError(
                    ErrorCodes.ServerError, e.Message);
            }
        }

        public ApiResponse<ResponseProject> GetById(int id)
        {
            try
            {
                Project? project = _dbContext.Projects
                            .SingleOrDefault(x => x.Id == id);

                if (project is null) return ApiResponseError<ResponseProject>.GenerateResponseError(ErrorCodes.CanNotFind, "Project", "id", id.ToString());

                return new ApiResponse<ResponseProject>
                {
                    Message = ApiResponseMessage.GetSuccessfulResponse($"Get Project"),
                    IsSuccessful = true,
                    Data = new ResponseProject(project),
                };
            }
            catch (Exception e)
            {
                return ApiResponseError<ResponseProject>.GenerateUnknownError(
                    ErrorCodes.ServerError, e.Message);
            }
        }

        public ApiResponse<ResponseProject> Create(RequestProject request)
        {
            try
            {
                var existingProject = _dbContext.Projects.SingleOrDefault(x => x.Name == request.Name);

                if (existingProject is not null)
                {
                    return ApiResponseError<ResponseProject>.GenerateResponseError(ErrorCodes.AlreadyExists, "Project", "Name", existingProject.Name);
                }

                var newProject = new Project
                {
                    Name = request.Name,
                    Description = request.Description ?? ""
                };

                _dbContext.Projects.Add(newProject);
                bool isSuccessful = _dbContext.SaveChanges() > 0;
                Project? createdProject = _dbContext.Projects.SingleOrDefault(x => x.Id == newProject.Id);

                if (isSuccessful && createdProject is not null)
                    return new ApiResponse<ResponseProject>
                    {
                        Message = ApiResponseMessage.GetSuccessfulResponse($"Get Project"),
                        IsSuccessful = true,
                        Data = new ResponseProject(createdProject),
                    };

                return ApiResponseError<ResponseProject>.GenerateUnknownError(
                    ErrorCodes.DatabaseError, "Something wrong when create new a project");
            }
            catch (Exception e)
            {
                return ApiResponseError<ResponseProject>.GenerateUnknownError(
                    ErrorCodes.ServerError, e.Message);
            }
        }
    }
}
