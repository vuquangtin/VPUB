namespace CommonHelper.Constants
{
    public class TableNames
    {
        public const string User = "user";
        public const string Group = "group";
        public const string Policy = "policy";
        public const string Key = "key";
        public const string Config = "config";
        public const string Member = "member";
        public const string Department = "department";
        public const string Faculty = "faculty";
        public const string PositionDetail = "position_detail";
        public const string ScaleDetail = "scale_detail";
        public const string Personalization = "personalization";
        public const string PersonalizationApp = "personalization_app";

        public static string GetVietnameseName(string tableName)
        {
            switch(tableName)
            {
                case User:
                    return "Tài Khoản";
                case Group:
                    return "Nhóm";
                case Policy:
                    return "Phân Quyền";
                case Key:
                    return "Khóa";
                case Config:
                    return "Cấu Hình";
                case Member:
                    return "Thành Viên";
                case Department:
                    return "Bộ Môn";
                case Faculty:
                    return "Khoa";
                case PositionDetail:
                    return "Chi Tiết Chức Vụ";
                case ScaleDetail:
                    return "Chi Tiết Ngạch";
                case Personalization:
                    return "Lượt Phát Hành";
                case PersonalizationApp:
                    return "Ứng Dụng Lượt Phát Hành";
                default:
                    return "N/A";
            }
        }
    }
}
