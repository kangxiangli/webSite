﻿
//   This file was generated by T4 code generator Implement_Creater.tt.



using System;
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

namespace Whiskey.ZeroStore.ERP.Services.Implements
{

    public class TransferItemService : ServiceBase, ITransferItemContract
    {
        #region TransferItemService

		private readonly IRepository<TransferItem, int> _transferitemRepository;


		public TransferItemService(
			IRepository<TransferItem, int> transferitemRepository
		): base(transferitemRepository.UnitOfWork)
		{
			_transferitemRepository = transferitemRepository;
		}


        /// <summary>
        /// 获取单个数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
		public TransferItem View(int Id){
			var entity=_transferitemRepository.GetByKey(Id);
            return entity;
		}


        /// <summary>
        /// 获取单个DTO数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
		public TransferItemDto Edit(int Id){
			var entity=_transferitemRepository.GetByKey(Id);
            Mapper.CreateMap<TransferItem, TransferItemDto>();
            var dto = Mapper.Map<TransferItem, TransferItemDto>(entity);
            return dto;
		}


        /// <summary>
        /// 获取数据集
        /// </summary>
        public IQueryable<TransferItem> TransferItems { get { return _transferitemRepository.Entities; } }



        /// <summary>
        /// 按条件检查数据是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的编号</param>
        /// <returns>是否存在</returns>
        public bool CheckExists(Expression<Func<TransferItem, bool>> predicate, int id = 0)
        {
            return _transferitemRepository.ExistsCheck(predicate, id);
        }



        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="dtos">要添加的DTO数据</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Insert(params TransferItemDto[] dtos)
        {
            try
            {
				dtos.CheckNotNull("dtos");
				OperationResult result = _transferitemRepository.Insert(dtos,
				dto =>
				{
					
				},
				(dto, entity) =>
				{
					entity.CreatedTime = DateTime.Now;
					entity.OperatorId=AuthorityHelper.OperatorId;
					return entity;
				});
				return result;
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "添加失败！错误如下：" + ex.Message);
            }
        }



		/// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="dtos">包含更新数据的DTO数据</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Update(params TransferItemDto[] dtos)
        {
            try
            {
				dtos.CheckNotNull("dtos");
				OperationResult result = _transferitemRepository.Update(dtos,
					dto =>
					{

					},
					(dto, entity) => {
						entity.UpdatedTime = DateTime.Now;
						entity.OperatorId=AuthorityHelper.OperatorId;
						return entity;
					});
				return result;
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "更新失败！错误如下：" + ex.Message);
            }
        }



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
				var entities = _transferitemRepository.Entities.Where(m => ids.Contains(m.Id));
				foreach (var entity in entities) {
					entity.IsDeleted = true;
					entity.UpdatedTime = DateTime.Now;
					entity.OperatorId=AuthorityHelper.OperatorId;
					_transferitemRepository.Update(entity);
				}
				return UnitOfWork.SaveChanges() > 0? new OperationResult(OperationResultType.Success, "移除成功！"): new OperationResult(OperationResultType.NoChanged,"数据没有变化！");
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "移除失败！错误如下：" + ex.Message);
            }
        }


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
				var entities = _transferitemRepository.Entities.Where(m => ids.Contains(m.Id));
				foreach (var entity in entities) {
					entity.IsDeleted = false;
					entity.UpdatedTime = DateTime.Now;
					entity.OperatorId=AuthorityHelper.OperatorId;
					_transferitemRepository.Update(entity);
				}
				return UnitOfWork.SaveChanges() > 0? new OperationResult(OperationResultType.Success, "恢复成功！"): new OperationResult(OperationResultType.NoChanged,"数据没有变化！");
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "恢复失败！错误如下：" + ex.Message);
            }
        }


        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids">要删除的编号</param>
        /// <returns>业务操作结果</returns>
        public OperationResult Delete(params int[] ids)
        {
            try
            {
				ids.CheckNotNull("ids");
				OperationResult result = _transferitemRepository.Delete(ids);
				return result;
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "删除失败！错误如下：" + ex.Message);
            }

        }


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
				var entities = _transferitemRepository.Entities.Where(m => ids.Contains(m.Id));
				foreach (var entity in entities) {
					entity.IsEnabled = true;
					entity.UpdatedTime = DateTime.Now;
					entity.OperatorId=AuthorityHelper.OperatorId;
					_transferitemRepository.Update(entity);
				}
				return UnitOfWork.SaveChanges() > 0? new OperationResult(OperationResultType.Success, "启用成功！"): new OperationResult(OperationResultType.NoChanged,"数据没有变化！");
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "启用失败！错误如下：" + ex.Message);
            }
		}


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
				var entities = _transferitemRepository.Entities.Where(m => ids.Contains(m.Id));
				foreach (var entity in entities) {
					entity.IsEnabled = false;
					entity.UpdatedTime = DateTime.Now;
					entity.OperatorId=AuthorityHelper.OperatorId;
					_transferitemRepository.Update(entity);
				}
				return UnitOfWork.SaveChanges() > 0? new OperationResult(OperationResultType.Success, "禁用成功！"): new OperationResult(OperationResultType.NoChanged,"数据没有变化！");
            }catch (Exception ex){
                return new OperationResult(OperationResultType.Error, "禁用失败！错误如下：" + ex.Message);
            }
		}




        #endregion
    }
}