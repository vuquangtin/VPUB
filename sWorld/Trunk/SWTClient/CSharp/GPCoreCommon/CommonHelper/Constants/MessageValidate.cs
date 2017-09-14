using CommonHelper.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace CommonHelper.Constants
{
    public static class MessageValidate
    {
        public static readonly String TitleError = "TitleError";//@"Thao Tác Sai";

        public static readonly String BaseMessValidate = "BaseMessValidate";//"Bạn chưa nhập {0}!";
        public static readonly String BaseMessValidateofDeduct = "BaseMessValidateofDeduct";//"Bạn chưa chọn {0} trừ tiền!";
        public static readonly String BaseMessRemove = "BaseMessRemove";//"Bạn có chắc chắn muốn xóa {0} không?";
        public static readonly String BaseMessDataFail = "BaseMessDataFail";//"{0} bạn nhập chưa đúng!";
        public static readonly String BaseMessAddSuccess = "BaseMessSuccess";//"Đã thêm {0} vào hệ thống thành công!";
        public static readonly String BaseMessUpdateSuccess = "BaseMessUpdateSuccess";//"Đã cập nhật {0} vào hệ thống thành công!";
        public static readonly String BaseMessRemoveSuccess = "BaseMessRemoveSuccess";//"Đã xóa {0} khỏi hệ thống thành công!";
        public static readonly String BaseMessNonMember = "BaseMessNonMember";//"Bạn chưa phải {0} để gửi tin nhắn!";
        public static readonly String BaseMessSMSSuccess = "BaseMessSMSSuccess";//"Đã gửi {0} thành công!";
        public static readonly String BaseMessSelect = "BaseMessSelect";//"Bạn chưa chọn {0}!";
        public static readonly String BaseMessStop = "BaseMessStop";//"Bạn có chắc muốn ngừng quá trình {0} thẻ và đóng hộp thoại này không?";
        public static readonly String BaseMessfalse = "BaseMessfalse";//"{0} không đúng!";
        public static readonly String BaseMessExist = "BaseMessExist";//"{0} đã tồn tại!";
        public static readonly String BaseMessDateFail = "BaseMessDateFail";//"Ngày bắt đầu {0} ngày kết thúc!";
        public static readonly String BaseMessCharOverLoad = "BaseMessCharOverLoad";//"{0} không được vượt quá {1} ký tự!";
        public static readonly String BaseMessProgram = "BaseMessProgram";//"Chương trình chỉ cho phép {0}!";
        public static readonly String BaseMessFunction = "BaseMessFunction";//"Chức năng này {0}!";
        public static readonly String BaseMessPassWeak = "BaseMessPassWeak";//"Mật khẩu quá yếu, {0} mật khẩu khác!";
        public static readonly String BaseMessInvalid = "BaseMessInvalid";//"{0} không hợp lệ!";
        public static readonly String BaseMessCancelRequest = "BaseMessCancelRequest";//"Bạn có chắc muốn hủy {0} này không?";
        public static readonly String BaseMessAddGroup = "BaseMessAddGroup";//"Bạn có chắc muốn {0} này vào hệ thống ?";
        public static readonly String ShowResult = "ShowResult";//"Hiển thị {0} kết quả từ {1} đến {2} trong tổng số {3}";
        public static readonly String QuestionAdd = "QuestionAdd";//"Bạn có chắc muốn thêm {0} này vào hệ thống?";
        public static readonly String QuestionUpdate = "QuestionUpdate";//"Bạn có chắc muốn cập nhật {0} này vào hệ thống?";
        public static readonly String BaseMessAddFail = "BaseMessAddFail";//"Thêm mới thất bại!";
        public static readonly String BaseMessUpdateFail = "BaseMessUpdateFail";//"Cập nhật thất bại!";

        /// <summary>
        /// Các field chung
        /// Quy định đặt tên: ProjectName_FieldName
        /// </summary>

        public static readonly String Amount = "Amount";//Số tiền giao dịch
        public static readonly String PhoneFirst = "PhoneFirst";//"Số điện thoại";
        public static readonly String MobilePhone = "MobilePhone";//"số điện thoại di động";

        public static readonly String Email = "Email";//"Email";
        public static readonly String Address = "Address";//"địa chỉ";
        public static readonly String Member = "Member";//"thành viên";
        public static readonly String SMS = "SMS";//"tin nhắn";
        public static readonly String Reader = "Reader";//"thiết bị đọc";
        public static readonly String ClearData = "ClearData";//"xóa dữ liệu";
        public static readonly String ReadData = "ReadData";//"đọc dữ liệu";
        public static readonly String Allocation = "Allocation";//"cấp";
        public static readonly String CardRequiredMem = "CardRequiredMem";//"thành viên cần cấp thẻ";
        public static readonly String CancelMem = "CancelMem";//"thành viên cần hủy";
        public static readonly String UnlockRelease = "UnlockRelease";//"lượt phát hành cần mở khóa";
        public static readonly String CancelRelease = "CancelRelease";//"lượt phát hành cần hủy";
        public static readonly String ExtensionRelease = "ExtensionRelease";//"lượt phát hành cần gia hạn";
        public static readonly String DamageMark = "DamageMark";//"thẻ cần đánh dấu hư";
        public static readonly String LostMark = "LostMark";//"thẻ cần đánh dấu mất";
        public static readonly String CancelLostMark = "CancelLostMark";//"thẻ cần hủy đánh dấu mất";
        public static readonly String CoReleaseOrg = "CoReleaseOrg";//"tổ chức đồng phát hành thẻ";
        public static readonly String CancelCoReleaseOrg = "CoReleaseOrg";//"tổ chức liên kết cần hủy";
        //phan ten them
        public static readonly String Organization = "Organization";//Tổ chức
        public static readonly String SubOrganization = "SubOrganization";//tổ chức con

        public static readonly String MemId = "MemId";//"mã thành viên";
        public static readonly String MemCode = "MemCode";//"mã nhân viên";
        public static readonly String LastName = "LastName";//"họ và tên đệm";
        public static readonly String FirstName = "FirstName";//"tên";
        public static readonly String MemName = "MemName";//"tên thành viên";
        public static readonly String Phone = "Phone";//"số điện thoại";
        public static readonly String Email1 = "Email1";//"email";
        public static readonly String ContactEmail = "ContactEmail";//"Email liên hệ";
        

        public static readonly String CancelSubOrg = "CancelSubOrg";//"tổ chức con cần hủy";
        public static readonly String CancelAcceptOrg = "CancelAcceptOrg";//"tổ chức chấp nhận thẻ cần hủy";
        public static readonly String OrgId = "OrgId";//"mã tổ chức";
        public static readonly String OrgName = "OrgName";//"tên tổ chức";
        public static readonly String ShortName = "ShortName";//"tên viết tắt";
        public static readonly String CancelOrg = "CancelOrg";//"tổ chức cần hủy";
        public static readonly String AddNewOrg = "AddNewOrg";//"thêm tổ chức mới";
        public static readonly String UpdateOrg = "UpdateOrg";//"cập nhật tổ chức";
        public static readonly String App = "app";//"ứng dụng
        public static readonly String Zipcode = "Zipcode";//"ZipCode";
        public static readonly String CountryCode = "CountryCode";//"Mã nước";
        public static readonly String Fax = "Fax";//"Số Fax";
        public static readonly String CMND = "CMND";//"Số CMND";
        public static readonly String Gender = "Gender";//"giới tính";
        public static readonly String ShowTextSearch = "ShowTextSearch";//"Hiện khung tìm kiếm";
        public static readonly String HideTextSearch = "HideTextSearch";//"Ẩn khung tìm kiếm";
        public static readonly String NewGroup = "NewGroup";//"nhóm mới";
        public static readonly String WaitLoadData = "waitLoadData";//"Đang load dữ liệu xin hãy chờ";
        
        /// <summary>
        /// Tao phuong thuc de chia du lieu theo trang
        /// </summary>
        /// <param name="rm"></param>
        /// <param name="numDisplayRecords"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="numTotalRecords"></param>
        /// <returns></returns>
        public static string GetCurrentPage(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, ShowResult);
        }

        public static readonly String GroupName = "GroupName";//"tên nhóm";
        public static readonly String CancelGroup = "CancelGroup";//"nhóm cần hủy";
        public static readonly String UpdateGroup = "UpdateGroup";//"nhóm cần cập nhật";
        public static readonly String GroupId = "GroupId";//"mã nhóm";

        public static readonly String NewPass = "NewPass";//"mật khẩu mới";
        public static readonly String ReNewPass = "ReNewPass";//"lại mật khẩu mới";
        public static readonly String RePass = "RePass";//"Mật khẩu nhập lại";
        public static readonly String CurrentPass = "CurrentPass";//"mật khẩu hiện tại";
        public static readonly String CurrentPassNull = "CurrentPassNull";//"Mật khẩu hiện tại không được rỗng";
        public static readonly String NewPassNull = "NewPassNull";//"Mật khẩu mới không được rỗng";
        public static readonly String ReNewPassNull = "ReNewPassNull";//"Mật khẩu nhập lại không được rỗng";

        public static readonly String UpdateAcc = "UpdateAcc";//"tài khoản cần cập nhật";
        public static readonly String ChangeGroupAcc = "ChangeGroupAcc";//"tài khoản cần đổi nhóm";
        public static readonly String ChangePassAcc = "ChangePassAcc";//"tài khoản cần cài lại mật khẩu";
        public static readonly String LockAcc = "LockAcc";//"tài khoản cần khóa";
        public static readonly String UnLockAcc = "UnLockAcc";//"tài khoản cần mở khóa";
        public static readonly String CancelAcc = "CancelAcc";//"tài khoản cần hủy";
        public static readonly String GroupAcc = "GroupAcc";//"nhóm tài khoản";

        public static readonly String AppName = "AppName";//"tên ứng dụng";
        public static readonly String CancelApp = "CancelApp";//"ứng dụng cần hủy";
        public static readonly String Title = "Title";//"tiêu đề";
        public static readonly String IndentifineCard = "IndentifineCard";//"Số chứng minh nhân dân";

        public static readonly String CancelCoupon = "CancelCoupon";//"cấu hình phiếu cần hủy";
        public static readonly String GiftVoucher_CancelVoucher = "GiftVoucher_CancelVoucher";//"Hủy cấu hình phiếu thất bại!";
        public static readonly String Less = "Less";//"nhỏ hơn";
        public static readonly String Description = "Description";//"Mô tả";

        public static readonly String UpdateProfile = "UpdateProfile";//"cập nhật thông tin cá nhân cho từng tài khoản";
        public static readonly String ChangeGroup = "ChangeGroup";//"đổi nhóm cho từng tài khoản";
        public static readonly String AccActionSupport = "AccActionSupport";//"chỉ hỗ trợ thao tác trên từng tài khoản";
        public static readonly String MemCancelFail = "MemCancelFail";//"Hủy thành viên thất bại";
        public static readonly String SubOrgCancelFail = "SubOrgCancelFail";//"Hủy tổ chức con thất bại";
        public static readonly String Select = "Select";//"vui lòng chọn";
        public static readonly String ExcelPath = "ExcelPath";//"Vui lòng chọn đường dẫn đến tập tin dữ liệu MS Excel!";
        public static readonly String CheckSameColumn = "CheckSameColumn";//"Có các cột trùng vị trí với nhau, xin hãy kiểm tra lại!";
        public static readonly String FirstDataPosition = "FirstDataPosition";//"Bạn chưa nhập vị trí dòng dữ liệu đầu tiên!";
        public static readonly String UserId = "UserId";//"tên đăng nhập";
        public static readonly String AppCancelFail = "AppCancelFail";//"Hủy ứng dụng thất bại";
        public static readonly String ServiceValue = "ServiceValue";//"Giá trị cổng dịch vụ";

        public static readonly String CancelCardConfig = "CancelCardConfig";//"cấu hình dịch vụ";
        public static readonly String CancelCardGroup = "CancelCardGroup";//"nhóm";
        public static readonly String CancelCardNameGroup = "CancelCardNameGroup";//"tên nhóm";
        public static readonly String UpdateCardGroup = "UpdateCardGroup";//"cập nhật nhóm";
        public static readonly String CancelCardItem = "CancelCardItem";//"danh mục";
        public static readonly String GroupCancelFail = "GroupCancelFail";//"Hủy nhóm thất bại";
        public static readonly String CardConfigValidateAmount = "CardConfigValidateAmount";//"15 số";
        public static readonly String CardConfigValidateAmountItem = "CardConfigValidateAmountItem";//"11 số";
        public static readonly String CardConfigValidateAmountisNumber = "CardConfigValidateAmountisNumber";//"chỉ nhập số"
        public static readonly String CardConfigNameConfig = "CardConfigNameConfig";//"tên cấu hình cấu hình";
        public static readonly String MenuEcashTopUp = "MenuEcashTopUp";//"nạp tiền"; 
        public static readonly String MenuEcashDeDuct = "MenuEcashDeDuct";//"trử tiền";
        public static readonly String CloseEcashDeDuct = "CloseEcashDeDuct";//"Trử tiền";
        public static readonly String MenuEcashNameItem = "MenuEcashNameItem";//"tên dịch vụ"; 
        public static readonly String NameItemDeduct = "NameItemDeduct";//"dịch vụ";

        public static readonly String DeviceDoorName = "DeviceDoorName";//Tên thiết bị
        public static readonly String Device = "Device";//thiết bị
        public static readonly String ValidateTitle = "ValidateTitle";//Tên thiết bị
        public static readonly String Confirm = "Confirm";//Confirm
        public static readonly String Cancel = "Cancel";//Cancel
        public static readonly String Close = "Close";//Close
        public static readonly String ErrorOccurred = "ErrorOccurred";//ErrorOccurred
        public static readonly String Information = "Information";//Information
        public static readonly String WarningLabel = "WarningLabel";//WarningLabel
        public static readonly String SetupKey = "SetupKey";//SetupKey



        //Sai Gon Pearl
        public static readonly String SaiGonPearlConfigApartment = "SaiGonPearlConfigApartment";//"1 Cấu hình";

        /// <summary>
        /// Quy định đặt tên: ProjectName_FieldName
        /// </summary>

        public static readonly String Attendance_ContactName = "Attendance_ContactName";//"tên người liên hệ";



        #region Funcetion Set Message
        public static string GetErrorTitle(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, TitleError);
        }

        public static string GetValidateTitle(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, ValidateTitle);
        }

        public static string GetMessage(ResourceManager rm, string key)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, key);
        }

        public static string GetMessageValidate(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessValidate);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetBaseMessValidateofDeduct(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessValidateofDeduct);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessageRemove(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessRemove);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }

        public static string GetMessageDataFail(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessDataFail);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }

        public static string GetAddMessageSuccess(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessAddSuccess);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetUpdateMessageSuccess(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessUpdateSuccess);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetRemoveMessageSuccess(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessRemoveSuccess);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessNonMember(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessNonMember);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessSMSSuccess(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessSMSSuccess);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessSelect(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessSelect);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessStop(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessStop);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessFalse(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessfalse);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessExist(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessExist);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessDateFail(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessDateFail);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessCharOverLoad(ResourceManager rm, string keyName, int lenght)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessCharOverLoad);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para, lenght);
        }
        public static string GetMessProgram(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessProgram);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessFunction(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessFunction);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessPassWeak(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessPassWeak);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetMessInvalid(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessInvalid);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }

        public static string GetMessCancelRequest(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessCancelRequest);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetBaseMessAddGroup(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, BaseMessAddGroup);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }

        public static string GetQuestionAdd(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, QuestionAdd);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetQuestionUpdate(ResourceManager rm, string keyName)
        {
            string mess = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, QuestionUpdate);
            string para = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, keyName);
            return string.Format(mess, para);
        }
        public static string GetConfirm(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Confirm);
        }
        public static string GetButtonConfirm(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Confirm);
        }
        public static string GetButtonCancel(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Cancel);
        }
        public static string GetButtonClose(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Close);
        }
        public static string GetButtonErrorOccurred(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, ErrorOccurred);
        }
        public static string GetButtonInformation(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, Information);
        }
        public static string GetButtonWarningLabel(ResourceManager rm)
        {
            return ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, WarningLabel);
        }
        #endregion
    }
}
