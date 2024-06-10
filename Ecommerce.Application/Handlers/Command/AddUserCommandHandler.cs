using AutoMapper;
using Ecommerce.Application.RequestModels;
using ECommerce.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Command
{
    public class AddUserCommandHandler : IRequestHandler<AddNewUserModel, string>
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public AddUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        #endregion  

        #region To add the new user
        public async Task<string> Handle(AddNewUserModel request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Ecommerce.Domain.Models.CoreModels.User>(request);
            var result = await _userRepository.AddUser(user);
            return result;
        }
        #endregion
    }
}
