package com.sworld.web.services;

import java.util.ArrayList;
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
import org.codehaus.jettison.json.JSONObject;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import com.sworld.common.Defines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.sworld.common.Utilites;
import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.cms.domain.CardMagnetic;
import com.swt.sworld.cms.impls.CardChipController;
import com.swt.sworld.cms.impls.CardMagneticController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.CardChipDto;
import com.swt.sworld.communication.customer.object.CardFilterDto;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.communication.customer.object.CardStatisticsData;
import com.swt.sworld.communication.customer.object.CardmagneticDTO;
import com.swt.sworld.communication.customer.object.KeyDTO;
import com.swt.sworld.communication.customer.object.MethodResultDto;
import com.swt.sworld.communication.customer.object.PreGenerateData;
import com.swt.sworld.communication.customer.object.ResultCheckCardDTO;
import com.swt.sworld.kms.impls.KMSController;
import com.swt.sworld.ps.impl.ChipPersonalizationController;

@Path(Defines.CARD)
@Produces(Defines.APPLICATION_JSON)
public class CardManager {
	@Context
	UriInfo uriInfo;

	@Context
	Request request;

	@GET
	@Path(Defines.GET_DATE_FOR_GENERATE_SERIAL + "/{token}/{masterid}/{partnerid}/{suborgid}/{check}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getPreGenerate(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("masterid") long masterid, @PathParam("partnerid") long partnerid,
			@PathParam("suborgid") long suborgid, @PathParam("check") int check) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag =  TokenManager.getInstance().checkTokenSession(session,token);
		if (flag) {
			if (check == 1)// get value default (FullName, CompanyName,
							// PhoneNumber)
			{
				// TODO: implement
				PreGenerateData pre = CardMagneticController.Instance.getPregenerateData(masterid, partnerid, suborgid,
						check);
				result.setStatus(Status.SUCCESS);
				result.setObj(pre);
			}

		}
		return result;
	}

	@GET
	@Path(Defines.CHECK_ADN_GET_MASTERDATA_4_CARD_CHIP + "/{token}/{id}/{serial}/{cardtype}/{start}/{stop}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getMasterDataByKey(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("id") int id, @PathParam("serial") String serial, @PathParam("cardtype") int cardtype,
			@PathParam("start") int start, @PathParam("stop") int stop) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ResultCheckCardDTO data = null;
			try {
				data = KMSController.Instance.checkAndGetDataToImportMasterInfo(session, id, serial, cardtype,
						(byte) start, (byte) stop);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			result.setStatus(Status.SUCCESS);
			result.setObj(data);
		}

		return result;

	}

	@GET
	@Consumes(Defines.APPLICATION_JSON)
	@Path(Defines.UPDATE_CARD_DATA_OF_MASTER + "/{token}/{id}/{partnerId}/{serial}/{cardtype}/{status}")
	public ResultObject updateCardDataBySerialAndMasterId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("id") int orgMasterId, @PathParam("partnerId") long partnerId,
			@PathParam("serial") String serial, @PathParam("cardtype") int cardtype, @PathParam("status") int status) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			if (ErrorCode.SUCCESS == CardChipController.Instance.updateCardChipStatus(session, orgMasterId, partnerId,
					serial, cardtype, status))
				result.setStatus(Status.SUCCESS);
		}

		return result;
	}

	@POST
	@Path(Defines.GENERATE_SERIAL_CARD_DATA + "/{token}/{masterid}/{partnerid}/{count}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMasterDataByKey(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("masterid") int masterid, @PathParam("partnerid") int partnerid, @PathParam("count") int count,
			JSONArray jsonArray) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			// TODO implement get master data by key
		}
		return result;
	}

	@GET
	@Path(Defines.CHECK_AND_GET_PARTNER_DATA_TO_IMPORT_CARD + "/{token}/{id}/{serial}/{cardtype}/{start}/{stop}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postCheckAndGetDataToImportCard(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("id") long id, @PathParam("serial") String serial,
			@PathParam("cardtype") int cardtype, @PathParam("start") byte start, @PathParam("stop") byte stop) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			ResultCheckCardDTO data = null;
			try {
				data = KMSController.Instance.checkAndGetDataToImportPartnerInfo(session, id, serial, cardtype, start,
						stop);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			result.setStatus(Status.SUCCESS);
			result.setObj(data);

		}
		return result;
	}

	@GET
	@Consumes(Defines.APPLICATION_JSON)
	@Path(Defines.UPDATE_DATA_FOR_CARD_BY_SERIAL_AND_PARTNERID + "/{token}/{id}/{serial}/{cardtype}/{status}")
	public ResultObject updateCardDataBySerialAndPartnerId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("id") int partnerid, @PathParam("serial") String serial,
			@PathParam("cardtype") int cardtype, @PathParam("status") int status) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			if (ErrorCode.SUCCESS == CardChipController.Instance.updateCardChipStatusByPartnerId(session, partnerid,
					serial, cardtype, status))
				result.setStatus(Status.SUCCESS);
		}

		return result;
	}

	@POST
	@Path(Defines.MARK_BROKEN_CARDS_BY_CARDCHIPID + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMarkBroken(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray markbroken) {

		ResultObject result = new ResultObject(Status.FAILED);

		List<Long> cardchipid = Utilites.getInstance().convertJsonArrayToListLong(markbroken);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<MethodResultDto> lstMethod = CardChipController.Instance.markBrokenCard(session, cardchipid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);

		}

		return result;
	}

	@POST
	@Path(Defines.UNMARK_BROKEN_CARDS_BY_CARDCHIPID + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUnMarkBroken(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray unmarkbroken) {

		ResultObject result = new ResultObject(Status.FAILED);
		List<Long> cardchipid = Utilites.getInstance().convertJsonArrayToListLong(unmarkbroken);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<MethodResultDto> lstMethod = CardChipController.Instance.unMarkBrokenCard(session, cardchipid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);

		}

		return result;
	}

	@POST
	@Path(Defines.MARK_LOST_CARDS_BY_CARDCHIPID + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMarkLost(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray marklost) {

		ResultObject result = new ResultObject(Status.FAILED);
		List<Long> cardchipid = Utilites.getInstance().convertJsonArrayToListLong(marklost);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<MethodResultDto> lstMethod = CardChipController.Instance.markLostCard(session, cardchipid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);

		}

		return result;
	}

	@POST
	@Path(Defines.UNMARK_LOST_CARDS_BY_CARDCHIPID + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUnMarkLost(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray unmarklost) {

		ResultObject result = new ResultObject(Status.FAILED);

		List<Long> cardchipid = Utilites.getInstance().convertJsonArrayToListLong(unmarklost);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<MethodResultDto> lstMethod = CardChipController.Instance.unMarkLostCard(session, cardchipid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMethod);

		}

		return result;
	}

	@POST
	@Consumes(Defines.APPLICATION_JSON)
	@Path(Defines.GET_CARD_CHIP_LIST + "/{token}/{orgid}/{suborgid}")
	public ResultObject updateGetCardChipList(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid, @PathParam("suborgid") long suborgid,
			JSONObject filter) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			CardFilterDto cardfilter = Utilites.getInstance().convertJsonObjToObject(filter, CardFilterDto.class);
			List<CardChipDto> lstcarChips = CardChipController.Instance.getAllCardChip(orgid, suborgid, cardfilter);
			if (lstcarChips == null) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstcarChips);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.STATISTIC_CARD_MAGNETIC_STATUS + "/{token}/{orgid}/{suborgid}/{cardtype}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getStatisticCardMagneticStatus(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid, @PathParam("suborgid") long suborgid,
			@PathParam("cardtype") String cardtype) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<CardStatisticsData> lstcard = CardMagneticController.Instance.StatisticCardMagneticStatus(orgid,
					suborgid, cardtype);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstcard);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_MAGNETIC_LIST + "/{token}/{masterid}/{partnerid}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject postGetMagneticList(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("masterid") long masterid, @PathParam("partnerid") long partnerid, JSONObject cardfilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			CardMagneticFilterDto filter = new CardMagneticFilterDto();
			filter = Utilites.getInstance().convertJsonObjToObject(cardfilter, filter.getClass());
			List<CardmagneticDTO> lstcard = CardMagneticController.Instance.getAllByFilterCardMagnetic(masterid,
					partnerid, filter);
			if (lstcard != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstcard);
			} else {
				result.setStatus(Status.FAILED);
				result.setObj(new ArrayList<CardMagnetic>());
			}
		}
		return result;
	}

	@POST
	@Path(Defines.GET_CHANGESTATUS_MAGNETIC + "/{token}/{status}/{reason}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject postChangeStatusCardMagnetic(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("status") int status, @PathParam("reason") String reason,
			JSONArray lstcardmagneticid) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> cardmagneticid = Utilites.getInstance().convertJsonArrayToListLong(lstcardmagneticid);
			List<CardmagneticDTO> lstcard = CardMagneticController.Instance.getChangeStatusCardMagnetic(status, reason,
					cardmagneticid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstcard);
		}
		return result;
	}

	@GET
	@Path(Defines.CLEAR_EMPTY_CARD + "/{token}/{orgid}/{serialnumber}/{cardtype}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getKeyClearEmptyCard(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid, @PathParam("serialnumber") String serialnumber,
			@PathParam("cardtype") int cardtype) {

		ResultObject result = new ResultObject(Status.FAILED);

		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<KeyDTO> lstcard = KMSController.Instance.getKeyClearEmptyCard(orgid, serialnumber, cardtype);
			if (lstcard != null && lstcard.size() > 0) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstcard);
			} else {
				result.setStatus(Status.FAILED);
				result.setObj(null);
			}

		}
		return result;
	}

	/**
	 * clear empty all card
	 * 
	 * @param session
	 * @param token
	 * @param serialnumber
	 * @return
	 */
	@GET
	@Path(Defines.CLEAR_EMPTY_CARDCHIP + "/{token}/{serialnumber}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getclearEmptyCard(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("serialnumber") String serialnumber) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			ChipPersonalizationController.Instance.clearCardData(serialnumber);
			CardChipController.Instance.deleteCardChip(serialnumber);
			result.setStatus(Status.SUCCESS);
		}
		return result;
	}

	/**
	 * get list cardchip for export
	 * 
	 * @param session
	 * @param token
	 * @param serialnumber
	 * @return
	 */
	@GET
	@Path(Defines.GET_CARD_CHIP_LIST_EXPORT + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetCardChipListExport(@CookieParam("sessionid") String session,
			@PathParam("token") String token) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<CardChip> lstCardChip = CardChipController.Instance.getCardChipListExport();
			if (lstCardChip != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstCardChip);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
	/**
	 * get list cardchip for export
	 * 
	 * @param session
	 * @param token
	 * @param serialnumber
	 * @return
	 */
	@GET
	@Path(Defines.GET_CARD_CHIP_LIST_BY_ORG_PARTNER + "/{token}/{orgId}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject GetCardChipListByOrgPartner(@CookieParam("sessionid") String session,
			@PathParam("token") String token,@PathParam("orgId") long orgId) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		
		if (flag) {
			List<CardChip> lstCardChip = CardChipController.Instance.getCardChipListByOrg(orgId);
			if (lstCardChip != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstCardChip);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	/**
	 * Import data card from excel
	 * 
	 * @param session
	 * @param token
	 * @param username
	 * @return
	 */
	@POST
	@Path(Defines.IMPORT_CARD_FROM_EXCEL + "/{token}/{username}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject importDataFromExcel(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("username") String username, JSONArray jsonArray) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		List<CardChip> lstCard = new ArrayList<CardChip>();

		try {
			TypeToken<List<CardChip>> tokenObj = new TypeToken<List<CardChip>>() {
			};
			Gson gson = new Gson();
			lstCard = gson.fromJson(jsonArray.toString(), tokenObj.getType());

		} catch (Exception e) {
			// TODO: handle exception
		}
		if (flag) {
			int kq = CardChipController.Instance.importCardFromExcel(username,lstCard);
			if (kq==0) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}
}