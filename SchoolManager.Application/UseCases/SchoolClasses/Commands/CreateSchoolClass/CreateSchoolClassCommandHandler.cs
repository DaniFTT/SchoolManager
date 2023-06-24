using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.CreateStudent;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.CreateSchoolClass
{
    public sealed class CreateSchoolClassCommandHandler : IRequestHandler<CreateSchoolClassCommand, Result<SchoolClass>>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public CreateSchoolClassCommandHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<Result<SchoolClass>> Handle(CreateSchoolClassCommand createSchoolClassCommand, 
            CancellationToken cancellationToken)
        {
            var schoolClassAreadyExists = await _schoolClassRepository.SchoolClassExistsByName(createSchoolClassCommand.ClassName!);
            if (schoolClassAreadyExists)
                return Result.Conflict("Nome de Turma já utilizado. Escolha um novo!");

            var schoolClass = createSchoolClassCommand.ToDomain();

            var operationSucceded = await _schoolClassRepository.AddAsync(schoolClass);

            return operationSucceded ? Result.Success(schoolClass) : Result.Error(GlobaErrors.BaseError);
        }
    }
}
