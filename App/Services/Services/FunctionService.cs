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
    public class FunctionService : IFunctionServiceInterface
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

        public Task<List<FunctionViewModel>> GetByPermission(Guid roleId)
        {
            var functions = (from function in _appDbContext.Functions
                             join permission in _appDbContext.Permisstions
                             on function.Id equals permission.FunctionId
                             where permission.RoleId == roleId
                             select new { Function = function});

            var functionViewModels = functions.ProjectTo<FunctionViewModel>(AutoMapperConfig.RegisterMapping()).ToListAsync();

            return functionViewModels;
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