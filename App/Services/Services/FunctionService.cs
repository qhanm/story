using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using story.App.AutoMapper;
using story.App.CodeFirstEntity;
using story.App.CodeFirstEntity.Entities;
using story.App.Model;
using story.App.Services.Repositories;
using story.App.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace story.App.Services.Services
{
    public class FunctionService : FunctionServiceInterface
    {

        private readonly IRepository<Function, string> _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly AppDbContext _appDbContext;

        public FunctionService(IRepository<Function, string> repository, IUnitOfWork unitOfWork, IMapper mapper, AppDbContext appDbContext)
        {
            _repository =  repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public void Add(FunctionViewModel model)
        {
            var modelMapper = _mapper.Map<FunctionViewModel, Function>(model);

            _repository.Add(modelMapper);
        }

        public void Delete(string id)
        {
            _repository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<FunctionViewModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<FunctionViewModel>> FindAllAsync()
        {
            var functions = _repository.FindAll().OrderBy(x => x.SortOrder)
                                        .ProjectTo<FunctionViewModel>(AutoMapperConfig.RegisterMapping())
                                        .ToListAsync();

            return functions;
        }

        public FunctionViewModel FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<FunctionViewModel> GetByPermission(Guid roleId)
        {
            var functions = _appDbContext.Functions.Join(_appDbContext.Permisstions,
                                                        function => function.Id,
                                                        permisstion => permisstion.FunctionId
                                                        (function, permisstion) => new { Function = function, Permisstion = permisstion });
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(FunctionViewModel model)
        {
            var modelMapper = _mapper.Map<FunctionViewModel, Function>(model);

            _repository.Update(modelMapper);
        }
    }

}