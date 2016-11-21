using Code;
using DataHelper.Repository;
using Domain;
using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.WebManage
{
     public  class ADRepository: WebRepositoryBase<ADModel>
    {
        public void SubmitForm(ADModel itemsEntity, long keyValue)
        {
            if (keyValue>0)
            {
                itemsEntity.AID = keyValue;
                var LoginInfo = OperatorProvider.Provider.GetCurrent();
                if (LoginInfo != null)
                {
                    itemsEntity.ACreateUser = LoginInfo.UserId;
                }
                itemsEntity.AeditTime = DateTime.Now;
                base.Update(itemsEntity);
            }
            else
            {
                
                base.Insert(itemsEntity);
            }
        }
    }

    public class ADItemRepository : WebRepositoryBase<ADItemModel>
    {

        public void SubmitForm(ADItemModel itemsEntity, long keyValue)
        {
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                itemsEntity.ICreateName = LoginInfo.UserName;
            }
            itemsEntity.ICreatetime = DateTime.Now;
            itemsEntity.IStatus = true;
            if (keyValue > 0)
            {
                itemsEntity.IID = keyValue;
               
                base.Update(itemsEntity);
            }
            else
            {

                base.Insert(itemsEntity);
            }
        }
    }

}
