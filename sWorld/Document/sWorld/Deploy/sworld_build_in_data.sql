-- --------------------------------------------------------------------
-- Records of  swtgp_config
-- --------------------------------------------------------------------
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`) VALUES ('sworld_mobile_center', '1|2', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('auto_add_default_suborg', 'true', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('key_active', '1', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('key_a_sector_active', '2525132530061989', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('key_b_sactor_active', '3006198930061989', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('key_value1_sector', '3107198930061989', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('mobile_member_card', '1', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('duration_mobile_card', '12', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('qacode_prefix', 'SWT', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('barcode_prefix', '0909', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('serial_prefix', '009', '1', null);
INSERT INTO swtgp_config(`Name`, `Value`, `status`, `updateddate`)  VALUES ('yescard_mobile_content', 'yes card', '1', null);

-- ----------------------------
-- Records of swtgp_hsm
-- ----------------------------
--INSERT INTO swtgp_hsm(`NameAlgorithm`, `Formatvalue` , `Values`, `Description`, `Status`, ) VALUES('RSA', '', '0901093093990901093093990901093093', 'smart world', '1');
-- ----------------------------
-- Records of swtgp_kms_secret_key
-- ----------------------------
INSERT INTO swtgp_kms_secret_key(`Alias`, `Description` , `HsmId`, `KeyADM`, `KeyBDM`, `KeyBHM`, `KeyValue`, `Name`, `PriKeyLicense`, `PriKeyServer`, `PubKeyLicense`, `PubKeyServer`, `Status`,  `Owner`) VALUES ('0', '', '1', '0901093093', '0901093093', '0901093093', '0901093093', 'swt key', '09010930930901093093', '10901093093090109309309010930909010930933', '0901093093990901093093990901093093', '0901093093990901093093990901093093', '', '1');

-- ----------------------------
-- Records of swtgp_cms_organization
-- ----------------------------
INSERT INTO swtgp_cms_organization(`Address`, `City`, `ContactEmail`, `ContactMobile`, `ContactName`, `ContactPhone`, `CountryCode`, `CreatedBy`, `CreatedOn`, `Email`, `Fax`, `Issuer`, `ModifiedBy`, `ModifiedOn`, `Name`, `Notes`, `OrgCode`, `OrgShortName`, `Phone`, `SettlementEmail`, `SettlementFrequency`, `State`,  `Status`,  `WebSite`, `ZipCode`, `SecretKeyId`) VALUES ('10 Luong Dinh Cua, Q.2', 'HCM', 'support@smartworld.com', '08 889900', 'Smart card', '08 889900', '+84', 'smartworld', null, 'support@smartworld.com', null, 'MASTER', null, null, 'Smart world', null, '0000', 'Smart world', null, null, null, null, '1', null, null, '1');

-- ----------------------------
-- Records of swtgp_cms_suborganization
-- ----------------------------
INSERT INTO swtgp_cms_suborganization(`state`, `address`, `city`, `contactemail`, `contactname`, `contactphone`, `countrycode`, `createdby`, `createdon`, `email`, `fax`, `modifiedby`, `modifiedon`, `names`, `notes`, `orgcode`, `orgid`, `phone`, `settlementemail`, `shortname`, `status`, `website`, `zipcode`) VALUES ('Viet Nam', '10 Luong Dinh Cua', 'HCM', 'support@smartworld.com', 'smart card', '08 889900', '+84', 'smartworld', null, 'support@smartworld.com', null, null, null, 'Smart world', null, '0000', '1', null, null, 'Yescard', '1', null, null);


-- --------------------------------------------------------------------
-- Records of swtgp_group_user
-- --------------------------------------------------------------------
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES ( null, '1', 'Smart world supper admin', 'swtsupper', '1', '1');
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES (null, '1', 'Smart world admin user', 'swtadmin', '2', '1');
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES (null, '0', 'Smart world normal user', 'swtnormal', '3', '1');
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES (null, '1', 'Merchant supper user', 'merchantsupper', '4', '1');
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES (null, '1', 'Merchant admin user', 'merchantadmin', '5', '1');
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES (null, '0', 'Merchant user', 'merchantuser', '6', '1');
INSERT INTO swtgp_group_user(`description`, `isadmin`,  `name`, `permission`, `role`,  `status`) VALUES (null, '0', 'Guest user', 'guestuser', '7', '1');

-- ----------------------------
-- Records of swtgp_user
-- ----------------------------
INSERT INTO swtgp_user(`Code`,
 `DateCreated`,
 `DateUpdated`, 
 `GroupId`, 
 `Ip`,
 `LocalCode`,
 `PasswordHash`,
 `Salt`,
 `Status`,
 `UserName`, 
 `Memberid`, 
 `Orgid`, 
 `BirthDate`,  
 `Email`,  
 `FirstName`, 
 `Gender`, 
 `IdCardIssuedDate` ,`IdCardIssuedPlace`, `IdCardNo` , `IsRoot` , `LastName` ,`Nationality`, `PermanentAddress`, `PhoneNo`, `TemporaryAddress`)VALUES ('001', '10/04/2014', '10/04/2014', '1', 'localhost', 'swtsupper', '1', 'admin', '1', 'swtsupper', '0', '0', null, null, null, null, null, null, null, null, null, null, 'smartworld temp', null, null);

INSERT INTO swtgp_user(`Code`,
 `DateCreated`,
 `DateUpdated`, 
 `GroupId`, 
 `Ip`,
 `LocalCode`,
 `PasswordHash`,
 `Salt`,
 `Status`,
 `UserName`, 
 `Memberid`, 
 `Orgid`, 
 `BirthDate`,  
 `Email`,  
 `FirstName`, 
 `Gender`, 
 `IdCardIssuedDate` ,`IdCardIssuedPlace`, `IdCardNo` , `IsRoot` , `LastName` ,`Nationality`, `PermanentAddress`, `PhoneNo`, `TemporaryAddress`)VALUES ('002', '10/04/2014', '10/04/2014', '2', 'localhost', 'swtcodeadmin', '1', 'test', '1', 'swtadmin', '0', '0', null, null, null, null, null, null, null, null, null, null, null, null, null);



