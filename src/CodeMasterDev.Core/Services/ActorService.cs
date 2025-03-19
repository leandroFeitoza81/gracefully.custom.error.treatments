using CodeMasterDev.Core.Domain.Interfaces.Repositories;
using CodeMasterDev.Core.Domain.Interfaces.Services;
using CodeMasterDev.Core.Domain.Models;
using CodeMasterDev.Core.Services.Validator;
using FluentValidation;

namespace CodeMasterDev.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repository;
        public ActorService(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
           return await _repository.GetAll();
        }

        public async Task<Actor?> GetById(int id)
        {
            if (id == 0)
                return null;

            var actor = await _repository.GetById(id);

            return actor;
        }

        public async Task<bool> Insert(Actor actor)
        {
            var validator = new ActorValidator();
            var model = await validator.ValidateAsync(actor);

            if (!model.IsValid)
            {
                foreach (var failure in model.Errors)
                {
                    throw new ValidationException(
                        $"Property [{failure.PropertyName}] failed validation. Erro: {failure.ErrorMessage}");
                }
            }
            
            var result = await _repository.Create(actor);

            return result;

        }

        public async Task<bool> Update(Actor actor)
        {
            var validator = new ActorValidator();
            var model = await validator.ValidateAsync(actor);

            if (!model.IsValid)
            {
                foreach (var failure in model.Errors)
                {
                    throw new ValidationException(
                        $"Property [{failure.PropertyName}] failed validation. Erro: {failure.ErrorMessage}");
                }
            }

            var result = await _repository.Update(actor);

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            if (id == 0)
                return false;

            return await _repository.Delete(id);
        }
    }
}
