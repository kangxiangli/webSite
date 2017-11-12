﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper;
using Whiskey.Core;
using Whiskey.Core.Data;
using Whiskey.Web.Helper;
using Whiskey.Web.SignalR;
using Whiskey.Web.Http;
using Whiskey.Web.Extensions;
using Whiskey.Utility;
using Whiskey.Utility.Helper;
using Whiskey.Utility.Data;
using Whiskey.Utility.Web;
using Whiskey.Utility.Class;
using Whiskey.Utility.Extensions;
using Whiskey.ZeroStore.ERP.Transfers;
using Whiskey.ZeroStore.ERP.Models;
using Whiskey.ZeroStore.ERP.Services.Contracts;
using Whiskey.ZeroStore.ERP.Transfers.Enum.Office;
using System.Web.Mvc;
using Whiskey.Utility.Logging;


namespace Whiskey.ZeroStore.ERP.Services.Implements
{
    public class PartnerService : ServiceBase, IPartnerContract
    {

        #region 声明数据层操作对象

        protected readonly ILogger _Logger = LogManager.GetLogger(typeof(PartnerService));

        private readonly IRepository<Partner, int> _partnerRepository;

        public PartnerService(IRepository<Partner, int> partnerRepository)
            : base(partnerRepository.UnitOfWork)
		{
            _partnerRepository = partnerRepository;
		}
        #endregion

        #region 查看数据

        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Partner View(int Id)
        {
            var entity = _partnerRepository.GetByKey(Id);
            return entity;
        }
        #endregion

        #region 获取编辑对象
                
        /// <summary>
        /// 获取单个DTO数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public PartnerDto Edit(int Id)
        {
            var entity = _partnerRepository.GetByKey(Id);
            Mapper.CreateMap<Partner, PartnerDto>();
            var dto = Mapper.Map<Partner, PartnerDto>(entity);            
            return dto;
        }
        #endregion

        #region 获取数据集
               
        /// <summary>
        /// 获取数据集
        /// </summary>
        public IQueryable<Partner> Partners { get { return _partnerRepository.Entities; } }
        #endregion

        #region 添加数据
               
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dtos">要添加的DTO数据</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Insert(params PartnerDto[] dtos)
        {
            try
            {
                dtos.CheckNotNull("dtos");
                IQueryable<Partner> listPartner = this.Partners.Where(x=>x.IsDeleted==false && x.IsEnabled==true);                
                foreach (var dto in dtos)
                {
                    int index  = listPartner.Where(x => x.PartnerName == dto.PartnerName).Count();
                    if (index > 0)
                    {
                        return new OperationResult(OperationResultType.Error, "合作商已经注册");
                    }
                    index = listPartner.Where(x => x.PhoneNum == dto.PhoneNum).Count();
                    if (index > 0)
                    {
                        return new OperationResult(OperationResultType.Error, "手机号码已经注册");
                    }
                    index = listPartner.Where(x => x.Email == dto.Email).Count();
                    if (index > 0)
                    {
                        return new OperationResult(OperationResultType.Error, "邮箱已经注册");
                    }
                    dto.PartnerPass = dto.PartnerPass.MD5Hash().Trim().ToLower();
                    string strNum = string.Empty;
                    while (true)
                    {
                        strNum = RandomHelper.GetRandomNum(6);
                        int count = this.Partners.Where(x => x.PartnerNum == strNum).Count();
                        if (count > 0)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    dto.PartnerNum = strNum;   
                }                 
                OperationResult result = _partnerRepository.Insert(dtos,
                dto =>
                {

                },
                (dto, entity) =>
                {
                    entity.CreatedTime = DateTime.Now;
                    entity.OperatorId = AuthorityHelper.OperatorId;
                    return entity;
                });
                return result;
            }
            catch (Exception ex)
            {
                _Logger.Error<string>(ex.ToString());
                return new OperationResult(OperationResultType.Error, "服务器忙，请稍后重试！");
            }
        }
        #endregion

        #region 更新数据

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="dtos">包含更新数据的DTO数据</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Update(params PartnerDto[] dtos)
        {
            try
            {
                dtos.CheckNotNull("dtos");                                  
                IQueryable<Partner> listPartner = this.Partners.Where(x => x.IsDeleted == false && x.IsEnabled == true);                
                foreach (var dto in dtos)
                {
                    int index = listPartner.Where(x => x.PartnerName == dto.PartnerName && x.Id!=dto.Id).Count();
                    if (index > 0)
                    {
                        return new OperationResult(OperationResultType.Error, "合作商已经注册");
                    }
                    index = listPartner.Where(x => x.PhoneNum == dto.PhoneNum && x.Id != dto.Id).Count();
                    if (index > 0)
                    {
                        return new OperationResult(OperationResultType.Error, "手机号码已经注册");
                    }
                    index = listPartner.Where(x => x.Email == dto.Email && x.Id != dto.Id).Count();
                    if (index > 0)
                    {
                        return new OperationResult(OperationResultType.Error, "邮箱已经注册");
                    }
                    Partner partner=this.Partners.Where(x=>x.Id==dto.Id).FirstOrDefault();
                    if(partner==null)
                    {
                        return new OperationResult(OperationResultType.Error, "修改的数据不存在");
                    }
                    else
                    {
                        dto.PartnerPass=partner.PartnerPass;
                        dto.PartnerPhoto=partner.PartnerPhoto;
                        dto.PhoneNum = partner.PhoneNum;                        
                    }
                    
                }                
                OperationResult result = _partnerRepository.Update(dtos,
                 dto =>
                 {
                 
                 },
                 (dto, entity) =>
                 {
                     entity.UpdatedTime = DateTime.Now;
                     entity.OperatorId = AuthorityHelper.OperatorId;
                     return entity;
                 });

                return result;
            }
            catch (Exception ex)
            {
                _Logger.Error<string>(ex.ToString());
                return new OperationResult(OperationResultType.Error, "服务器忙，请稍后重试！" );
            }
        }
        #endregion

        #region 移除数据

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="ids">要移除的编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Remove(params int[] ids)
        {
            try
            {
                ids.CheckNotNull("ids");
                UnitOfWork.TransactionEnabled = true;
                var entities = _partnerRepository.Entities.Where(m => ids.Contains(m.Id));
                foreach (var entity in entities)
                {
                    entity.IsDeleted = true;
                    entity.UpdatedTime = DateTime.Now;
                    entity.OperatorId = AuthorityHelper.OperatorId;
                    _partnerRepository.Update(entity);
                }
                return UnitOfWork.SaveChanges() > 0 ? new OperationResult(OperationResultType.Success, "移除成功！") : new OperationResult(OperationResultType.NoChanged, "数据没有变化！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "移除失败！错误如下：" + ex.Message);
            }
        }
        #endregion

        #region 恢复数据
               
        /// <summary>
        /// 恢复数据
        /// </summary>
        /// <param name="ids">要恢复的编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Recovery(params int[] ids)
        {
            try
            {
                ids.CheckNotNull("ids");
                UnitOfWork.TransactionEnabled = true;
                var entities = _partnerRepository.Entities.Where(m => ids.Contains(m.Id));
                foreach (var entity in entities)
                {
                    entity.IsDeleted = false;
                    entity.UpdatedTime = DateTime.Now;
                    entity.OperatorId = AuthorityHelper.OperatorId;
                    _partnerRepository.Update(entity);
                }
                return UnitOfWork.SaveChanges() > 0 ? new OperationResult(OperationResultType.Success, "恢复成功！") : new OperationResult(OperationResultType.NoChanged, "数据没有变化！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "恢复失败！错误如下：" + ex.Message);
            }
        }
        #endregion

        #region 启用数据
                
        /// <summary>
        /// 启用数据
        /// </summary>
        /// <param name="ids">要启用的编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Enable(params int[] ids)
        {

            try
            {
                ids.CheckNotNull("ids");
                UnitOfWork.TransactionEnabled = true;
                var entities = _partnerRepository.Entities.Where(m => ids.Contains(m.Id));
                foreach (var entity in entities)
                {
                    entity.IsEnabled = true;
                    entity.UpdatedTime = DateTime.Now;
                    entity.OperatorId = AuthorityHelper.OperatorId;
                    _partnerRepository.Update(entity);
                }
                return UnitOfWork.SaveChanges() > 0 ? new OperationResult(OperationResultType.Success, "启用成功！") : new OperationResult(OperationResultType.NoChanged, "数据没有变化！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "启用失败！错误如下：" + ex.Message);
            }
        }
        #endregion

        #region 禁用数据
        
        /// <summary>
        /// 禁用数据
        /// </summary>
        /// <param name="ids">要禁用的编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Disable(params int[] ids)
        {
            try
            {
                ids.CheckNotNull("ids");
                UnitOfWork.TransactionEnabled = true;
                var entities = _partnerRepository.Entities.Where(m => ids.Contains(m.Id));
                foreach (var entity in entities)
                {
                    entity.IsEnabled = false;
                    entity.UpdatedTime = DateTime.Now;
                    entity.OperatorId = AuthorityHelper.OperatorId;
                    _partnerRepository.Update(entity);
                }
                return UnitOfWork.SaveChanges() > 0 ? new OperationResult(OperationResultType.Success, "禁用成功！") : new OperationResult(OperationResultType.NoChanged, "数据没有变化！");
            }
            catch (Exception ex)
            {
                return new OperationResult(OperationResultType.Error, "禁用失败！错误如下：" + ex.Message);
            }
        }
        #endregion

        #region 获取数据下拉选项列表
        /// <summary>
        /// 获取数据下拉选项列表
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public List<SelectListItem> SelectList(string title)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            IQueryable<Partner> listAnn = this.Partners.Where(x => x.IsDeleted == false && x.IsEnabled == true);
            foreach (var item in listAnn)
            {
                list.Add(new SelectListItem() { Text = item.PartnerName, Value = item.Id.ToString() });
            }
            if (!String.IsNullOrEmpty(title))
            {
                list.Insert(0, new SelectListItem() { Text = title, Value =string.Empty });
            }
            return list;
        }
        #endregion

    }
}