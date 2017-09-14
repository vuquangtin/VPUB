/**
 * 
 */
package com.sworld.web.services;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Request;
import javax.ws.rs.core.UriInfo;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;

import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.impls.CardMagneticController;
import com.swt.sworld.cms.impls.OrganizationController;
import com.swt.sworld.cms.impls.PartnersController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.communication.customer.object.CardStatisticsData;
import com.swt.sworld.communication.customer.object.DataForReadCard;
import com.swt.sworld.communication.customer.object.DataToReadCardDTO;
import com.swt.sworld.communication.customer.object.DataToWriteCardDTO;
import com.swt.sworld.communication.customer.object.MagneticPersData;
import com.swt.sworld.communication.customer.object.MagneticPersonalizationDTO;
import com.swt.sworld.communication.customer.object.MemberCustomerDTO;
import com.swt.sworld.communication.customer.object.MemberDataExcelDto;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.communication.customer.object.MethodResultDto;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.communication.customer.object.PersoMagneticCardInforDTO;
import com.swt.sworld.kms.impls.KMSController;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.MagneticPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationController;
import com.swt.sworld.ps.impl.MagneticPersonalizationController;
import com.swt.sworld.ps.impl.MemberController;

/**
 * @author Vo tinh
 * 
 */
@Path(Defines.PERSO)
@Produces(Defines.APPLICATION_JSON)
public class PersoManager {
	@Context
	UriInfo uriInfo;

	@Context
	Request request;

	@GET
	@Path(Defines.PERSO_CARD_CHIP + "/{token}/{memberid}/{serial}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject updatePersoCardChip(@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("memberid") long memberid,
			@PathParam("serial") String serial) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			int kq = ChipPersonalizationController.Instance.insertPersoCardChip(session, memberid, serial);
			
			if (ErrorCode.SUCCESS == kq)
				result.setStatus(Status.SUCCESS);
			else
				result.setStatus(Status.FAILED);

		}
		return result;
	}

	@POST
	@Path(Defines.UPDATE_DATE_MEMBER_APP_OF_PERSO + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMasterDataByKey(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONObject data) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {

			result.setStatus(Status.SUCCESS);

		}
		return result;
	}

	@POST
	@Path(Defines.GET_MEMBER_DATA_BY_SUBORG_ID + "{token}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMasterDataByKey(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("suborgid") long orgid, JSONObject memberFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			MemberFilter filter = new MemberFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(memberFilter, filter.getClass());
			List<Member> lstMember = MemberController.Instance.getMemberListDataByOrgId(orgid, filter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMember);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_PERSO_DATA_BY_ORG_ID_SUBORG_ID
			+ "/{token}/{orgid}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMasterDataByKey(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid,
			@PathParam("suborgid") long suborgid, JSONObject persoFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {

			PersoChipFilter memFilter = new PersoChipFilter();
			memFilter = Utilites.getInstance().convertJsonObjToObject(persoFilter, memFilter.getClass());
			List<ChipPersonalization> lstChipPerso = ChipPersonalizationController.Instance.getPersoDataByOrgAndSubOrg(orgid, suborgid, memFilter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstChipPerso);

		}
		return result;
	}

	@POST
	@Path(Defines.CANCEL_PERSO_BY_PERSOID + "/{token}/{reason}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postCancelPerso(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,@PathParam("reason") String reason, JSONArray cancelPerso) {

		ResultObject result = new ResultObject(Status.FAILED);
			List<Long> chipPersoIds = Utilites.getInstance().convertJsonArrayToListLong(cancelPerso);

			boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
			if (flag) {
				List<MethodResultDto> lstMethod = ChipPersonalizationController.Instance.cancelPerso(session, chipPersoIds, reason);
				result.setStatus(Status.SUCCESS);
				result.setObj(lstMethod);

			}

		return result;
	}

	@POST
	@Path(Defines.LOCK_PERSO_BY_PERSOID + "/{token}/{reason}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postLockPerso(@CookieParam("sessionid") String session,
			@PathParam("token") String token,@PathParam("reason") String reason, JSONArray lockPerso) {

		ResultObject result = new ResultObject(Status.FAILED);
			List<Long> chipPersoIds = Utilites.getInstance().convertJsonArrayToListLong(lockPerso);
			boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
			if (flag) {
				List<MethodResultDto> lstMethod = ChipPersonalizationController.Instance.lockPerso(session, chipPersoIds, reason);
				result.setStatus(Status.SUCCESS);
				result.setObj(lstMethod);

			}

		return result;
	}

	@POST
	@Path(Defines.UNLOCK_PERSO_BY_PERSOID + "/{token}/{reason}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUnLockPerso(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,@PathParam("reason") String reason, JSONArray unlockPerso) {

		ResultObject result = new ResultObject(Status.FAILED);
			List<Long> chipPersoIds = Utilites.getInstance().convertJsonArrayToListLong(unlockPerso);
			boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
			if (flag) {
				List<MethodResultDto> lstMethod = ChipPersonalizationController.Instance
						.unLockPerso(session, chipPersoIds, reason);
				result.setStatus(Status.SUCCESS);
				result.setObj(lstMethod);

			}

		return result;
	}

	@POST
	@Path(Defines.EXTEND_PERSO_BY_PERSOID + "/{token}/{date}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postExtendPerso(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,@PathParam("date") String date, JSONArray extendPerso) throws ParseException {

		ResultObject result = new ResultObject(Status.FAILED);
			List<Long> chipPersoIds = Utilites.getInstance().convertJsonArrayToListLong(extendPerso); 
			Date date1 ;
			SimpleDateFormat formatter = new SimpleDateFormat("dd-MM-yyyy");
			date1 = formatter.parse(date);
			SimpleDateFormat dt1 = new SimpleDateFormat("dd/MM/yyyy");
			String ngay = dt1.format(date1);
			boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
			if (flag) {
				List<MethodResultDto> lstMethod = ChipPersonalizationController.Instance
						.extendPerso(chipPersoIds, ngay);
				result.setStatus(Status.SUCCESS);
				result.setObj(lstMethod);

			}

		return result;
	}

	@GET
	@Path(Defines.CHECK_AND_GET_PERSO_DATA + "/{token}/{memberId}/{serialNumber}/{cardType}/{sectorstart}/{issuer}")
	public ResultObject checkAndGetPersoData(@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("memberId") long memberId,
			@PathParam("serialNumber") String serialNumber,
			@PathParam("cardType") int cardType,
			@PathParam("sectorstart") byte sectorstart, 
			@PathParam("issuer") String issuer){
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			
			if(!ChipPersonalizationController.Instance.ValidatePersoCard(serialNumber, memberId))
			{
				//check partner has permission assign card for member, who is not member
				Member member = MemberController.Instance.getMemberById(memberId);
				boolean isOkie = PartnersController.Instance.checkRelationship(issuer, member.getOrgCode());
				
				//not has permission
				if(!isOkie)
					return result;
				
				//get issuer org
				Organization issuerOrg = OrganizationController.Instance.getByIssuerCode(issuer);
				if(null == issuerOrg)
					return result;
				
				//prepare data for writing chip
				String strdata = ChipPersonalizationController.Instance.getDataToPersoCard(member);
				DataToWriteCardDTO data = KMSController.Instance.checkAndGetKey4PersoData(memberId, issuerOrg.getOrgId(), serialNumber,
								cardType, sectorstart, strdata.getBytes().length);
				if(data != null)
				{
					// encrypt data using partner key (partner is organization assign key);
					//byte[] encryptData = KMSController.Instance.encryptDataByPartnerKeyB(strdata, issuerOrg.getSecretkeyid());
					//String base64Data = Base64.getEncoder().encodeToString(encryptData);
					//data.setData(base64Data);
					//String encryptData = KMSController.Instance.encryptDataByPartnerKey(strdata, issuerOrg.getSecretkeyid());
					
					String encryptData = KMSController.Instance.encryptDataByValueKey(strdata, issuerOrg.getSecretkeyid());
				
					data.setData(encryptData);
				}
				result.setStatus(Status.SUCCESS);
				result.setObj(data);
			}
			else
			{
				result.setStatus(Status.FAILED);
				result.setObj(null);
			}
		}
		return result;
	}
	

	@POST
	@Path(Defines.GET_DATA_TO_READ_CARD + "/{token}/{serialNumber}/{cardType}/{data}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetDataToReadCard(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serialNumber") String serialNumber,
			@PathParam("cardType") int cardType, @PathParam("data") String data) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {

			DataForReadCard dataKQ = ChipPersonalizationController.Instance
					.getDataToReadCard(serialNumber, cardType, data);
			result.setStatus(Status.SUCCESS);
			result.setObj(dataKQ);

		}
		return result;
	}

	@POST
	@Path(Defines.GET_KEY_FOR_READ_CARD + "/{token}/{serial}/{cardtype}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetKeyForReadCard(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serial") String serial,
			@PathParam("cardtype") int cardtype, JSONArray list) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			DataToReadCardDTO data = null;
			// list sector
			List<Long> lstLong = Utilites.getInstance()
					.convertJsonArrayToListLong(list);
			data = KMSController.Instance.getKey4ReadCardBySerial(serial, cardtype, lstLong);
			result.setStatus(Status.SUCCESS);
			result.setObj(data);
		}
		return result;
	}

	@GET
	@Path(Defines.GET_DATA_TO_UPDATE_CARD
			+ "/{token}/{serialNumber}/{sectorstart}/{issuer}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetDataToUpdateCard(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serialNumber") String serialNumber,
			@PathParam("sectorstart") byte sectorstart,
			@PathParam("issuer") String issuer) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			// string data for updating to card
			String strdata = ChipPersonalizationController.Instance.getDataToUpdateCard(serialNumber, sectorstart);

			//get issuer org
			Organization issuerOrg = OrganizationController.Instance.getByIssuerCode(issuer);
			if(null == issuerOrg)
				return result;
			
			// object to client
			DataToWriteCardDTO data = KMSController.Instance.getKey4UpdateCardData(issuerOrg.getOrgId(), serialNumber, 0, sectorstart,
							strdata.getBytes().length);

			if(strdata != null)
			{
				// encrypt data using partner key (partner is organization assign key);
				String encryptData = KMSController.Instance.encryptDataByValueKey(strdata, issuerOrg.getSecretkeyid());
				data.setData(encryptData); 
			}
			
			result.setStatus(Status.SUCCESS);
			result.setObj(data);

		}
		return result;
	}

	@GET
	@Path(Defines.UPDATE_MEMBER_APP_OF_PERSO
			+ "/{token}/{serialNumber}/{lastupdatedate}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateMemberAppOfPerso(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serialNumber") String serialNumber,
			@PathParam("lastupdatedate") String lastupdatedate) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {

			int kq = ChipPersonalizationController.Instance.updateMemberAppOfPerso("N/A", serialNumber, lastupdatedate);
			if (kq > 0)
				result.setStatus(Status.SUCCESS);
			else
				result.setStatus(Status.FAILED);
		}
		return result;
	}

	@GET
	@Path(Defines.CHECK_AND_GET_APP_DATA_TO_CLEAR_CARD
			+ "/{token}/{serialNumber}/{cardtype}/{sectorstart}/{sectorstop}/{issuer}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getCheckAndGetAppDataToClearCard(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serialNumber") String serialNumber,
			@PathParam("cardtype") int cardtype,
			@PathParam("sectorstart") byte sectorstart,
			@PathParam("sectorstop") byte sectorstop, 
			@PathParam("issuer") String issuer ) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			//get issuer org
			Organization issuerOrg = OrganizationController.Instance.getByIssuerCode(issuer);
			if(null == issuerOrg)
				return result;
			
			DataToWriteCardDTO datawrite = KMSController.Instance .checkAndGetAppDataToClearCard(issuerOrg.getOrgId(), serialNumber, cardtype,
							sectorstart, sectorstop);
			if (datawrite == null) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
				result.setObj(datawrite);
			}
		}
		return result;
	}

	@GET
	@Path(Defines.CLEAR_CARD_DATA + "/{token}/{serialnumber}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getClearCardData(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("serialnumber") String serialnumber) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			ChipPersonalizationController.Instance.clearCardData(serialnumber);
			result.setStatus(Status.SUCCESS);
		}
		return result;
	}
	
	@POST
	@Path(Defines.GET_CHANGE_STATUS + "/{token}/{reason}/{status}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getChangeStatus(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("reason") String reason,@PathParam("status") byte status,
			JSONArray lstChipPersoid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			List<Long> lstLong = Utilites.getInstance().convertJsonArrayToListLong(lstChipPersoid);
			List<MemberCustomerDTO> lstmem = ChipPersonalizationController.Instance.updateStatus(lstLong, status, reason);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstmem);
		}
		return result;
	}
	
	@POST
	@Path(Defines.GET_CHANGE_STATUS_MAGNETIC + "/{token}/{reason}/{status}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject postGetChangeStatusMagnetic(@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			@PathParam("status") int status,
			@PathParam("reason") String reason, JSONArray lstpersoid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			List<Long> persoid = Utilites.getInstance().convertJsonArrayToListLong(lstpersoid);
			List<MagneticPersonalization> lstmagnetic = MagneticPersonalizationController.Instance.getChangeStatusMagnetic(status, reason, persoid);
			result.setObj(lstmagnetic);
			result.setStatus(Status.SUCCESS);

		}
		return result;
	}
	
	@GET
	@Path(Defines.STATISTIC_CARDCHIP_BY_STATUS + "/{token}/{masterId}/{orgpartnerid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getStatisticCardChipByStatus(
			@CookieParam("sessionid") String session,@PathParam("token") String token,
			@PathParam("masterId") long masterId,@PathParam("orgpartnerid") long orgpartnerid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			List<CardStatisticsData> lstcardstatistic = ChipPersonalizationController.Instance.statisticCardChip(masterId,orgpartnerid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstcardstatistic);

		}
		return result;
	}
	
	@POST
	@Path(Defines.SAVE_DATA_PERSO_CARD_MAGNETIC + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postSaveDataPersoCardMagnetic(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			JSONObject persocardmagneticinfordto) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			PersoMagneticCardInforDTO dto = new PersoMagneticCardInforDTO();
			dto = Utilites.getInstance().convertJsonObjToObject(persocardmagneticinfordto, dto.getClass());
			int kq = ErrorCode.FALSED;
			try {
				if(dto.getIsdefault() == 1)
				{
					CardMagneticController.Instance.saveListCardinfor(dto);
					result.setStatus(Status.SUCCESS);
				}
				else
				{
					kq = MagneticPersonalizationController.Instance.saveListCardinforNoDefault(dto);
					if(kq == ErrorCode.SUCCESS)
					{
						result.setStatus(Status.SUCCESS);
					}
					else
					{
						result.setStatus(Status.FAILED);
					}
				}
			} catch (Exception e) {
				e.printStackTrace();
			}
			
			
		}
		return result;
	}
	
	@POST
	@Path(Defines.GET_MEMBER_MAGNETIC_LIST + "/{token}/{orgid}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetMemberMagneticList(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid,
			@PathParam("suborgid") long suborgid, JSONObject cardmagneticfilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			CardMagneticFilterDto cardfilter = new CardMagneticFilterDto();
			cardfilter = Utilites.getInstance().convertJsonObjToObject(cardmagneticfilter, cardfilter.getClass());
			List<MagneticPersonalizationDTO> lstMagnticPerso = MagneticPersonalizationController.Instance.getMemberPersoMagnetic(orgid, suborgid, cardfilter);
			if (lstMagnticPerso == null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(new ArrayList<MagneticPersonalization>());
			} 
			else 
			{
				result.setStatus(Status.SUCCESS);
				result.setObj(lstMagnticPerso);
			}

		}
		return result;
	}
	
	@POST
	@Path(Defines.PERSO_CARDMAGNETIC + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postPersoCardMagnetic(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token, JSONArray cardPerDataList) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			try {
				List<MagneticPersData> lstmagnetic = Utilites.getInstance().convertJsonArrayToList(cardPerDataList.getJSONArray(0));
				MagneticPersonalizationController.Instance.presoCardMagnetic(lstmagnetic);
				result.setStatus(Status.SUCCESS);
			} catch (JSONException e) {
				e.printStackTrace();
			}
		}
		return result;
	}
	
	@POST
	@Path(Defines.POST_PERSO_DATA_4_GENERATE_CARD + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject PostPersoData4GenerateCard(
			@CookieParam("sessionid") String session,
			@PathParam("token") String token,
			 JSONObject jsonObj) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			try{
				PersoMagneticCardInforDTO persoData = Utilites.getInstance().convertJsonObjToObject(jsonObj, PersoMagneticCardInforDTO.class);
				List<MemberDataExcelDto> list = KMSController.Instance.generatorData4Person(persoData);
				
				result.setStatus(Status.SUCCESS);
				result.setObj(list);
			}catch (Exception e) {
				e.printStackTrace();
			}
		}
		return result;
	}
}
