using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace JavaCommunication.Test
{
    public class HardCode
    {
        private static HardCode instance = new HardCode();
        public static HardCode Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HardCode();
                }
                return instance;
            }
        }
        private HardCode()
        {
        }

        #region Authentication

        public List<Function> LoadPermissionList()
        {
            List<Function> permissions = new List<Function>();

            permissions.Add(Function.FUNC_CARD_CHANGE_STATUS);
            permissions.Add(Function.FUNC_CARD_IMPORT);
            permissions.Add(Function.FUNC_CARD_VIEW);
            permissions.Add(Function.FUNC_PERSO_CHANGE_STATUS);
            permissions.Add(Function.FUNC_PERSO_EXTEND);
            permissions.Add(Function.FUNC_PERSO_PERSO_CARD);
            permissions.Add(Function.FUNC_PERSO_VIEW);
            permissions.Add(Function.FUNC_TEACHER_VIEW);
            permissions.Add(Function.FUNC_TOOLKIT_CLEAR_DATA);
            permissions.Add(Function.FUNC_TOOLKIT_READ_DATA);
            permissions.Add(Function.FUNC_TOOLKIT_UPDATE_DATA);
            permissions.Add(Function.MOD_CARD_MGT);
            permissions.Add(Function.MOD_PERSO_MGT);
            permissions.Add(Function.MOD_STATS);
            permissions.Add(Function.MOD_TEACHER_MGT);
            permissions.Add(Function.MOD_TOOLKIT);
            permissions.Add(Function.NULL);

            return permissions;
        }

        public SessionDTO GetSession()
        {
            return new SessionDTO()
            {
                Id = 1,
                Token = "dd2cf29f-07e3-4c14-835c-2c96f1a7ebb7",
                GroupId = -1,
                UserName = "root",
                IsRoot = true
            };
        }

        #endregion

        #region Key

        public MasterInfoDTO GetMasterInfoDto(string masterCode)
        {
            List<CardTypeDTO> cardType1 = new List<CardTypeDTO>();
            cardType1.Add(new CardTypeDTO { cardTypeName = "AAAA", prefix = "01" });
            cardType1.Add(new CardTypeDTO { cardTypeName = "BBBB", prefix = "02" });
            cardType1.Add(new CardTypeDTO { cardTypeName = "CCCC", prefix = "03" });

            return new MasterInfoDTO()
            {
                MasterId = 1,
                OrgShortName = @"SWT",
                Name = @"Smart World Technology",
                key = new KeyDTO()
                {
                    Id = 1,
                    KeyValue1 = "%tB&1oH*54jh^04k<%ikD48?2Mnb>Cf0",
                    Key = new SectorKeyPairDTO()
                },
                code = @"01",
                cardtypes = cardType1
            };
        }

        public List<PartnerInfoDTO> GetPartnerInfoDto(string partnerCode)
        {
            List<PartnerInfoDTO> partnerList = new List<PartnerInfoDTO>();
            List<string> partnerNames = new List<string>() 
            {
                "Yes Card","BNI","YBA",
            };

            List<CardTypeDTO> cardType1 = new List<CardTypeDTO>();
            cardType1.Add(new CardTypeDTO { cardTypeName = "Economic", prefix = "01" });
            cardType1.Add(new CardTypeDTO { cardTypeName = "Student", prefix = "02" });
            cardType1.Add(new CardTypeDTO { cardTypeName = "Bussiness", prefix = "03" });

            List<CardTypeDTO> cardType2 = new List<CardTypeDTO>();
            cardType2.Add(new CardTypeDTO { cardTypeName = "Diamond", prefix = "01" });
            cardType2.Add(new CardTypeDTO { cardTypeName = "Gold", prefix = "02" });
            cardType2.Add(new CardTypeDTO { cardTypeName = "Silver", prefix = "03" });

            for (int i = 0; i < partnerNames.Count; i++)
            {
                var partnerInfo = new PartnerInfoDTO()
                {
                    PartnerId = 1,
                    OrgShortName = string.Format("TN{0}", i + 1),
                    Name = partnerNames[i],
                    key = new KeyDTO()
                    {
                        Id = 1,
                        KeyValue1 = "%tB&1oH*54jh^04k<%ikD48?2Mnb>Cf0",
                        Key = new SectorKeyPairDTO()
                    },
                    code = string.Format("000{0}", i + 1),
                    cardtypes = i == 0 ? cardType1 : i == 1 ? cardType2 : cardType2,

                };
                partnerList.Add(partnerInfo);
            }
            return partnerList;
        }

        #endregion

        #region Magnetic

        public PreGenerateData GetPreGenerateDataDto()
        {
            return new PreGenerateData()
            {
                AlgorithmSerial = 1,
                BeginNumber = 1000,
                FullName = "Member Default",
                CompanyName = "Smart World Technology",
                PhoneNumber = "0123456789",
            };
        }

        public List<CMSCardmagneticDto> GetCardMagneticList()
        {
            List<CMSCardmagneticDto> memberList = new List<CMSCardmagneticDto>();
            for (int i = 1; i <= 100; i++)
            {
                var subOrg = new CMSCardmagneticDto()
                {
                    MagneticId = 1,
                    OrgMasterId = 2,
                    OrgPartnerId = 3,
                    CardNumber = "5555",
                };
                memberList.Add(subOrg);
            }
            return memberList;
        }

        #endregion

        #region Quan ly vong doi the Chip

        public List<SubOrgCustomerDTO> GetSubOrgList()
        {
            List<SubOrgCustomerDTO> subOrgList = new List<SubOrgCustomerDTO>();
            for (int i = 1; i <= 10; i++)
            {
                var subOrg = new SubOrgCustomerDTO()
                {
                    OrgId = i,
                    OrgShortName = string.Format("PB {0}", i),
                    Name = string.Format("Phong ban {0}", i),
                };
                subOrgList.Add(subOrg);
            }
            return subOrgList;
        }

        public List<MemberChipPersoDTO> GetMemberChipList()
        {
            List<MemberChipPersoDTO> memberList = new List<MemberChipPersoDTO>();
            for (int i = 1; i <= 100; i++)
            {
                var subOrg = new MemberChipPersoDTO()
                {
                    Member = new MemberDTO()
                    {
                        Id = i,
                        FirstName = "Nguyen Cong",
                        LastName = "Chinh",
                        BirthDate = DateTime.Now.AddYears(-24),
                        PermanentAddress = "4a nguyen van b",
                        TemporaryAddress = "4a nguyen van bcbxmbm",
                        PhoneNo = "0123456789",
                        Email = "chinh.nguyen@smartworld.com.vn",
                    },
                    PersoCard = new PersoCardCustomerDTO()
                    {
                        ChipPersoId = i,
                        CardChipId = i,
                        SerialNumber = "8C19D257",
                        PersoDate = DateTime.Now.ToShortDateString(),
                        ExpirationDate = DateTime.Now.AddYears(1).ToShortDateString(),
                        PhysicalStatus = 1,
                        Status = 2,
                    },
                };
                memberList.Add(subOrg);
            }
            return memberList;
        }

        public List<MemberMagneticPersoDTO> GetMemberMagneticList(CardMagneticFilterDto filter)
        {
            List<MemberMagneticPersoDTO> memberList = new List<MemberMagneticPersoDTO>();
            List<MemberMagneticPersoDTO> result = new List<MemberMagneticPersoDTO>();
            for (int i = 1; i <= 100; i++)
            {
                var subOrg = new MemberMagneticPersoDTO()
                {
                    Member = new MemberDTO()
                    {
                        Id = i,
                        FirstName = "Hóa",
                        LastName = "Phan",
                        BirthDate = DateTime.Now.AddYears(-24),
                        PermanentAddress = "ABCC",
                        TemporaryAddress = "EEEE",
                        PhoneNo = "0123456789",
                        Email = "hoa.phan@smartworld.com.vn",
                    },
                    PersoCardMagnetic = new PersoCardMagneticCustomerDTO()
                    {
                        CardMagneticId = i,
                        MagneticId = i,
                        SerialCard = "8C19D257",
                        PersoDate = DateTime.Now.ToShortDateString(),
                        ExpirationDate = DateTime.Now.AddYears(1).ToShortDateString(),
                        PhysicalStatus = i < 25 ? 1 : i < 50 ? 2 : 3,
                        LogicalStatus = i < 25 ? 1 : i < 50 ? 2 : 3,
                        Status = 2,
                    }
                };
                memberList.Add(subOrg);
            }

            if (filter.FilterByCardPhysicalStatus)
            {
                result = memberList.Where(m => m.PersoCardMagnetic.PhysicalStatus == filter.CardPhysicalStatus).ToList();
            }
            else if (filter.FilterByCardLogicalStatus)
            {
                result = memberList.Where(m => m.PersoCardMagnetic.LogicalStatus == filter.CardLogicalStatus).ToList();
            }
            else
            {
                result = memberList;
            }
            return result;
        }

        #endregion

        #region Users

        public List<GroupDto> GetGroupList()
        {
            List<GroupDto> groupList = new List<GroupDto>();
            for (int i = 1; i <= 10; i++)
            {
                var group = new GroupDto()
                {
                    Id = i,
                    Name = string.Format("Nhom {0}", i),
                    Description = "",
                    Status = 1
                };
                groupList.Add(group);
            }
            return groupList;
        }

        public GroupCustomerDto GetGroupFunction()
        {
            return new GroupCustomerDto()
            {
                Id = 1,
                Name = "",
                Description = "",
                Functions = new List<long>()
                {
                    (long)Convert.ChangeType(Function.MOD_PERSO_MGT, typeof(long)),
                    (long)Convert.ChangeType(Function.FUNC_PERSO_VIEW, typeof(long)),
                    (long)Convert.ChangeType(Function.FUNC_PERSO_PERSO_CARD, typeof(long)),
                    (long)Convert.ChangeType(Function.MOD_CARD_MGT, typeof(long)),
                    (long)Convert.ChangeType(Function.FUNC_CARD_VIEW, typeof(long)),
                    (long)Convert.ChangeType(Function.FUNC_CARD_IMPORT, typeof(long)),
                    (long)Convert.ChangeType(Function.MOD_TOOLKIT, typeof(long)),
                    (long)Convert.ChangeType(Function.FUNC_TOOLKIT_READ_DATA, typeof(long)),
                }
            };
        }

        public List<User> GetUserList(int count = 10)
        {
            List<User> userList = new List<User>();
            for (int i = 1; i <= count; i++)
            {
                var group = new User()
                {
                    Id = i,
                    FirstName = "Chinh",
                    LastName = "Nguyen",
                    IsRoot = i == 1 ? true : false,
                    UserName = string.Format("user{0}", i),
                    Password = string.Format("pass{0}", i),
                    Status = 1
                };
                userList.Add(group);
            }
            return userList;
        }

        public User GetUserById(long userId)
        {
            return new User()
            {
                Id = userId,
                FirstName = "Chinh",
                LastName = "Nguyen",
                IsRoot = userId == 1 ? true : false,
                UserName = string.Format("user{0}", userId),
                Password = string.Format("pass{0}", userId),
                Status = 1
            };
        }

        #endregion

    }

    public class SystemCode
    {
        public const string MasterCode = @"&6h5Y8^JH;";
        public const string PartnerCode = @"JG&^%hut75";
    }
}
