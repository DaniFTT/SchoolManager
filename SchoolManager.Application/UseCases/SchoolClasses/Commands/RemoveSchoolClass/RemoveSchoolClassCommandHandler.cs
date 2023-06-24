using Ardalis.Result;
using MediatR;
using SchoolManager.Application.UseCases.Students.Commands.InactivateStudent;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Application.UseCases.SchoolClasses.Commands.RemoveSchoolClass
{
    public sealed class RemoveSchoolClassCommandHandler : IRequestHandler<RemoveSchoolClassCommand, Result>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;

        public RemoveSchoolClassCommandHandler(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<Result> Handle(RemoveSchoolClassCommand command,
            CancellationToken cancellationToken)
        {
            var student = await _schoolClassRepository.GetByIdAsync(command.id);
            if (student is null)
                return Result.NotFound("Turma não encontrada!");

            await _schoolClassRepository.RemoveAsync(command.id);

            return Result.Success();
        }
    }
}
