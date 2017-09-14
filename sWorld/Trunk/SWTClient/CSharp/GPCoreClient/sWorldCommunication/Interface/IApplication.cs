using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace sWorldCommunication
{
    public interface IApplication
    {
        /// <summary>
        /// Lấy danh sách ứng dụng 
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="orgId">Tổ chức</param>
        /// <param name="subOrgId">Tổ chức con</param>
        /// <returns>Danh sách ứng dụng</returns>
        List<App> GetAppDataList(string session,long orgId, long subOrgId);

        /// <summary>
        /// Lấy thông tin của ứng dụng
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="appId">Id của ứng dụng</param>
        /// <returns>Thông tin của ứng dụng</returns>
        App GetAppById(string session, long appId);

        /// <summary>
        /// Thêm ứng dụng
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="app">Thông tin của ứng dụng</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int InsertApp(string session, App app);

        /// <summary>
        /// Cập nhật ứng dụng
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="app">Thông tin của ứng dụng</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateApp(string session, App app);

        /// <summary>
        /// Xóa thông tin của ứng dụngs
        /// </summary>
        /// <param name="session">Session của User đăng nhập</param>
        /// <param name="appId">Id của ứng dụng</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int DeleteApp(string session, long appId);
    }
}
