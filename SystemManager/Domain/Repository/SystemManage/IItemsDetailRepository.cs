/****************************************************************************************************************************************************************/
using Data;
using Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace Domain.IRepository.SystemManage
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetailEntity>
    {
        List<ItemsDetailEntity> GetItemList(string enCode);
    }
}
