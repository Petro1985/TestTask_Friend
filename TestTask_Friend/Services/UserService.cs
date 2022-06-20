using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Utils;
using TestTask_Friend.Validators;

namespace TestTask_Friend.Services;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<User> _userValidator;

    public UserService(IUserRepository userRepository, IMapper mapper, IValidator<User> userValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userValidator = userValidator;
    }

    public async Task<User?> Get(int id)
    {
        var userFromDb = await  _userRepository.GetById(id);
        return userFromDb is null ? null : _mapper.Map<User>(userFromDb);
    }

    public async Task<OperationResult<int, IReadOnlyCollection<string>>> Set(User user)
    {
        var validationResult = _userValidator.Validate(user);
        if (validationResult.IsError)
            return new OperationResult<int, IReadOnlyCollection<string>>(validationResult.GetErrors());

        var userFromDb = await _userRepository.GetByLogin(user.login);
        
        if (userFromDb is not null) 
            return new OperationResult<int, IReadOnlyCollection<string>>(
                new List<string>{$"User with login={user.login} is already exist"}
                );
        
        var mappedUser = _mapper.Map<UserEntity>(user);
        var newUserId = await _userRepository.Set(mappedUser);

        return new OperationResult<int, IReadOnlyCollection<string>>(newUserId);
    }

    public async Task<OperationResult<UserEntity, string>> Authentication(UserCredentials userCredentials)
    {
        var userFromDb = await _userRepository.GetByLogin(userCredentials.login);
        
        if (userFromDb is null || userFromDb.Password != userCredentials.password) return new OperationResult<UserEntity, string>("Wrong login or password");
        return new OperationResult<UserEntity, string>(userFromDb);
    }
}

