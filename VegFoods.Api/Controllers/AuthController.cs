using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegFoods.Api.DTO;
using VegFoods.Core.Models;
using VegFoods.Core.Models.Token;
using VegFoods.Core.Services;
using VegFoods.Core.StringInfos;

namespace VegFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IJwtService jwtService, IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("[action]")]
        
        public async Task<IActionResult> SignIn(UserLoginDTO userLoginDTO)
        {
            //?
            // userName =>  varmı 
            // password => eşleşiyor mu?
            //_jwtService.GenerateJwt()

            var appUser = await _userService.FindByUserName(userLoginDTO.UserName);
            if (appUser == null)
            {
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
            else
            {
               
                // İYİCE BAKAYIM

                User user = new User();
                user.UserName = userLoginDTO.UserName;
                user.Password = userLoginDTO.Password;

                if (await _userService.CheckPassword(user))
                {
                    var activeuser = await _userService.FindByUserName(userLoginDTO.UserName);
                    var roles = await _userService.GetRolesByUserName(userLoginDTO.UserName);
                    var token = _jwtService.GenerateJwt(appUser, roles);
                    //  JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    // jwtAccessToken.Token = token;
                    UserTokenDTO userTokenDTO = new UserTokenDTO
                    {
                        FullName = activeuser.FullName,
                        UserName = activeuser.UserName,
                        Roles = roles.Select(I => I.Name).ToList(),
                        Token = token.ToString()
                    };

                   
                    return Created("", userTokenDTO);
                }
                return BadRequest("kullanıcı adı veya şifre hatalı");
            }
        }


        [HttpPost("[action]")]
       
        public async Task<IActionResult> SignUp(UserAddDTO userAddDTO, [FromServices] IUserRoleService userRoleService, [FromServices] IRoleService roleService)
        {
            var appUser = await _userService.FindByUserName(userAddDTO.UserName);
            if (appUser != null)
                return BadRequest($"{userAddDTO.UserName} zaten alınmış");

            await _userService.AddAsync(_mapper.Map<User>(userAddDTO));
          

            var user = await _userService.FindByUserName(userAddDTO.UserName);
            var role = await roleService.FindByName(RoleInfo.Member);

            await userRoleService.AddAsync(new UserRole
            {
                RoleId = role.Id,
                UserId = user.Id
            });
            return Created("", userAddDTO);
        }


        [HttpGet("[action]")]
        
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _userService.FindByUserName(User.Identity.Name);
            var roles = await _userService.GetRolesByUserName(User.Identity.Name);

            UserDTO userDTO = new UserDTO
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(I => I.Name).ToList()
            };

            return Ok(userDTO);
        }




    }
}
