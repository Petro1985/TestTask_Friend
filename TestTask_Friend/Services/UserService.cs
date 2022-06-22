using AutoMapper;
using TestTask_Friend.APIStruct;
using TestTask_Friend.DAL.Entities;
using TestTask_Friend.DAL.Repository;
using TestTask_Friend.Errors;
using TestTask_Friend.Utils;
using TestTask_Friend.Validators;

namespace TestTask_Friend.Services;

class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UserRequest> _userValidator;

    public UserService(IUserRepository userRepository, IMapper mapper, IValidator<UserRequest> userValidator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userValidator = userValidator;
    }

    public async Task<OperationResult<UserResponse>> Get(int id, CancellationToken cancellationToken = default)
    {
        var userFromDb = await  _userRepository.GetById(id, cancellationToken);

        if (userFromDb is null)
            return new OperationResult<UserResponse>(new UserNotFoundError(id));
        
        return new OperationResult<UserResponse>(_mapper.Map<UserResponse>(userFromDb));
    }

    public async Task<OperationResult<int>> Set(UserRequest user, CancellationToken cancellationToken = default)
    {
        var validationResult = _userValidator.Validate(user);
        
        if (validationResult.IsError)
            return new OperationResult<int>(new ValidationError(validationResult));

        var userFromDb = await _userRepository.GetByLogin(user.Login, cancellationToken);
        
        if (userFromDb is not null) 
            return new OperationResult<int>(new LoginIsBusyError(user.Login));
        
        var mappedUser = _mapper.Map<UserEntity>(user);
        var newUserId = await _userRepository.Set(mappedUser, cancellationToken);

        return new OperationResult<int>(newUserId);
    }

    public async Task<OperationResult<int>> Authentication(UserCredentials userCredentials, CancellationToken cancellationToken = default)
    {
        var userFromDb = await _userRepository.GetByLogin(userCredentials.Login, cancellationToken);
        
        if (userFromDb is null || userFromDb.Password != userCredentials.Password)
            return new OperationResult<int>(new AuthenticationError());
        
        return new OperationResult<int>(userFromDb.Id);
    }
}

