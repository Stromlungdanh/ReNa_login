using Abp.Application.Services.Dto;
using Framework.Authorization.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface IPersonService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);
        Task CreatePerson(CreatePersonInput input);
        Task DeletePerson(DeletePersonInput input);
        Task UpdatePerson(UpdatePersonInput input);
    }
}
