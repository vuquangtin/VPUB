/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50527
Source Host           : localhost:3306
Source Database       : swordcore

Target Server Type    : MYSQL
Target Server Version : 50527
File Encoding         : 65001

Date: 2016-06-30 12:04:51
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `swtgp_ams_app`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_ams_app`;
CREATE TABLE `swtgp_ams_app` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Alias` tinyint(4) DEFAULT NULL,
  `AppCode` varchar(255) DEFAULT NULL,
  `CountModule` int(11) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `ModulesName` varchar(45) DEFAULT NULL,
  `NameApp` varchar(45) DEFAULT NULL,
  `StatusApp` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_ams_app
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_ams_cardchip_app`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_ams_cardchip_app`;
CREATE TABLE `swtgp_ams_cardchip_app` (
  `CardChipAppId` bigint(20) NOT NULL AUTO_INCREMENT,
  `AppCode` varchar(255) NOT NULL,
  `AppId` bigint(20) NOT NULL,
  `ChipPersoId` bigint(20) NOT NULL,
  `Data` varchar(255) NOT NULL,
  `LastMemberDataUpdatedOn` varchar(255) NOT NULL,
  `Rule` varchar(255) NOT NULL,
  `StartSector` varchar(255) NOT NULL,
  `Status` tinyint(4) DEFAULT NULL,
  `UserMaxSector` varchar(255) NOT NULL,
  PRIMARY KEY (`CardChipAppId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_ams_cardchip_app
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_ams_cardmagnetic_app`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_ams_cardmagnetic_app`;
CREATE TABLE `swtgp_ams_cardmagnetic_app` (
  `CardMagniteId` bigint(20) NOT NULL AUTO_INCREMENT,
  `AppCode` varchar(255) NOT NULL,
  `AppId` varchar(255) NOT NULL,
  `MagneticPersoId` varchar(255) NOT NULL,
  `Rule` varchar(255) NOT NULL,
  `Status` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`CardMagniteId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_ams_cardmagnetic_app
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_cms_acquirer`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_acquirer`;
CREATE TABLE `swtgp_cms_acquirer` (
  `AcquirerId` bigint(20) NOT NULL AUTO_INCREMENT,
  `AccessCode` varchar(45) DEFAULT NULL,
  `AcquierMasterCode` varchar(45) NOT NULL,
  `CreatedBy` varchar(45) DEFAULT NULL,
  `CreatedOn` varchar(45) DEFAULT NULL,
  `Desciption` varchar(255) DEFAULT NULL,
  `ModifiedBy` varchar(45) DEFAULT NULL,
  `ModifiedOn` varchar(45) DEFAULT NULL,
  `Rule` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`AcquirerId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_acquirer
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_cms_cardchip`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_cardchip`;
CREATE TABLE `swtgp_cms_cardchip` (
  `CardChipId` bigint(20) NOT NULL AUTO_INCREMENT,
  `CreatedBy` varchar(20) DEFAULT NULL,
  `CreatedOn` varchar(20) DEFAULT NULL,
  `LogicalStatus` int(11) DEFAULT NULL,
  `ModifyBy` varchar(20) DEFAULT NULL,
  `ModifyOn` varchar(20) DEFAULT NULL,
  `OrgMasterCode` varchar(10) DEFAULT NULL,
  `OrgMasterId` bigint(20) DEFAULT NULL,
  `OrgPartnerCode` varchar(10) DEFAULT NULL,
  `OrgPartnerId` bigint(20) DEFAULT NULL,
  `PhysicalStatus` int(11) DEFAULT NULL,
  `SerialNumberHex` varchar(100) NOT NULL,
  `TypeCard` int(11) DEFAULT NULL,
  `TypeCrypto` varchar(50) DEFAULT NULL,
  `headerposision` int(11) DEFAULT NULL,
  `licensemaster` longtext NOT NULL,
  `licensepartner` longtext,
  PRIMARY KEY (`CardChipId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_cardchip
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_cms_cardmagnetic`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_cardmagnetic`;
CREATE TABLE `swtgp_cms_cardmagnetic` (
  `MagneticId` bigint(20) NOT NULL AUTO_INCREMENT,
  `ActiveCode` varchar(10) DEFAULT NULL,
  `CardNumber` varchar(255) NOT NULL,
  `Company` varchar(255) DEFAULT NULL,
  `ExpireDate` varchar(10) DEFAULT NULL,
  `FullName` varchar(100) DEFAULT NULL,
  `MasterCode` varchar(255) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `OrgMasterId` bigint(20) DEFAULT NULL,
  `OrgPartnerId` bigint(20) DEFAULT NULL,
  `PartnerCode` varchar(255) DEFAULT NULL,
  `PhoneNumber` varchar(45) DEFAULT NULL,
  `PhysicalStatus` int(11) DEFAULT NULL,
  `PinCode` varchar(6) DEFAULT NULL,
  `PrefixCard` varchar(4) DEFAULT NULL,
  `PrintedStatus` int(11) DEFAULT NULL,
  `StartDate` varchar(10) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `SubOrgId` bigint(20) DEFAULT NULL,
  `TrackData` longtext,
  `TypeCrypto` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`MagneticId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_cardmagnetic
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_cms_cardtype`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_cardtype`;
CREATE TABLE `swtgp_cms_cardtype` (
  `CardTypeID` bigint(20) NOT NULL AUTO_INCREMENT,
  `CardHigh` varchar(23) DEFAULT NULL,
  `CardLow` varchar(23) DEFAULT NULL,
  `CardTypeName` varchar(20) DEFAULT NULL,
  `CreateOn` varchar(45) DEFAULT NULL,
  `CreatedBy` varchar(45) DEFAULT NULL,
  `ModifiedBy` varchar(45) DEFAULT NULL,
  `ModifiedOn` varchar(45) DEFAULT NULL,
  `OrgCode` varchar(10) NOT NULL,
  `OrgId` bigint(20) DEFAULT NULL,
  `PinLength` int(11) DEFAULT NULL,
  `Prefix` varchar(10) NOT NULL,
  `Status` bit(1) DEFAULT NULL,
  PRIMARY KEY (`CardTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_cardtype
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_cms_organization`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_organization`;
CREATE TABLE `swtgp_cms_organization` (
  `OrgId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Address` varchar(50) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `ContactEmail` varchar(45) DEFAULT NULL,
  `ContactMobile` varchar(45) DEFAULT NULL,
  `ContactName` varchar(45) DEFAULT NULL,
  `ContactPhone` varchar(45) DEFAULT NULL,
  `CountryCode` varchar(45) DEFAULT NULL,
  `CreatedBy` varchar(45) DEFAULT NULL,
  `CreatedOn` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Fax` varchar(45) DEFAULT NULL,
  `Issuer` varchar(100) DEFAULT NULL,
  `ModifiedBy` varchar(45) DEFAULT NULL,
  `ModifiedOn` varchar(45) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `OrgCode` varchar(50) DEFAULT NULL,
  `OrgShortName` varchar(10) DEFAULT NULL,
  `Phone` varchar(45) DEFAULT NULL,
  `SettlementEmail` varchar(45) DEFAULT NULL,
  `SettlementFrequency` varchar(45) DEFAULT NULL,
  `State` varchar(45) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `WebSite` varchar(45) DEFAULT NULL,
  `ZipCode` varchar(45) DEFAULT NULL,
  `SecretKeyId` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`OrgId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_organization
-- ----------------------------
INSERT INTO swtgp_cms_organization VALUES ('1', '10 Luong Dinh Cua, Q.2', 'HCM', 'support@smartworld.com', '08 889900', 'Smart card', '08 889900', '+84', 'smartworld', null, 'support@smartworld.com', null, 'MASTER', null, null, 'Smart world', null, '0000', 'Smart worl', null, null, null, null, '1', null, null, '1');

-- ----------------------------
-- Table structure for `swtgp_cms_partners`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_partners`;
CREATE TABLE `swtgp_cms_partners` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `mastercode` varchar(255) DEFAULT NULL,
  `masterid` bigint(20) DEFAULT NULL,
  `partnercode` varchar(255) DEFAULT NULL,
  `partnerid` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_partners
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_cms_suborganization`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_cms_suborganization`;
CREATE TABLE `swtgp_cms_suborganization` (
  `suborgid` bigint(20) NOT NULL AUTO_INCREMENT,
  `state` varchar(45) DEFAULT NULL,
  `SwtGroup` varchar(50) DEFAULT NULL,
  `address` longtext,
  `city` varchar(45) DEFAULT NULL,
  `contactemail` varchar(45) DEFAULT NULL,
  `contactname` varchar(45) DEFAULT NULL,
  `contactphone` varchar(45) DEFAULT NULL,
  `countrycode` varchar(20) DEFAULT NULL,
  `createdby` varchar(20) DEFAULT NULL,
  `createdon` varchar(20) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `fax` varchar(45) DEFAULT NULL,
  `modifiedby` varchar(20) DEFAULT NULL,
  `modifiedon` varchar(20) DEFAULT NULL,
  `names` varchar(250) DEFAULT NULL,
  `notes` varchar(45) DEFAULT NULL,
  `orgcode` varchar(45) NOT NULL,
  `orgid` bigint(20) NOT NULL,
  `orgshortname` varchar(45) NOT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `settlementemail` varchar(45) DEFAULT NULL,
  `shortname` varchar(250) DEFAULT NULL,
  `status` int(11) DEFAULT NULL,
  `transferDate` varchar(30) DEFAULT NULL,
  `website` varchar(45) DEFAULT NULL,
  `zipcode` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`suborgid`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_cms_suborganization
-- ----------------------------
INSERT INTO swtgp_cms_suborganization VALUES ('1', 'Viet Nam', null, '10 Luong Dinh Cua', 'HCM', 'support@smartworld.com', 'smart card', '08 889900', '+84', 'smartworld', null, 'support@smartworld.com', null, null, null, 'Smart world', null, '0000', '1', '', null, null, 'Yescard', '1', null, null, null);

-- ----------------------------
-- Table structure for `swtgp_config`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_config`;
CREATE TABLE `swtgp_config` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Name` varchar(40) NOT NULL,
  `Value` longtext NOT NULL,
  `status` int(11) DEFAULT '0',
  `updateddate` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_config
-- ----------------------------
INSERT INTO swtgp_config VALUES ('1', 'sworld_mobile_center', '1|2', '1', null);
INSERT INTO swtgp_config VALUES ('2', 'auto_add_default_suborg', 'true', '1', null);
INSERT INTO swtgp_config VALUES ('3', 'key_active', '1', '1', null);
INSERT INTO swtgp_config VALUES ('4', 'key_a_sector_active', '2525132530061989', '1', null);
INSERT INTO swtgp_config VALUES ('5', 'key_b_sactor_active', '3006198930061989', '1', null);
INSERT INTO swtgp_config VALUES ('6', 'key_value1_sector', '3107198930061989', '1', null);
INSERT INTO swtgp_config VALUES ('7', 'mobile_member_card', '1', '1', null);
INSERT INTO swtgp_config VALUES ('8', 'duration_mobile_card', '12', '1', null);
INSERT INTO swtgp_config VALUES ('9', 'qacode_prefix', 'SWT', '1', null);
INSERT INTO swtgp_config VALUES ('10', 'barcode_prefix', '0909', '1', null);
INSERT INTO swtgp_config VALUES ('11', 'serial_prefix', '009', '1', null);
INSERT INTO swtgp_config VALUES ('12', 'yescard_mobile_content', 'yes card', '1', null);
INSERT INTO swtgp_config VALUES ('13', 'sworld_mobile_center', '1|2', '1', null);
INSERT INTO swtgp_config VALUES ('14', 'auto_add_default_suborg', 'true', '1', null);
INSERT INTO swtgp_config VALUES ('15', 'key_active', '1', '1', null);
INSERT INTO swtgp_config VALUES ('16', 'key_a_sector_active', '2525132530061989', '1', null);
INSERT INTO swtgp_config VALUES ('17', 'key_b_sactor_active', '3006198930061989', '1', null);
INSERT INTO swtgp_config VALUES ('18', 'key_value1_sector', '3107198930061989', '1', null);
INSERT INTO swtgp_config VALUES ('19', 'mobile_member_card', '1', '1', null);
INSERT INTO swtgp_config VALUES ('20', 'duration_mobile_card', '12', '1', null);
INSERT INTO swtgp_config VALUES ('21', 'qacode_prefix', 'SWT', '1', null);
INSERT INTO swtgp_config VALUES ('22', 'barcode_prefix', '0909', '1', null);
INSERT INTO swtgp_config VALUES ('23', 'serial_prefix', '009', '1', null);
INSERT INTO swtgp_config VALUES ('24', 'yescard_mobile_content', 'yes card', '1', null);
INSERT INTO swtgp_config VALUES ('25', 'sworld_mobile_center', '1|2', '1', null);
INSERT INTO swtgp_config VALUES ('26', 'auto_add_default_suborg', 'true', '1', null);
INSERT INTO swtgp_config VALUES ('27', 'key_active', '1', '1', null);
INSERT INTO swtgp_config VALUES ('28', 'key_a_sector_active', '2525132530061989', '1', null);
INSERT INTO swtgp_config VALUES ('29', 'key_b_sactor_active', '3006198930061989', '1', null);
INSERT INTO swtgp_config VALUES ('30', 'key_value1_sector', '3107198930061989', '1', null);
INSERT INTO swtgp_config VALUES ('31', 'mobile_member_card', '1', '1', null);
INSERT INTO swtgp_config VALUES ('32', 'duration_mobile_card', '12', '1', null);
INSERT INTO swtgp_config VALUES ('33', 'qacode_prefix', 'SWT', '1', null);
INSERT INTO swtgp_config VALUES ('34', 'barcode_prefix', '0909', '1', null);
INSERT INTO swtgp_config VALUES ('35', 'serial_prefix', '009', '1', null);
INSERT INTO swtgp_config VALUES ('36', 'yescard_mobile_content', 'yes card', '1', null);

-- ----------------------------
-- Table structure for `swtgp_group_user`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_group_user`;
CREATE TABLE `swtgp_group_user` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `description` text,
  `isadmin` int(11) DEFAULT '0',
  `name` varchar(255) NOT NULL,
  `permission` varchar(500) DEFAULT NULL,
  `role` int(11) DEFAULT '0',
  `status` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_group_user
-- ----------------------------
INSERT INTO swtgp_group_user VALUES ('1', null, '1', 'Smart world supper admin', 'swtsupper', '1', '1');
INSERT INTO swtgp_group_user VALUES ('2', null, '1', 'Smart world admin user', 'swtadmin', '2', '1');
INSERT INTO swtgp_group_user VALUES ('3', null, '0', 'Smart world normal user', 'swtnormal', '3', '1');
INSERT INTO swtgp_group_user VALUES ('4', null, '1', 'Merchant supper user', 'merchantsupper', '4', '1');
INSERT INTO swtgp_group_user VALUES ('5', null, '1', 'Merchant admin user', 'merchantadmin', '5', '1');
INSERT INTO swtgp_group_user VALUES ('6', null, '0', 'Merchant user', 'merchantuser', '6', '1');
INSERT INTO swtgp_group_user VALUES ('7', null, '0', 'Guest user', 'guestuser', '7', '1');

-- ----------------------------
-- Table structure for `swtgp_kms_secret_key`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_kms_secret_key`;
CREATE TABLE `swtgp_kms_secret_key` (
  `SecretKeyId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Alias` bigint(20) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `HsmId` bigint(20) NOT NULL,
  `KeyADM` longtext,
  `KeyBDM` longtext,
  `KeyBHM` longtext,
  `KeyValue` longtext,
  `Name` varchar(255) DEFAULT NULL,
  `PriKeyLicense` longtext,
  `PriKeyServer` longtext,
  `PubKeyLicense` longtext,
  `PubKeyServer` longtext,
  `Status` bit(1) DEFAULT NULL,
  `Owner` int(11) DEFAULT NULL,
  PRIMARY KEY (`SecretKeyId`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_kms_secret_key
-- ----------------------------
INSERT INTO swtgp_kms_secret_key VALUES ('1', '0', '', '1', '0901093093', '0901093093', '0901093093', '0901093093', 'swt key', '09010930930901093093', '10901093093090109309309010930909010930933', '0901093093990901093093990901093093', '0901093093990901093093990901093093', '', '1');

-- ----------------------------
-- Table structure for `swtgp_login_history`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_login_history`;
CREATE TABLE `swtgp_login_history` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `FailedCode` int(11) NOT NULL,
  `LoginTime` varchar(45) NOT NULL,
  `LogoutTime` varchar(45) DEFAULT NULL,
  `Result` bit(1) NOT NULL,
  `UserName` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_login_history
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_mobile_rulevourcher`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_mobile_rulevourcher`;
CREATE TABLE `swtgp_mobile_rulevourcher` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `area` varchar(255) DEFAULT NULL,
  `dateBegin` varchar(255) DEFAULT NULL,
  `dateBeginJoin` varchar(255) DEFAULT NULL,
  `dateEnd` varchar(255) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `gender` int(11) DEFAULT NULL,
  `orgId` bigint(20) NOT NULL,
  `status` int(11) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `type` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_mobile_rulevourcher
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_policy`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_policy`;
CREATE TABLE `swtgp_policy` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `AppId` bigint(20) DEFAULT NULL,
  `Deleted` int(11) DEFAULT '0',
  `Descriptions` varchar(255) DEFAULT NULL,
  `GroupId` bigint(20) DEFAULT NULL,
  `Inserted` int(11) DEFAULT '0',
  `Modified` int(11) DEFAULT '0',
  `ModuleId` bigint(20) DEFAULT NULL,
  `Viewer` int(11) DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_policy
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_ps_chip_personalization`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_ps_chip_personalization`;
CREATE TABLE `swtgp_ps_chip_personalization` (
  `ChipPersoId` bigint(20) NOT NULL AUTO_INCREMENT,
  `Active` int(11) DEFAULT '0',
  `CardChipId` bigint(20) NOT NULL,
  `CreatedBy` varchar(255) DEFAULT NULL,
  `CreatedOn` varchar(20) DEFAULT NULL,
  `Data` varchar(255) DEFAULT NULL,
  `ExpirationDate` varchar(20) DEFAULT NULL,
  `ModifiedBy` varchar(255) DEFAULT NULL,
  `ModifiedOn` varchar(255) NOT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `PersoDate` varchar(20) NOT NULL,
  `PsMemberId` bigint(20) NOT NULL,
  `SerialNumber` varchar(255) DEFAULT NULL,
  `Temp1` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ChipPersoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_ps_chip_personalization
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_ps_magnetic_personalization`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_ps_magnetic_personalization`;
CREATE TABLE `swtgp_ps_magnetic_personalization` (
  `MagneticPersId` bigint(20) NOT NULL AUTO_INCREMENT,
  `ActiveCodeNew` varchar(255) DEFAULT NULL,
  `CardMagneticId` bigint(20) NOT NULL,
  `CompayName` varchar(255) DEFAULT NULL,
  `ExpirationDate` varchar(255) DEFAULT NULL,
  `FullName` varchar(100) DEFAULT NULL,
  `MemberId` bigint(20) DEFAULT NULL,
  `Notes` varchar(255) DEFAULT NULL,
  `PersoDate` varchar(255) DEFAULT NULL,
  `PhoneNumber` varchar(255) DEFAULT NULL,
  `PinCodeNew` varchar(255) DEFAULT NULL,
  `PreFix` varchar(5) DEFAULT NULL,
  `SerialCard` varchar(45) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `TrackData` longtext,
  `ActivePinCodeNew` varchar(10) DEFAULT NULL,
  `Company` varchar(255) DEFAULT NULL,
  `ExpireDate` varchar(10) DEFAULT NULL,
  `StartDate` varchar(10) DEFAULT NULL,
  `Track1Data` varchar(255) NOT NULL,
  `Track2Data` varchar(255) DEFAULT NULL,
  `Track3Data` varchar(107) DEFAULT NULL,
  `TypeCrypto` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`MagneticPersId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_ps_magnetic_personalization
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_ps_member`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_ps_member`;
CREATE TABLE `swtgp_ps_member` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Active` bit(1) DEFAULT NULL,
  `BirthDate` varchar(20) DEFAULT NULL,
  `Code` varchar(255) DEFAULT NULL,
  `Companyname` varchar(255) DEFAULT NULL,
  `ContactAddress` varchar(255) DEFAULT NULL,
  `ContactEmail` varchar(255) DEFAULT NULL,
  `ContactName` varchar(255) DEFAULT NULL,
  `ContactPhone` varchar(255) DEFAULT NULL,
  `CreatedDate` varchar(20) DEFAULT NULL,
  `Degree` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `FirstName` varchar(255) DEFAULT NULL,
  `Gender` int(11) DEFAULT NULL,
  `HashCode` varchar(255) DEFAULT NULL,
  `IdentityCard` varchar(20) DEFAULT NULL,
  `IdentityCardIssue` varchar(255) DEFAULT NULL,
  `IdentityCardIssueDate` varchar(30) DEFAULT NULL,
  `ImagePath` varchar(255) DEFAULT NULL,
  `LastName` varchar(255) DEFAULT NULL,
  `LowerFullName` varchar(255) DEFAULT NULL,
  `ModifiedDate` varchar(20) DEFAULT NULL,
  `Nationality` varchar(255) DEFAULT NULL,
  `OrgCode` varchar(10) DEFAULT NULL,
  `OrgID` bigint(20) DEFAULT NULL,
  `PermanentAddress` varchar(255) DEFAULT NULL,
  `PhoneNo` varchar(255) DEFAULT NULL,
  `Position` varchar(255) DEFAULT NULL,
  `SubOrgId` bigint(20) DEFAULT NULL,
  `TemporaryAddress` varchar(255) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_ps_member
-- ----------------------------

-- ----------------------------
-- Table structure for `swtgp_user`
-- ----------------------------
DROP TABLE IF EXISTS `swtgp_user`;
CREATE TABLE `swtgp_user` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `BirthDate` varchar(40) DEFAULT NULL,
  `Email` varchar(40) DEFAULT NULL,
  `FirstName` varchar(40) DEFAULT NULL,
  `Gender` varchar(40) DEFAULT NULL,
  `GroupId` bigint(20) NOT NULL,
  `IdCardIssuedDate` varchar(40) DEFAULT NULL,
  `IdCardIssuedPlace` varchar(40) DEFAULT NULL,
  `IdCardNo` varchar(40) DEFAULT NULL,
  `IsRoot` bit(1) DEFAULT NULL,
  `LastName` varchar(40) DEFAULT NULL,
  `Nationality` varchar(100) DEFAULT NULL,
  `PasswordHash` varchar(255) DEFAULT NULL,
  `PermanentAddress` varchar(200) DEFAULT NULL,
  `PhoneNo` varchar(40) DEFAULT NULL,
  `Status` int(11) NOT NULL,
  `TemporaryAddress` varchar(200) DEFAULT NULL,
  `UserName` varchar(255) NOT NULL,
  `Code` varchar(50) DEFAULT NULL,
  `DateCreated` varchar(25) DEFAULT NULL,
  `DateUpdated` varchar(25) DEFAULT NULL,
  `Ip` varchar(25) DEFAULT NULL,
  `LocalCode` varchar(25) DEFAULT NULL,
  `memberid` int(11) DEFAULT '0',
  `OrgId` int(11) DEFAULT '0',
  `Salt` varchar(100) DEFAULT NULL,
  `date_created` varchar(25) DEFAULT NULL,
  `date_updated` varchar(25) DEFAULT NULL,
  `local_code` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swtgp_user
-- ----------------------------
INSERT INTO swtgp_user VALUES ('1', '10/04/2014', 'support@smartworld.com', 'support', '1', '1', '10/04/2014', 'sworld office', null, '', 'swt', 'Viet Nam', '1', 'smartworld temp', null, '1', 'sworld address temp', 'swtsupper', '001', '10/04/2014', '10/04/2014', 'localhost', 'swtsupper', '0', '0', 'admin', null, null, null);
INSERT INTO swtgp_user VALUES ('2', '10/04/2014', 'support@smartworld.com', 'support', '1', '2', '10/04/2014', 'sworld office', null, '', 'swt admin', 'Viet Nam', '1', 'smartworld temp', null, '1', 'sworld address temp', 'swtadmin', '002', '10/04/2014', '10/04/2014', 'localhost', 'swtcodeadmin', '0', '0', 'test', null, null, null);

-- ----------------------------
-- Table structure for `swt_ams_personalization_app`
-- ----------------------------
DROP TABLE IF EXISTS `swt_ams_personalization_app`;
CREATE TABLE `swt_ams_personalization_app` (
  `Id` bigint(20) NOT NULL AUTO_INCREMENT,
  `AppId` bigint(20) NOT NULL,
  `AppMasterKeyId` int(11) DEFAULT NULL,
  `LastMemberDataUpdatedOn` varchar(255) NOT NULL,
  `MaxSectorUsed` int(11) NOT NULL,
  `PersoId` bigint(20) NOT NULL,
  `StartSectorNumber` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swt_ams_personalization_app
-- ----------------------------

-- ----------------------------
-- Table structure for `swt_ps_personalization`
-- ----------------------------
DROP TABLE IF EXISTS `swt_ps_personalization`;
CREATE TABLE `swt_ps_personalization` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CardId` int(11) DEFAULT NULL,
  `CardType` int(11) DEFAULT NULL,
  `ExpirationDate` date DEFAULT NULL,
  `MemberId` int(11) NOT NULL,
  `Notes` text,
  `PersoDate` date NOT NULL,
  `Status` int(11) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of swt_ps_personalization
-- ----------------------------
