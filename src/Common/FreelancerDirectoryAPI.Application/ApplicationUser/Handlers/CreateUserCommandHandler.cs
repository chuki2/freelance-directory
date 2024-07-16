using FreelancerDirectoryAPI.Application.ApplicationUser.Commands;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using FreelancerDirectoryAPI.Domain.Persistence;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace FreelancerDirectoryAPI.Application.ApplicationUser.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResult<ApplicationUserDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public CreateUserCommandHandler(
            ApplicationDbContext context,
            IConfiguration configuration,
            IMapper mapper,
            IMemoryCache memoryCache,
            UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _cache = memoryCache;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.CustomMessage("Error to create user admin"));
            }

            string skillsetsAsString = request.Skillsets != null ? string.Join(",", request.Skillsets) : string.Empty;

            var user = new Domain.Entities.ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Skillsets = skillsetsAsString,
                Hobby = request.Hobby
            };

            var temporaryPassword = GenerateTemporaryPassword();

            var result = await _userManager.CreateAsync(user, temporaryPassword);

            return result == IdentityResult.Success ? ServiceResult.Success(_mapper.Map<ApplicationUserDto>(user)) : ServiceResult.Failed<ApplicationUserDto>(ServiceError.CustomMessage("Error to create user admin"));
        }

        private string GenerateTemporaryPassword()
        {
            const int passwordLength = 12;
            const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@$?_-";
            Random random = new Random();
            char[] chars = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = validChars[random.Next(validChars.Length)];
            }
            return new string(chars);
        }
    }

}
