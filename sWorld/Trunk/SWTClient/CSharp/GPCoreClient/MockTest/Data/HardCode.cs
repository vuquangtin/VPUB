using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace MockTest.Data
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

        #region Properties

        private readonly string DEFAULT_KEY = "ffffffffffff";
        private readonly string KEYA = "fffAAfffffAA";

        #endregion

        #region Authentication

        public List<PolicySworld> LoadPermissionList()
        {
            List<PolicySworld> permissions = new List<PolicySworld>();
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
                MasterId = 9999,
                OrgShortName = @"SWT",
                Name = @"Smart World Technology",
                key = new KeyDTO()
                {
                    Id = 1,
                    KeyValue = "%tB&1oH*54jh^04k<%ikD48?2Mnb>Cf0",
                    //Key = new SectorKeyPairDTO()
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
                    PartnerId = i + 1,
                    OrgShortName = string.Format("TN{0}", i + 1),
                    Name = partnerNames[i],
                    key = new KeyDTO()
                    {
                        Id = 1,
                        KeyValue = "%tB&1oH*54jh^04k<%ikD48?2Mnb>Cf0",
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

        #region Application

        public List<App> GetAppDataList()
        {
            List<App> appList = new List<App>();

            for (int i = 1; i <= 10; i++)
            {
                var app = new App()
                {
                    Id = i,
                    AppCode = string.Format("UD{0}", i),
                    NameApp = string.Format("Ứng Dụng {0}", i),
                    Description = string.Format("Mô Tả Ứng Dụng", i)
                };
                appList.Add(app);
            }

            return appList;
        }

        #endregion

        #region PersoCardChip

        public ResultCheckCardDTO CheckAndGetMasterDataToImportCard(byte start, byte stop)
        {
            List<KeyDTO> keyPairList = new List<KeyDTO>();

            for (byte sector = start; sector < stop + 1; sector++)
            {
                SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
                keyPair.KeyA = DEFAULT_KEY;
                keyPair.KeyB = DEFAULT_KEY;
                keyPairList.Add(new KeyDTO()
                {
                    Alias = sector,
                    Key = keyPair,
                    Id = 1,
                    KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
                });
            }
            ResultCheckCardDTO checkCard = new ResultCheckCardDTO()
            {
                HMK_ALIAS = 1,
                DMKA_ALIAS = 1,
                DMKB_ALIAS = 1,
                License = "2077548e830d2faacfe6d0c8a985a7ef260bc2270c3a64771d9336c6a59d7ff6dd1331b5f665d121321c66957cc2c767afbf6f17e4c5b74ed806aee579ad26d7ad03ef08b053a0f2e443cb57d3e3e89162a27244aa814875a83ba5acbecab5d5ba4c5bf3025a679bdf5b4d4be7f62e8fa3834582f262465e43cb6f8d08dc71dd",
                LicenseServer = "7fd5868f2811225b47df9f982b8cd7b0b5712481de1803045a94ea9e0713eccadef7df408f979a8a6238dfb0857c796dfa3c1884cc8defe200bcb09733c99a4d971f33567aba742b3dfb54cf062976a1c69c776e703738fff16676a46a0683e9dcb4017ead8dfa90d98dcc0236b1588b7d4bcd8f160a166bce4ad048e7561328",
                PVK_ALIAS = 0,
                Status = 100,
                KEY = keyPairList,
            };

            return checkCard;
        }

        public DataToReadCardDTO GetKeyForWriteCard(List<int> listSector)
        {
            List<KeyDTO> keyPairList = new List<KeyDTO>();

            foreach (int index in listSector)
            {
                SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
                keyPair.KeyA = KEYA;
                keyPair.KeyB = DEFAULT_KEY;
                keyPairList.Add(new KeyDTO()
                {
                    Alias = (byte)index,
                    Key = keyPair,
                    Id = 1,
                    KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
                });
            }
            DataToReadCardDTO checkCard = new DataToReadCardDTO()
            {
                KEY = keyPairList,
                LicenseServer = "7fd5868f2811225b47df9f982b8cd7b0b5712481de1803045a94ea9e0713eccadef7df408f979a8a6238dfb0857c796dfa3c1884cc8defe200bcb09733c99a4d971f33567aba742b3dfb54cf062976a1c69c776e703738fff16676a46a0683e9dcb4017ead8dfa90d98dcc0236b1588b7d4bcd8f160a166bce4ad048e7561328",
            };

            return checkCard;
        }

        public DataToWriteCardDTO CheckAndGetAppDataToPersoCard(byte sectorData)
        {
            int MaxSectorUseds = 0;
            DataToWriteCardDTO data = new DataToWriteCardDTO();
            //System.Text.UTF8Encoding encoding=new System.Text.UTF8Encoding();
            data.Data = "Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có";

            MaxSectorUseds = data.Data.Length / 48;
            MaxSectorUseds += data.Data.Length % 48 == 0 ? 0 : 1;

            List<KeyDTO> keyPairList = new List<KeyDTO>();
            keyPairList.Add(new KeyDTO()
            {

                Alias = 3,
                Key = new SectorKeyPairDTO() { KeyA = DEFAULT_KEY, KeyB = DEFAULT_KEY },
                Id = 1,
                KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
            });
            for (byte i = 0; i < MaxSectorUseds; i++)
            {
                SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
                keyPair.KeyA = i % 2 == 0 ? DEFAULT_KEY : KEYA;
                keyPair.KeyB = DEFAULT_KEY;
                keyPairList.Add(new KeyDTO()
                {
                    Alias = sectorData++,
                    Key = keyPair,
                    Id = 1,
                    KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
                });
            }
            data.KEY = keyPairList;

            return data;
        }

        public DataToWriteCardDTO CheckAndGetAppDataToClearCard(byte sectorBegin, byte sectorEnd)
        {
            DataToWriteCardDTO data = new DataToWriteCardDTO();

            List<KeyDTO> keyPairList = new List<KeyDTO>();
            keyPairList.Add(new KeyDTO()
            {

                Alias = 3,
                Key = new SectorKeyPairDTO() { KeyA = DEFAULT_KEY, KeyB = DEFAULT_KEY },
                Id = 1,
                KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
            });
            for (byte i = sectorBegin; i < sectorEnd; i++)
            {
                SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
                keyPair.KeyA = i % 2 == 0 ? DEFAULT_KEY : KEYA;
                keyPair.KeyB = DEFAULT_KEY;
                keyPairList.Add(new KeyDTO()
                {
                    Alias = sectorBegin++,
                    Key = keyPair,
                    Id = 1,
                    KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
                });
            }
            data.KEY = keyPairList;

            return data;
        }

        public DataToWriteCardDTO GetDataToReadCard(byte sectorData)
        {
            int MaxSectorUseds = 0;
            DataToWriteCardDTO data = new DataToWriteCardDTO();
            //System.Text.UTF8Encoding encoding=new System.Text.UTF8Encoding();
            data.Data = "Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có";

            MaxSectorUseds = data.Data.Length / 48;
            MaxSectorUseds += data.Data.Length % 48 == 0 ? 0 : 1;

            List<KeyDTO> keyPairList = new List<KeyDTO>();
            //KeyB cua header
            keyPairList.Add(new KeyDTO()
            {

                Alias = 3,
                Key = new SectorKeyPairDTO() { KeyA = DEFAULT_KEY, KeyB = DEFAULT_KEY },
                Id = 1,
                KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
            });

            for (byte i = 0; i < MaxSectorUseds; i++)
            {
                SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
                keyPair.KeyA = i % 2 == 0 ? DEFAULT_KEY : KEYA;
                keyPair.KeyB = DEFAULT_KEY;
                keyPairList.Add(new KeyDTO()
                {
                    Alias = sectorData++,
                    Key = keyPair,
                    Id = 1,
                    KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
                });
            }
            data.KEY = keyPairList;

            return data;
        }


        public DataToWriteCardDTO GetDataToUpdateCard(byte sectorData)
        {
            int MaxSectorUseds = 0;
            DataToWriteCardDTO data = new DataToWriteCardDTO();
            //System.Text.UTF8Encoding encoding=new System.Text.UTF8Encoding();
            data.Data = "Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.Cố ý tìm không, không mà có - Vô tâm tìm có, có như không.";

            MaxSectorUseds = data.Data.Length / 48;
            MaxSectorUseds += data.Data.Length % 48 == 0 ? 0 : 1;

            List<KeyDTO> keyPairList = new List<KeyDTO>();
            //KeyB cua header
            keyPairList.Add(new KeyDTO()
            {

                Alias = 3,
                Key = new SectorKeyPairDTO() { KeyA = DEFAULT_KEY, KeyB = DEFAULT_KEY },
                Id = 1,
                KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
            });

            for (byte i = 0; i < MaxSectorUseds; i++)
            {
                SectorKeyPairDTO keyPair = new SectorKeyPairDTO();
                keyPair.KeyA = i % 2 == 0 ? DEFAULT_KEY : KEYA;
                keyPair.KeyB = DEFAULT_KEY;
                keyPairList.Add(new KeyDTO()
                {
                    Alias = sectorData++,
                    Key = keyPair,
                    Id = 1,
                    KeyValue = "30819f300d06092a864886f70d010101050003818d0030818902818100be2bcb86c423336502c33b5ccb12b50cb0b077fa2abc945e41d159261ba1f9b2c4d113092109dcdad577c134245fdcd9825d990c2e8309b9e849cb1aebf303bcf0a61d5781a2063e0f39d6943d0906bb84965535d8d6a59b05e121bfdbc7999ebe99b"
                });
            }
            data.KEY = keyPairList;

            return data;
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

        //public List<CMSCardmagneticDto> GetCardMagneticList()
        //{
        //    List<CMSCardmagneticDto> memberList = new List<CMSCardmagneticDto>();
        //    for (int i = 1; i <= 100; i++)
        //    {
        //        var subOrg = new CMSCardmagneticDto()
        //        {
        //            MagneticId = 1,
        //            OrgMasterId = 2,
        //            OrgPartnerId = 3,
        //            CardNumber = "5555",
        //        };
        //        memberList.Add(subOrg);
        //    }
        //    return memberList;
        //}

        public List<CardStatisticsData> StatisticCardByPhysicalStatus()
        {
            List<CardStatisticsData> statisticByPhysical = new List<CardStatisticsData>();
            for (int i = 1; i <= 6; i++)
            {
                var statis = new CardStatisticsData()
                {
                    Status = i,
                    Amount = 20,
                };


                statisticByPhysical.Add(statis);
            }
            return statisticByPhysical;
        }

        public List<CardStatisticsData> StatisticCardByLogicalStatus()
        {
            List<CardStatisticsData> statisticByLogical = new List<CardStatisticsData>();
            for (int i = 1; i <= 5; i++)
            {
                var statis = new CardStatisticsData()
                {
                    Status = i,
                    Amount = 20,
                };


                statisticByLogical.Add(statis);
            }
            return statisticByLogical;
        }

        #endregion

        #region Quan ly vong doi the Chip

        public List<SubOrgCustomerDTO> GetSubOrgList(long orgId)
        {
            if (orgId <= 0)
            {
                return new List<SubOrgCustomerDTO>();
            }
            List<SubOrgCustomerDTO> subOrgList = new List<SubOrgCustomerDTO>();
            for (int i = 1; i <= 10; i++)
            {
                var subOrg = new SubOrgCustomerDTO()
                {
                    OrgId = orgId,
                    SubOrgId = i,
                    OrgShortName = string.Format("PB {0}", i),
                    Name = string.Format("Phong ban {0}", i),
                };
                subOrgList.Add(subOrg);
            }
            return subOrgList;
        }

        public List<MemberCustomerDTO> GetMemberPersoChipList(long orgId, long subOrgId)
        {
            List<MemberCustomerDTO> memberList = new List<MemberCustomerDTO>();
            for (int i = 1; i <= 100; i++)
            {
                var subOrg = new MemberCustomerDTO()
                {
                    Member = new Member()
                    {
                        Id = i,
                        OrgId = orgId,
                        SubOrgId = subOrgId,
                        FirstName = "Nguyen Cong",
                        LastName = "Chinh",
                        BirthDate = DateTime.Now.AddYears(-24).ToShortDateString(),
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

        public List<MemberCustomerDTO> GetMemberChipList(long orgId, long subOrgId)
        {
            List<MemberCustomerDTO> memberList = new List<MemberCustomerDTO>();
            for (int i = 1; i <= 100; i++)
            {
                var subOrg = new MemberCustomerDTO()
                {
                    Member = new Member()
                    {
                        Id = i,
                        OrgId = orgId,
                        SubOrgId = subOrgId,
                        FirstName = "Nguyen Cong",
                        LastName = "Chinh",
                        BirthDate = DateTime.Now.AddYears(-24).ToShortDateString(),
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

        public List<MemberMagneticPersoDTO> GetMemberMagneticList(CardMagneticFilterDto filter, int Skip, int Take, int TotalRecords)
        {
            List<MemberMagneticPersoDTO> memberList = new List<MemberMagneticPersoDTO>();
            List<MemberMagneticPersoDTO> result = new List<MemberMagneticPersoDTO>();
            //for (int i = 1; i <= 1000; i++)
            //{
            //    var subOrg = new MemberMagneticPersoDTO()
            //    {
            //        Member = new Member()
            //        {
            //            Id = i,
            //            FirstName = "Hóa",
            //            LastName = "Phan",
            //            BirthDate = DateTime.Now.AddYears(-24).ToShortDateString(),
            //            PermanentAddress = "4a nguyen van b",
            //            TemporaryAddress = "4a nguyen van bcbxmbm",
            //            PhoneNo = "0123456789",
            //            Email = "hoa.phan@smartworld.com.vn",
            //        },
            //        PersoCardMagnetic = new MagneticPersonalizationDTO()
            //        {
            //            CardMagneticId = i,
            //            //MagneticId = i,
            //            SerialCard = "8C19D257",
            //            PersoDate = DateTime.Now.ToShortDateString(),
            //            ExpirationDate = DateTime.Now.AddYears(1).ToShortDateString(),
            //            PhysicalStatus = i < 25 ? 1 : i < 50 ? 2 : 3,
            //          //  LogicalStatus = i < 25 ? 1 : i < 50 ? 2 : 3,
            //            // Skip = 100,
            //            // Take = 500,
            //            // TotalRecords = 1000,
            //            //  Status = 2,
            //        }
            //    };
            //    memberList.Add(subOrg);
            //}

            //if (filter.FilterByCardPhysicalStatus)
            //{
            //    result = memberList.Where(m => m.PersoCardMagnetic.PhysicalStatus == filter.CardPhysicalStatus).ToList();
            //}
            ////else if (filter.FilterByCardLogicalStatus)
            ////{
            ////    result = memberList.Where(m => m.PersoCardMagnetic.LogicalStatus == filter.CardLogicalStatus).ToList();
            ////}
            //else
            //{
            //    result = memberList;
            //}
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
                PolicySworlds = new List<PolicySworld>()
                {
                    //(long)Convert.ChangeType(Function.MOD_PERSO_MGT, typeof(long)),
                    //(long)Convert.ChangeType(Function.FUNC_PERSO_VIEW, typeof(long)),
                    //(long)Convert.ChangeType(Function.FUNC_PERSO_PERSO_CARD, typeof(long)),
                    //(long)Convert.ChangeType(Function.MOD_CARD_MGT, typeof(long)),
                    //(long)Convert.ChangeType(Function.FUNC_CARD_VIEW, typeof(long)),
                    //(long)Convert.ChangeType(Function.FUNC_CARD_IMPORT, typeof(long)),
                    //(long)Convert.ChangeType(Function.MOD_TOOLKIT, typeof(long)),
                    //(long)Convert.ChangeType(Function.FUNC_TOOLKIT_READ_DATA, typeof(long)),
                }
            };
        }

        public List<UserSworld> GetUserList(int count = 10)
        {
            List<UserSworld> userList = new List<UserSworld>();
            for (int i = 1; i <= count; i++)
            {
                UserSworld user = new UserSworld()
                {
                    id = i,
                    FirstName = "Chinh",
                    LastName = "Nguyen",
                    IsRoot = i == 1 ? true : false,
                    UserName = string.Format("user{0}", i),
                    PasswordHash = string.Format("pass{0}", i),
                    Status = 1
                };
                userList.Add(user);
            }
            return userList;
        }

        public UserSworld GetUserById(long userId)
        {
            return new UserSworld()
            {
                id = userId,
                FirstName = "Chinh",
                LastName = "Nguyen",
                IsRoot = userId == 1 ? true : false,
                UserName = string.Format("user{0}", userId),
                PasswordHash = string.Format("pass{0}", userId),
                Status = 1
            };
        }

        #endregion

        #region Quan Lý Org

        public List<OrgCustomerDto> GetOrgList()
        {
            List<OrgCustomerDto> result = new List<OrgCustomerDto>();

            for (int i = 1; i < 10; i++)
            {
                OrgCustomerDto org = new OrgCustomerDto()
                {
                    OrgId = i,
                    Name = string.Format("Tổ Chức {0}", i),
                    SubOrgList = new List<SubOrgCustomerDTO>(),
                };
                for (int k = 1; k < 10; k++)
                {
                    SubOrgCustomerDTO subOrg = new SubOrgCustomerDTO()
                    {
                        SubOrgId = k,
                        Name = string.Format("Tổ Chức Con {0}", k),
                    };
                    org.SubOrgList.Add(subOrg);
                }
                result.Add(org);
            }

            return result;
        }

        #endregion

    }

    public class SystemCode
    {
        public const string MasterCode = @"&6h5Y8^JH;";
        public const string PartnerCode = @"JG&^%hut75";
    }
}
