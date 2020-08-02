using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Framework.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PhoneBook
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook)]
    public class PersonService : FrameworkAppServiceBase, IPersonService
    {
        private IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            this._repository = repository;
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_CreatePerson)]
        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _repository.InsertAsync(person);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_DeletePerson)]
        public async Task DeletePerson(DeletePersonInput input)
        {
            await _repository.DeleteAsync(input.Id);
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            var people = _repository
                .GetAll()
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) || p.SurName.Contains(input.Filter) || p.EmailAddress.Contains(input.Filter))
                .OrderBy(p => p.Name)
                .ThenBy(p => p.SurName)
                .ToList();
            return new ListResultDto<PersonListDto> { Items = ObjectMapper.Map<List<PersonListDto>>(people) };
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_PhoneBook_UpdatePerson)]
        public Task UpdatePerson(UpdatePersonInput input)
        {
            return _repository.UpdateAsync(ObjectMapper.Map<Person>(input));
        }
    }
}
