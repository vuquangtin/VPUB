package com.swt.sworld.kms.impls;

import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;

import org.apache.commons.lang3.RandomStringUtils;

import com.nhn.utilities.Converter;
import com.nhn.utilities.Utilities;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.cms.domain.CardType;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.impls.CardChipController;
import com.swt.sworld.cms.impls.CardMagneticController;
import com.swt.sworld.cms.impls.CardTypeDAOImpl;
import com.swt.sworld.cms.impls.OrganizationDAOImpl;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.DataToReadCardDTO;
import com.swt.sworld.communication.customer.object.DataToWriteCardDTO;
import com.swt.sworld.communication.customer.object.KeyDTO;
import com.swt.sworld.communication.customer.object.MemberDataExcelDto;
import com.swt.sworld.communication.customer.object.PersoMagneticCardInforDTO;
import com.swt.sworld.communication.customer.object.ResultCheckCardDTO;
import com.swt.sworld.communication.customer.object.SectorKeyPairDTO;
import com.swt.sworld.kms.IGeneratorKey;
import com.swt.sworld.kms.domain.SecretKey;
import com.swt.sworld.kms.factory.GeneratorKeyFactory;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationDAOImpl;
import com.swt.sworld.ps.impl.MemberDAOImpl;
import com.swt.sworld.utilites.SworldConst;

public class KMSController {
	public static final KMSController Instance = new KMSController();

	private SecretKeyDaoImpl KeyDAO = new SecretKeyDaoImpl();
	private OrganizationDAOImpl ORG = new OrganizationDAOImpl();
	private MemberDAOImpl MEMDAO = new MemberDAOImpl();
	private ChipPersonalizationDAOImpl CHIPDAO = new ChipPersonalizationDAOImpl();
	private CardTypeDAOImpl CARDTYPE = new CardTypeDAOImpl();

	private int sectorNumberOfCard(int cardtype) {
		int result = 0;
		switch (cardtype) {
		case SworldConst.MF_1K:
		case SworldConst.MF_1K_CN:
			result = 16;
			break;
		case SworldConst.MF_4K:
			result = 40;
			break;
		default:
			result = 16;
			break;
		}

		return result;
	}

	private SecretKey getSecretKeyByOrgId(long orgid) {
		// get key id
		long keyid = ORG.getSecrectKeyId(orgid);

		// select secrect key by key id
		return KeyDAO.getById(keyid);
	}
	
	/**
	 * generate key for sector
	 * @param orgid	
	 * @param serialnumbex
	 * @param sector
	 * @return
	 */
	public KeyDTO getKeyBySector(long orgid, String serialnumbex, byte sector)
	{
		//ChinhNguyen
		Organization org = ORG.getById(orgid);
		if (null == org)
			return null;

		SecretKey secretkey = KeyDAO.getById(org.getSecretkeyid());

		ResultCheckCardDTO result = new ResultCheckCardDTO();
		result.setHMK_ALIAS((byte) secretkey.getAlias());
		result.setDMKA_ALIAS((byte) secretkey.getAlias());
		result.setDMKB_ALIAS((byte) secretkey.getAlias());

		// create generator
		IGeneratorKey generator = new GeneratorKeyFactory()
				.Instance(SworldConst.RSA);
		generator.setHeaderMasterKeyBytes(secretkey.getKeyBHM());
		
		//preparate data for generator key
		byte[] serial = Converter.getInstance().hexStringToByteArray(serialnumbex);
		SectorKeyPairDTO keypair = generator.deriveSectorPairKeyWithKeyADefault(sector, serial);
		KeyDTO key = null;
		
		if(sector == 3 || sector >= 7){
			generator.setDataMasterKeyABytes(secretkey.getKeyADM());
			key = createHeaderKey(generator,
					secretkey.getSecretKeyId(), serial, (byte) sector);
		}
		else
			key = new KeyDTO(secretkey.getSecretKeyId(), (long) sector, secretkey.getKeyValue(), keypair);
		
		return key;
	}
	
	public List<KeyDTO> getKeyClearEmptyCard(long orgid, String serialnumbex, int cardtype)
	{
		/**
		 * ChinhNguyen
		 * keyB de ghi thong tin nap tien vao the
		 */
		String keyBPayOut = "d9071abe5e9f";
		List<KeyDTO> result = new ArrayList<KeyDTO>();
		for(int sector =0; sector < sectorNumberOfCard(cardtype); sector++)
		{
			if(sector == 12 ){
				SectorKeyPairDTO keyPair = new SectorKeyPairDTO(); 
				keyPair.setKeyA(keyBPayOut);
				keyPair.setKeyB(keyBPayOut);
				result.add(new KeyDTO(orgid, sector, keyPair));
			}
			else
				result.add(getKeyBySector(orgid, serialnumbex, (byte)sector));
		}
		return result;
	}
	
	/**
	 * check data of card to import masterinfo
	 * 
	 * @param orgid
	 * @param serialnumbex
	 * @param cardtype
	 * @param startbyte
	 * @param stopbyte
	 * @return
	 * @throws Exception
	 */
	public ResultCheckCardDTO checkAndGetDataToImportMasterInfo(String session,
			long orgid, String serialnumbex, int cardtype, byte startbyte,
			byte stopbyte) throws Exception {

		Organization org = ORG.getById(orgid);
		if (null == org) return null;

		SecretKey secretkey = KeyDAO.getById(org.getSecretkeyid());

		ResultCheckCardDTO result = new ResultCheckCardDTO();
		result.setHMK_ALIAS((byte) secretkey.getAlias());
		result.setDMKA_ALIAS((byte) secretkey.getAlias());
		result.setDMKB_ALIAS((byte) secretkey.getAlias());

		
		// create generator
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);

		// implement generator server data
		String serverdata = SworldConst.PRE_SERVER + serialnumbex + SworldConst.NAME_SERVER;
		byte[] byteServerdt = Converter.getInstance().hexStringToByteArray(serverdata);
		byte[] serial = Converter.getInstance().hexStringToByteArray(serialnumbex);

		// set license server
		String prikey = secretkey.getPubKeyServer();
		result.setLicenseServer(generator.encryptDataByHexXmlPubKey(prikey, byteServerdt));

		// /------begin preparate data for generator key
		generator.setHeaderMasterKeyBytes(secretkey.getKeyBHM());
		
		// generator key for master
		List<KeyDTO> listKey = new ArrayList<KeyDTO>();
		for (byte sectornumber = startbyte; sectornumber <= stopbyte; sectornumber++) {
			SectorKeyPairDTO keypair = generator.deriveSectorPairKeyWithKeyADefault(sectornumber, serial);

			KeyDTO key = new KeyDTO(secretkey.getSecretKeyId(), (long) sectornumber, secretkey.getKeyValue(), keypair);
			listKey.add(key);

		}
		result.setKEY(listKey);

		// /-----------begin license master----------------------------------
		String license = null;

		// request card in db
		CardChip card = CardChipController.Instance.getCardChipBySerial(serialnumbex);
		if (null == card) {
			String licenseKey = secretkey.getPubKeyLicense();
			license = generator.encryptDataByHexXmlPubKey(licenseKey, serial);
			
			if (CardChipController.Instance.insertCardChipWithRSA(session,
					orgid, org.getOrgCode(), serialnumbex, license, cardtype,
					SworldConst.CARD_HAS_MASTER_READED_ONLY) > 0)
				result.setStatus(SworldConst.CARD_HAS_MASTER_READED_ONLY);
			else
				result.setStatus(ErrorCode.FALSED);
		} 
		else{
			license = card.getLicensemaster();
			result.setStatus(card.getLogicalStatus());
		}

		// /set license
		result.setLicense(license);

		return result;
	}

	public ResultCheckCardDTO checkAndGetDataToImportPartnerInfo(
			String session, long orgid, String serialnumbex, int cardtype,
			byte startbyte, byte stopbyte) {

		Organization orgpartner = ORG.getById(orgid);
		if (null == orgpartner)
			return null;

		ResultCheckCardDTO result = new ResultCheckCardDTO();
		String serverdata = SworldConst.PRE_SERVER + serialnumbex + SworldConst.NAME_SERVER;

		SecretKey secretkey = KeyDAO.getById(orgpartner.getSecretkeyid());
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);

		
		

		// // get licence data
		CardChip card = CardChipController.Instance.getCardChipBySerial(serialnumbex);
		
		if (null != card) {

			String user = TokenManager.getInstance().getUserBySession(session);

			if (!"".equals(user)) {
				card.setOrgPartnerId(orgid);
				card.setOrgPartnerCode(orgpartner.getOrgCode());
				card.setModifyBy(user);
				
				String date = Utilities.getInstance().currentDateStrDDMMYYYY();
				card.setModifyOn(date);

				card.setLogicalStatus(SworldConst.CARD_HAS_MASTER_PARTNER_READED);

				if (CardChipController.Instance.updateCardChip(card) == 0) {
					result.setStatus(SworldConst.CARD_HAS_MASTER_PARTNER_READED);
					card.setLogicalStatus(SworldConst.CARD_HAS_MASTER_PARTNER_READED);
				} else
					result.setStatus(ErrorCode.FALSED);

				//license 
				String licensePubKey = secretkey.getPubKeyLicense();
				byte[] serial = Converter.getInstance().hexStringToByteArray(serialnumbex);
				String license = generator.encryptDataByHexXmlPubKey(licensePubKey, serial);
				card.setLicensepartner(license);
				
				
				String serverPubKey = secretkey.getPubKeyServer();
				byte[] byteServerdt = Converter.getInstance().hexStringToByteArray(serverdata);
				String licenseserver = generator.encryptDataByHexXmlPubKey(serverPubKey, byteServerdt);

				// // pre data for generator key
				generator.setHeaderMasterKeyBytes(secretkey.getKeyBHM());

				List<KeyDTO> listKey = new ArrayList<KeyDTO>();
				for (int sectornumber = startbyte; sectornumber <= stopbyte; sectornumber++) {
					SectorKeyPairDTO keypair = generator.deriveSectorPairKeyWithKeyADefault((byte) sectornumber, serial);
					KeyDTO key = new KeyDTO(secretkey.getSecretKeyId(),
							sectornumber, secretkey.getKeyValue(), keypair);
					listKey.add(key);

				}

				result.setHMK_ALIAS((byte) secretkey.getAlias());
				result.setKEY(listKey);

				result.setLicenseServer(licenseserver);
				result.setLicense(license);
			} else
				result.setStatus(ErrorCode.FALSED);

		} else {

			result.setStatus(ErrorCode.FALSED);
		}

		return result;
	}
	
	public String encryptDataByValueKey(String data, long secrectid){
		SecretKey secretkey = KeyDAO.getById(secrectid);
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.AES);

		String keyvalue = secretkey.getKeyValue();
		byte[] dataBytes =  data.getBytes(Charset.forName("UTF-8")); 
		return generator.encryptDataByValueKey(keyvalue, dataBytes); 
		
	}
	public String encryptDataByPartnerKey(String data, long secrectid) {

		SecretKey secretkey = KeyDAO.getById(secrectid);
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);

		String pubKey = secretkey.getPubKeyLicense();
		byte[] dataBytes =  data.getBytes(Charset.forName("UTF-8")); 
		return generator.encryptDataByHexXmlPubKey(pubKey, dataBytes); 
	}
	
	public byte[] encryptDataByPartnerKeyB(String data, long secrectid) {

		SecretKey secretkey = KeyDAO.getById(secrectid);
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);

		String pubKey = secretkey.getPubKeyLicense();
		byte[] dataBytes =  data.getBytes(); 
		return generator.encryptDataByHexXmlPubKeyB(pubKey, dataBytes); 
	}
	
	public byte[] encryptDataByHexXmlPubKey(String data, long secrectid) {

		SecretKey secretkey = KeyDAO.getById(secrectid);
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);

		String pubKey = secretkey.getPubKeyLicense();
		byte[] dataBytes =  data.getBytes(); 
		return generator.encryptDataByHexXmlPubKeyB(pubKey, dataBytes); 
	}
	

	public DataToReadCardDTO getKey4ReadCardBySerial(String serialNumber,
			int cardtype, List<Long> listCheck) {
		DataToReadCardDTO data = new DataToReadCardDTO();

		// get orgid by serial number in table cardchip
		CardChip card = CardChipController.Instance.getCardChipBySerial(serialNumber);

		long orgid = card.getOrgPartnerId() <= 0 ? card.getOrgMasterId() : card
				.getOrgPartnerId();

		// get secret key by secret key id in table secret key
		SecretKey secretkey = getSecretKeyByOrgId(orgid);

		

		// create generator
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);

		String serverdata = SworldConst.PRE_SERVER + serialNumber + SworldConst.NAME_SERVER;
		byte[] byteServerdt = Converter.getInstance().hexStringToByteArray(serverdata);
		
		// create license server
		String pubKey = secretkey.getPubKeyServer();
		data.setLicenseServer(generator.encryptDataByHexXmlPubKey(pubKey, byteServerdt));

		// generator key for master
		List<KeyDTO> listKey = new ArrayList<KeyDTO>();
		byte[] serial = Converter.getInstance().hexStringToByteArray(serialNumber);
		
		generator.setDataMasterKeyABytes(secretkey.getKeyADM());

		// begin preparate data for generator key
		for (Long long1 : listCheck) {
			SectorKeyPairDTO keypair = new SectorKeyPairDTO();
			keypair.setKeyA(generator.deriveSectorKeyA(long1.byteValue(), serial).getKeyA());
			keypair.setKeyB("");
			KeyDTO key = new KeyDTO(secretkey.getSecretKeyId(), long1, "", keypair);
			listKey.add(key);

		}

		KeyDTO headerKye = createHeaderKey(generator, secretkey.getSecretKeyId(), serial, (byte) 3);
		listKey.add(headerKye);
		data.setKEY(listKey);
		// end add list keyDto

		if (data.getKEY() != null && data.getLicenseServer() != null) {
			data.setStatus((byte) ErrorCode.SUCCESS);
		} else {
			data.setStatus((byte) ErrorCode.FALSED);
		}

		return data;
	}

	/**
	 * build server licenser to make sure data send from correct server
	 * @param orgid
	 * @param serialNumber
	 * @return
	 */
	private String buildServerLicenser(long orgid, String serialNumber){
		SecretKey secretkey = getSecretKeyByOrgId(orgid); // get secretkey
		String pubkey = secretkey.getPubKeyServer(); // get private key server
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA); //create generator
		//prepare data
		String serverdata = SworldConst.PRE_SERVER + serialNumber + SworldConst.NAME_SERVER;
		byte[] byteServerdt = Converter.getInstance().hexStringToByteArray(serverdata);
		return generator.encryptDataByHexXmlPubKey(pubkey, byteServerdt);
	}
	
	private DataToWriteCardDTO generateKey4PersoData(long orgid, long issuerid, String serialNumber, byte sectorstart, int length){
		DataToWriteCardDTO data = new DataToWriteCardDTO();

		// get secret key by secret key id in table secret key
		SecretKey secretkey = getSecretKeyByOrgId(orgid);

		// set licenseserver
		String serverLicense = buildServerLicenser(issuerid, serialNumber);
		data.setLicenseServer(serverLicense);

		//prepare data for generator key
		IGeneratorKey generator = new GeneratorKeyFactory().Instance(SworldConst.RSA);
		generator.setDataMasterKeyABytes(secretkey.getKeyADM());
		generator.setDataMasterKeyBBytes(secretkey.getKeyBDM());
		generator.setHeaderMasterKeyBytes(secretkey.getKeyBHM());

		// generator key for master
		List<KeyDTO> listKey = new ArrayList<KeyDTO>();
		byte[] serial = Converter.getInstance().hexStringToByteArray(
				serialNumber);

		int endsector = 0;
		if ((length % 48) == 0) {
			endsector = length / 48;
		} else {
			endsector = (length / 48) + 1;
		}
		endsector += sectorstart;
		for (byte sectornumber = sectorstart; sectornumber < endsector; sectornumber++) {
			if(sectornumber == 11 || sectornumber == 12)
				continue;
			SectorKeyPairDTO keypair = new SectorKeyPairDTO();
			keypair.setKeyA(generator.deriveSectorKeyA(sectornumber, serial)
					.getKeyA());
			keypair.setKeyB(generator.deriveSectorKeyB(sectornumber, serial)
					.getKeyB());
			KeyDTO key = new KeyDTO(secretkey.getSecretKeyId(), sectornumber,
					secretkey.getKeyValue(), keypair);
			listKey.add(key);
		}

		KeyDTO headerKye = createHeaderKey(generator,
				secretkey.getSecretKeyId(), serial, (byte) 3);
		listKey.add(headerKye);
		
		//Sector 11
		KeyDTO sector11Kye = getKeyBySector(orgid, serialNumber, (byte)11);
		listKey.add(sector11Kye);
		//Sector 12
		String keyBPayOut = "d9071abe5e9f";
		SectorKeyPairDTO sector12key = new SectorKeyPairDTO(); 
		sector12key.setKeyA(keyBPayOut);
		sector12key.setKeyB(keyBPayOut);
		listKey.add(new KeyDTO(orgid, 12, sector12key));

		data.setKEY(listKey);

		return data;
		
	}
	
	/**
	 * 
	 * @param orgid
	 * @param serialNumber
	 * @param cardType
	 * @param sectorstart
	 * @param length
	 * @return
	 */
	public DataToWriteCardDTO checkAndGetKey4PersoData(long memberid, long issuerid, String serialNumber, int cardType, byte sectorstart, int length) {
		DataToWriteCardDTO data = null;
		ChipPersonalization chipper = CHIPDAO.getByMemberIdAndSerialNumber(memberid, serialNumber);
		if(chipper == null)
		{
			Member member = MEMDAO.getMembeByMemberid(memberid);
	
			// get orgid by serial number in table cardchip
			CardChip card = CardChipController.Instance.getCardChipBySerial(serialNumber);
			if (card != null) {
				long orgid = (member.getOrgId() != card.getOrgPartnerId()) ? card
						.getOrgMasterId() : card.getOrgPartnerId();
				data = generateKey4PersoData(orgid, issuerid, serialNumber, sectorstart, length);
	
			}
		}
		else
		{
			if(chipper.getStatus() == SworldConst.CANCEL || chipper.getStatus() == SworldConst.LOCK || chipper.getStatus() == SworldConst.MARKBROKEN || chipper.getStatus() == SworldConst.MARKLOST)
			{
				Member member = MEMDAO.getMembeByMemberid(memberid);
				
				// get orgid by serial number in table cardchip
				CardChip card = CardChipController.Instance.getCardChipBySerial(serialNumber);
				if (card != null) {
					long orgid = (member.getOrgId() != card.getOrgPartnerId()) ? card
							.getOrgMasterId() : card.getOrgPartnerId();
					data = generateKey4PersoData(orgid, issuerid, serialNumber, sectorstart, length);
		
				}
			}
			else
			{
				return data;
			}
		}

		return data;
	}

	/**
	 * 
	 * @param orgid
	 * @param serialNumber
	 * @param cardType
	 * @param sectorstart
	 * @param length
	 * @return
	 */
	public DataToWriteCardDTO getKey4UpdateCardData(long issuerid, String serialNumber, int cardType, 
			byte sectorstart, int length) {
		DataToWriteCardDTO data = new DataToWriteCardDTO();

		ChipPersonalization persion = CHIPDAO.getCardChipBySerial(serialNumber);
		Member member = MEMDAO.getMembeByMemberid(persion.getPsMemberId());

		// get orgid by serial number in table cardchip
		CardChip card = CardChipController.Instance
				.getCardChipBySerial(serialNumber);
		if (card != null) {
			long orgid = (member.getOrgId() != card.getOrgPartnerId()) ? card
					.getOrgMasterId() : card.getOrgPartnerId();

			data = generateKey4PersoData(orgid, issuerid, serialNumber, sectorstart, length);
			// end add list keyDto
		}

		return data;
	}

	private KeyDTO createHeaderKey(IGeneratorKey generator, long secid,
			byte[] serial, byte sector) {
		SectorKeyPairDTO keypair = new SectorKeyPairDTO();
		keypair.setKeyA(generator.deriveSectorKeyA(sector, serial).getKeyA());
		keypair.setKeyB(generator.deriveSectorKeyB(sector, serial).getKeyB());
		return new KeyDTO(secid, sector, "alibaba", keypair);
	}

	// generato data
	public List<MemberDataExcelDto> generatorData4Person(
			PersoMagneticCardInforDTO data) throws Exception {

		if (data == null)
			return null;

		List<MemberDataExcelDto> listresult = new ArrayList<MemberDataExcelDto>();
		long orgid = data.getPartnerid() > 0 ? data.getPartnerid() : data
				.getMasterid();

		// get key id
		long keyid = ORG.getSecrectKeyId(orgid);

		// select secrect key by key id

		SecretKey key = KeyDAO.getById(keyid);

		GeneratorDataUserAES aes = new GeneratorDataUserAES();
		long beginnumber = CardMagneticController.Instance
				.totalRecordbyMasterPartnerPrefix(data.getMasterid(),
						data.getPartnerid(), data.getPrefix());
		String partnerCode = data.getPartnercode() == null ? "0000" : data
				.getPartnercode();
		String prefixMaster = "";
		if (data.getMastercode().length() == 1) {
			prefixMaster = "0" + data.getMastercode();
		} else {
			prefixMaster = (data.getMastercode().length() > 2) ? data
					.getMastercode().substring(0, 2) : "00";
		}

		// System.out.println("master = " + prefixMaster);
		// System.out.println("partner = " + partnerCode);
		// System.out.println("prefix = " + data.getPrefix());

		if (partnerCode.contentEquals(data.getMastercode())) {
			CardType card = CARDTYPE.getById(data.getMasterid(),
					data.getPrefix());
			partnerCode = card.getCardLow();
		}
		// unpadded is "12345"
		// padded is "000000000012345"

		prefixMaster = prefixMaster + partnerCode + data.getPrefix();
		String temp = "0000000000000000".substring(prefixMaster.length());

		// System.out.println("master = " + prefixMaster);
		// System.out.println("prefix = " + temp);

		if (data.getIsdefault() != 0) {
			// default
			for (int i = 0; i < data.getCount(); i++) {
				MemberDataExcelDto memberdata = new MemberDataExcelDto();
				memberdata.setCompanyName("smart sworld");

				String numberPhone = RandomStringUtils.randomNumeric(10);
				memberdata.setFullName("SWT"
						+ RandomStringUtils.randomAlphabetic(10));
				memberdata.setPhoneNumber(numberPhone);
				memberdata.setSheetName("Sheetname1");
				memberdata.setExpiredTime(data.getExpiredTime());
				String lasted = "" + beginnumber++;
				if (lasted.length() > 8)
					break;

				String generatedSerialNumber = prefixMaster
						+ temp.substring(lasted.length()) + lasted;
				memberdata.setSerialNumber(generatedSerialNumber);

				String trackdata = aes.encryptDataByHexXmlPubKey(key.getKeyValue(), numberPhone.getBytes());

				memberdata.setTrackData(generatedSerialNumber + trackdata);

				listresult.add(memberdata);
			}
		} else {
			listresult = data.getListperso();
			if (listresult.size() != 0) {
				for (MemberDataExcelDto memberdata : listresult) {
					String lasted = String.valueOf(beginnumber++);

					if (lasted.length() > 8)
						break;

					String generatedSerialNumber = prefixMaster
							+ temp.substring(lasted.length()) + lasted;
					memberdata.setSerialNumber(generatedSerialNumber);
					String phone = memberdata.getPhoneNumber();
					String trackdata = aes.encryptDataByHexXmlPubKey(key.getKeyValue(), phone.getBytes());
					memberdata.setTrackData(generatedSerialNumber + trackdata);
				}
			}
		}
		return listresult;
	}

	public DataToWriteCardDTO checkAndGetAppDataToClearCard(long issuerid, String serial,
			int cardtype, byte sectorstart, byte sectorstop) {

		int length = (sectorstop - sectorstart) * 48;
		DataToWriteCardDTO data = getKey4UpdateCardData(issuerid, serial, cardtype, sectorstart, length);

		return data;
	}

}
