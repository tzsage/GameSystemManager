/****************************************************************************************************************************************************************/
using Data;
using Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Domain.IRepository.SystemManage
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entitys);
    }
}
