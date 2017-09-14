/**
 * 
 */
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
import com.swt.sworld.cms.domain.Organization;
import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.cms.impls.AcquirerController;
import com.swt.sworld.cms.impls.OrganizationController;
import com.swt.sworld.cms.impls.PartnersController;
import com.swt.sworld.cms.impls.SubOrganizationController;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.common.utilitis.TokenManager;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.communication.customer.object.CmsOrgCustomerDto;
import com.swt.sworld.communication.customer.object.MasterInfoDTO;
import com.swt.sworld.communication.customer.object.MemberCustomerDTO;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.communication.customer.object.MemberMagneticPersoDTO;
import com.swt.sworld.communication.customer.object.MoveMemberSubOrg;
import com.swt.sworld.communication.customer.object.OrgCustomerDto;
import com.swt.sworld.communication.customer.object.OrgFilterDto;
import com.swt.sworld.communication.customer.object.PartnerInfoDto;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.communication.customer.object.SubOrgCustomerDto;
import com.swt.sworld.communication.customer.object.SubOrgFilterDto;
import com.swt.sworld.communication.customer.object.TotalMemberDTO;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.sworld.ps.impl.MoveSubOrganizationController;

/**
 * @author Vo tinh
 * 
 */
@Path(Defines.ORG)
@Produces(Defines.APPLICATION_JSON)
public class OrganizationManager {
	@Context
	UriInfo uriInfo;

	@Context
	Request request;

	@GET
	@Consumes(Defines.APPLICATION_JSON)
	@Path(Defines.GET_MASTER_DATA_BY_KEY + "/{token}/{code}")
	public ResultObject getMasterDataByKey(@CookieParam(value = "sessionid") String session,
			@PathParam("token") String token, @PathParam("code") String code) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			MasterInfoDTO masterDto = OrganizationController.Instance.getDataMasterByKey(code);
			if (null != masterDto)
				result.setStatus(Status.SUCCESS);

			result.setObj(masterDto);

		}

		return result;
	}

	@GET
	@Path(Defines.GET_PARTNER_DATA_BY_KEY + "/{token}/{masterid}/{code}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getPartnerDataByKey(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("masterid") int masterid, @PathParam("code") String code) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<PartnerInfoDto> lstpartnerDto = OrganizationController.Instance.getDataPartnerByKey(masterid, code);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstpartnerDto);
		}
		return result;
	}

	@GET
	@Path(Defines.GET_MEMBER_BY_CODE + "/{token}/{orgId}/{memberCode}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getMemberByCode(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgId") long orgId, @PathParam("memberCode") String memberCode) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Member member = MemberController.Instance.getMemberByCode(orgId, memberCode);
			result.setStatus(Status.SUCCESS);
			result.setObj(member);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_SUBORG_DATA_BY_ORG_ID + "/{token}/{orgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") int orgid, JSONObject subOrgFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SubOrgFilterDto filter = new SubOrgFilterDto();
			filter = Utilites.getInstance().convertJsonObjToObject(subOrgFilter, filter.getClass());
			List<SubOrgCustomerDto> lstSubOrg = SubOrganizationController.Instance.getSubOrgListDataByOrgId(orgid);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstSubOrg);
		}
		return result;
	}

	// Loc lam cai nay
	@GET
	@Consumes(Defines.APPLICATION_JSON)
	@Path(Defines.GET_MEMBER_BY_SUBORGID + "/{token}/{suborgid}")
	public ResultObject getMemberBySubOrgId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("suborgid") long suborgid) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Member> lstMember = MemberController.Instance.getMemberBySubOrgId(suborgid);
			if (null != lstMember) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstMember);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.GET_SUBORG_BY_ORGID + "/{token}/{orgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postSubOrgByOrgId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid, JSONObject subOrgFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			SubOrgFilterDto filter = new SubOrgFilterDto();
			filter = Utilites.getInstance().convertJsonObjToObject(subOrgFilter, filter.getClass());
			List<SubOrgCustomerDto> lstSubOrg = SubOrganizationController.Instance.getSubOrgListByOrgId(orgid, filter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstSubOrg);
		}
		return result;
	}

	// @POST
	// @Path(Defines.GET_MEMBERPERSO_BY_ORGID_SUBORGID
	// + "/{token}/{orgid}/{suborgid}")
	// @Consumes(MediaType.APPLICATION_JSON)
	// public ResultObject postMemberPersoByOrgSubId(
	// @CookieParam("sessionid") String session,
	// @PathParam("token") String token, @PathParam("orgid") long orgid,
	// @PathParam("suborgid") long suborgid, JSONObject persoFilter) {
	//
	// ResultObject result = new ResultObject(Status.FAILED);
	// boolean flag = TokenManager.getInstance().checkTokenSession(session,
	// token);
	// if (flag) {
	// PersoChipFilter filter = new PersoChipFilter();
	// filter = Utilites.getInstance().convertJsonObjToObject(persoFilter,
	// filter.getClass());
	// List<MemberCustomerDTO> lstMemberCus = MemberController.Instance
	// .getMemberListBySubOrgId(orgid, suborgid, filter);
	// result.setStatus(Status.SUCCESS);
	// result.setObj(lstMemberCus);
	// }
	// return result;
	// }
	/**
	 * get listmemberPeso Sửa lại với menu nhiều cấp
	 * 
	 * @param session
	 * @param token
	 * @param orgid
	 * @param suborgid
	 * @param persoFilter
	 * @return
	 */
	@POST
	@Path(Defines.GET_MEMBERPERSO_BY_ORGID_SUBORGID + "/{token}/{orgid}/{parentorgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMemberPersoByOrgSubId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid,
			@PathParam("parentorgid") long parentOrgId, JSONObject persoFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			PersoChipFilter filter = new PersoChipFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(persoFilter, filter.getClass());
			List<MemberCustomerDTO> lstMemberCus = MemberController.Instance.getMemberListBySubOrgId(orgid, parentOrgId,
					filter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMemberCus);
		}
		return result;
	}

	// @POST
	// @Path(Defines.GET_MEMBERLIST_BY_SUBORGID + "/{token}/{orgid}/{suborgid}")
	// @Consumes(MediaType.APPLICATION_JSON)
	// public ResultObject postMemberListBySubId(
	// @CookieParam("sessionid") String session,
	// @PathParam("token") String token, @PathParam("orgid") long orgid,
	// @PathParam("suborgid") long suborgid, JSONObject memberFilter) {
	//
	// ResultObject result = new ResultObject(Status.FAILED);
	// boolean flag = TokenManager.getInstance().checkTokenSession(session,
	// token);
	// if (flag) {
	// MemberFilter filter = new MemberFilter();
	// filter = Utilites.getInstance().convertJsonObjToObject(
	// memberFilter, filter.getClass());
	// List<MemberCustomerDTO> lstMemberCus = MemberController.Instance
	// .getMemberListBySub(orgid, suborgid, filter);
	// result.setStatus(Status.SUCCESS);
	// result.setObj(lstMemberCus);
	// }
	// return result;
	// }
	/**
	 * Get list member Sửa lại với menu nhieuf cấp
	 * 
	 * @param session
	 * @param token
	 * @param orgid
	 * @param parentorgid
	 * @param memberFilter
	 * @return
	 */
	@POST
	@Path(Defines.GET_MEMBERLIST_BY_SUBORGID + "/{token}/{orgid}/{parentorgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postMemberListBySubId(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid,
			@PathParam("parentorgid") long parentorgid, JSONObject memberFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			MemberFilter filter = new MemberFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(memberFilter, filter.getClass());
			List<MemberCustomerDTO> lstMemberCus = MemberController.Instance.getMemberListBySub(orgid, parentorgid,
					filter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMemberCus);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_MEMBER_PERSO_MAGNETIC_LIST + "/{token}/{orgid}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetMemPerspMagneticList(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgid, @PathParam("suborgid") long suborgid,
			JSONObject cardmagneticfilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		CardMagneticFilterDto cardMagneticFilter = new CardMagneticFilterDto();
		cardMagneticFilter = Utilites.getInstance().convertJsonObjToObject(cardmagneticfilter,
				cardMagneticFilter.getClass());
		if (flag) {
			List<MemberMagneticPersoDTO> lstMemberMagnetic = MemberController.Instance.getMemBerListMagnetic(orgid,
					orgid, cardMagneticFilter);
			result.setStatus(Status.SUCCESS);
			result.setObj(lstMemberMagnetic);
		}

		return result;
	}

	@POST
	@Path(Defines.GET_ORG_LIST + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetOrgList(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject orgFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		OrgFilterDto filter = new OrgFilterDto();
		filter = Utilites.getInstance().convertJsonObjToObject(orgFilter, filter.getClass());
		if (flag) {
			List<OrgCustomerDto> lstOrg = OrganizationController.Instance.getOrgList(filter);
			if (lstOrg == null) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstOrg);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.GET_ORG_BY_ORG_ID + "/{token}/{orgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getGetOrgByOrgId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Organization lstOrg = OrganizationController.Instance.getOrgByOrgId(orgid);
			if (lstOrg == null) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstOrg);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.ADD_ORG + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postAddOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject organization) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {

			Organization org = new Organization();
			org = Utilites.getInstance().convertJsonObjToObject(organization, org.getClass());
			int kq = ErrorCode.UNKNOW;
			if (org != null)
				kq = OrganizationController.Instance.addOrg(session, org);

			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
				result.setObj(org);
			} else {
				result.setStatus(Status.FAILED);
				result.setObj(org);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.IMPORT_MEMBER_DATA + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postImportMemberData(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONArray lstmemberdata) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		List<Member> lstMember = new ArrayList<Member>();

		try {
			TypeToken<List<Member>> tokenObj = new TypeToken<List<Member>>() {
			};
			Gson gson = new Gson();
			lstMember = gson.fromJson(lstmemberdata.toString(), tokenObj.getType());

		} catch (Exception e) {
		}
		if (flag) {
			List<Member> lstNoInsert = MemberController.Instance.insertMember(lstMember);

			if (lstNoInsert.size() == 0) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstNoInsert);
			} else {
				result.setStatus(Status.FAILED);
				result.setObj(lstNoInsert);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.UPDATE_ORG + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject organization) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		Organization org = new Organization();
		org = Utilites.getInstance().convertJsonObjToObject(organization, org.getClass());
		if (flag) {
			int kq = OrganizationController.Instance.updateOrg(session, org);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
				result.setObj(org);
			} else {
				result.setStatus(Status.FAILED);
				result.setObj(org);
			}
		}
		return result;
	}

	@GET
	@Path(Defines.DELETE_ORG + "/{token}/{orgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getDeleteOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = OrganizationController.Instance.deleteOrg(orgid);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.INSERT_SUBORGANIZATION + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postInsertSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject suborganization) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		SubOrganization suborg = new SubOrganization();
		suborg = Utilites.getInstance().convertJsonObjToObject(suborganization, suborg.getClass());
		if (flag) {
			int kq = SubOrganizationController.Instance.insertSubOrg(session, suborg);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.UPDATE_SUBORGANIZATION + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject suborganization) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		SubOrganization suborg = new SubOrganization();
		suborg = Utilites.getInstance().convertJsonObjToObject(suborganization, suborg.getClass());
		if (flag) {
			int kq = SubOrganizationController.Instance.updateSubOrg(session, suborg);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.DELETE_SUBORGANIZATION + "/{token}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postDeleteSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("suborgid") long suborgid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = SubOrganizationController.Instance.deleteSubOrg(suborgid);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.GET_SUB_ORG_BY_ID + "/{token}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getSubOrgById(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("suborgid") long suborgid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			SubOrganization suborg = SubOrganizationController.Instance.getSubOrgById(suborgid);
			if (suborg != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(suborg);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.INSERT_MEMBER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postInsertMember(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject mem) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		Member member = new Member();
		member = Utilites.getInstance().convertJsonObjToObject(mem, member.getClass());
		if (flag) {
			int kq = MemberController.Instance.insertMember(member);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
				result.setObj(member);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.UPDATE_MEMBER + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postUpdateMember(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject mem) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		Member member = new Member();
		member = Utilites.getInstance().convertJsonObjToObject(mem, member.getClass());
		if (flag) {
			int kq = MemberController.Instance.updateMember(member);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.DELETE_MEMBER + "/{token}/{memid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getDeleteMember(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("memid") long memid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			int kq = MemberController.Instance.deleteMember(memid);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.GET_MEMBER_BY_MEM_ID + "/{token}/{memid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetMemberByMemId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("memid") long memid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			Member mem = MemberController.Instance.getMemberById(memid);
			if (mem == null) {
				result.setStatus(Status.FAILED);
			} else {
				result.setStatus(Status.SUCCESS);
				result.setObj(mem);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.GET_SUB_ORG_LIST_BY_ORG_ID + "/{token}/{orgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getSubOrgListByOrgId(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid, JSONObject orgfilterdto) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrgFilterDto filter = new OrgFilterDto();
			filter = Utilites.getInstance().convertJsonObjToObject(orgfilterdto, filter.getClass());
			List<SubOrganization> lstsuborg = SubOrganizationController.Instance.getSubOrgByOrgId(orgid, filter);
			if (lstsuborg != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstsuborg);
			} else {
				lstsuborg = null;
				result.setStatus(Status.SUCCESS);
				result.setObj(lstsuborg);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.GET_ALL_ORG_LIST + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllOrgList(@CookieParam("sessionid") String session, @PathParam("token") String token) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<CmsOrgCustomerDto> lstorg = OrganizationController.Instance.getAllOrgList();
			result.setStatus(Status.SUCCESS);
			result.setObj(lstorg);
		}
		return result;
	}

	@GET
	@Path(Defines.GET_MASTER_LIST + "/{token}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllMasterList(@CookieParam("sessionid") String session, @PathParam("token") String token) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<CmsOrgCustomerDto> lstorg = PartnersController.Instance.getAllMasterList();
			result.setStatus(Status.SUCCESS);
			result.setObj(lstorg);
		}
		return result;
	}

	@POST
	@Path(Defines.GET_PARTNER_LIST + "/{token}/{masterid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getAllMasterList(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("masterid") long masterid, JSONObject filter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrgFilterDto orgfilter = new OrgFilterDto();
			orgfilter = Utilites.getInstance().convertJsonObjToObject(filter, orgfilter.getClass());
			List<CmsOrgCustomerDto> lstorg = PartnersController.Instance.getPartnerByMasterIdAndFilter(masterid,
					orgfilter);
			if (lstorg != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstorg);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.INSERT_PARTNER_OF_MASTER + "/{token}/{masterid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postInsertPartnerOfMaster(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("masterid") long masterid, JSONArray lstpartnerid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> lstpnId = Utilites.getInstance().convertJsonArrayToListLong(lstpartnerid);
			int kq = PartnersController.Instance.insertPartnerOfMaster(masterid, lstpnId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.INSERT_ORG_ACQUIRER + "/{token}/{masterid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postInsertOrgAcquirer(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("masterid") long masterid, JSONArray lstpartnerid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> lstpnId = Utilites.getInstance().convertJsonArrayToListLong(lstpartnerid);
			int kq = AcquirerController.Instance.insertOrgAcquirer(session, masterid, lstpnId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.DELETE_PARTNER_OF_MASTER + "/{token}/{masterid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postDeletePartnerOfMaster(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("masterid") long masterid, JSONArray lstpartnerid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> lstpnId = Utilites.getInstance().convertJsonArrayToListLong(lstpartnerid);
			int kq = PartnersController.Instance.deletePartnerOfMaster(masterid, lstpnId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.DELETE_ORG_ACQUIRER + "/{token}/{masterid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postDeleteOrgAcquirer(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("masterid") String mastercode, JSONArray lstpartnerid) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Long> lstpnId = Utilites.getInstance().convertJsonArrayToListLong(lstpartnerid);
			int kq = AcquirerController.Instance.deleteOrgQcquirer(mastercode, lstpnId);
			if (kq == ErrorCode.SUCCESS) {
				result.setStatus(Status.SUCCESS);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	@POST
	@Path(Defines.GET_PARTNER_ACQUIRER_LIST + "/{token}/{mastercode}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getPartnerAcquirerList(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("mastercode") String mastercode, JSONObject filter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrgFilterDto orgfliter = new OrgFilterDto();
			orgfliter = Utilites.getInstance().convertJsonObjToObject(filter, orgfliter.getClass());
			List<CmsOrgCustomerDto> lstorg = AcquirerController.Instance.getPartnerByMastercode(mastercode, orgfliter);
			if (lstorg != null) {
				result.setStatus(Status.SUCCESS);
				result.setObj(lstorg);
			} else {
				result.setStatus(Status.FAILED);
			}
		}
		return result;
	}

	// trang.vo

	/**
	 * getmember cho thong ke cham cong
	 * 
	 * @param session
	 * @param token
	 * @param orgid
	 * @param subOrgFilter
	 * @return
	 */
	@POST
	@Path(Defines.GET_MEMBER_BY_TOTAL_COUNT + "/{token}/{orgid}/{suborgid}/{start}/{length}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetListMember(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid, @PathParam("suborgid") long subOrgId, @PathParam("start") int start,
			@PathParam("length") int length, JSONObject subOrgFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			MemberFilter filter = new MemberFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(subOrgFilter, filter.getClass());
			List<Member> listMember = MemberController.Instance.getMemberBytotalCount(orgid, subOrgId, filter, start,
					length);
			result.setStatus(Status.SUCCESS);
			result.setObj(listMember);
		}
		return result;
	}

	/**
	 * get count of member
	 * 
	 * @param session
	 * @param token
	 * @param orgid
	 * @param subOrgId
	 * @param start
	 * @param length
	 * @param subOrgFilter
	 * @return
	 */
	@POST
	@Path(Defines.GET_MEMBER_COUNT + "/{token}/{orgid}/{suborgid}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject postGetMemberCount(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("orgid") long orgid, @PathParam("suborgid") long subOrgId, JSONObject subOrgFilter) {

		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			MemberFilter filter = new MemberFilter();
			filter = Utilites.getInstance().convertJsonObjToObject(subOrgFilter, filter.getClass());
			long cntListMember = MemberController.Instance.getTotalMember(orgid, subOrgId, filter);
			TotalMemberDTO totalMember = new TotalMemberDTO(cntListMember);
			result.setStatus(Status.SUCCESS);
			result.setObj(totalMember);
		}
		return result;
	}

	// minh.nguyen
	// MoveSubOrganizationManager
	@POST
	@Path(Defines.GET_LIST_SUBORG + "/{token}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getListSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			JSONObject orgfilter) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			OrgFilterDto orgFilter = new OrgFilterDto();
			orgFilter = Utilites.getInstance().convertJsonObjToObject(orgfilter, orgFilter.getClass());
			List<OrgCustomerDto> listOrg = MoveSubOrganizationController.Instance.getListSubOrg(orgFilter);

			if (null != listOrg) {
				result.setStatus(Status.SUCCESS);
				result.setObj(listOrg);
			}
		}

		return result;
	}

	@GET
	@Path(Defines.GET_LIST_MEMBER + "/{token}/{orgid}/{parentorgid}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject getListMemberBySubOrgID(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("orgid") long orgID,
			@PathParam("parentorgid") long parentOrgID) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			List<Member> listMember = MoveSubOrganizationController.Instance.getListMemberBySubOrgID(orgID,
					parentOrgID);
			if (null != listMember) {
				result.setStatus(Status.SUCCESS);
				result.setObj(listMember);
			}
		}

		return result;
	}

	@POST
	@Path(Defines.MOVE_MEMBER_SUBORG + "/{token}/{suborgidleft}/{suborgidright}")
	@Consumes(Defines.APPLICATION_JSON)
	public ResultObject moveSubOrg(@CookieParam("sessionid") String session, @PathParam("token") String token,
			@PathParam("suborgidleft") long subOrgIdLeft, @PathParam("suborgidright") long subOrgIdRight,
			JSONArray jsonMemberIDLeftRight) {
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag;

		flag = TokenManager.getInstance().checkTokenSession(session, token);
		if (flag) {
			try {
				TypeToken<List<MoveMemberSubOrg>> typeToken = new TypeToken<List<MoveMemberSubOrg>>(){};
				Gson gson = new Gson();
				List<MoveMemberSubOrg> listMemberIDLeftRight = gson.fromJson(jsonMemberIDLeftRight.toString(), typeToken.getType());
				
				int iResult = MoveSubOrganizationController.Instance.moveSubOrg(subOrgIdLeft, subOrgIdRight, listMemberIDLeftRight);
				if (iResult == 1) // Success
					result.setStatus(Status.SUCCESS);
			} catch (Exception e) {
				e.printStackTrace();
			}
		}

		return result;
	}
}
